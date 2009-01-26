using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace TouchlessViewer
{
    public partial class MainWindow : Form
    {
        #region Loading of Basic Content

        private ImageRotator Rotator;
        public List<string> AllowedExtensions;
        private TouchlessManager tMgr = TouchlessManager.Instance;

        private ApplicationSettingsWindow applicationSettings = new ApplicationSettingsWindow();
        private CameraSettingsWindow cameraSettings = new CameraSettingsWindow();
        private AboutWindow aboutWindow = new AboutWindow();

        private double pictureBoxActiveArea = 0.2;

        private bool leftActive = false;
        private bool rightActive = false;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            this.ChangeTitle("No images loaded");
            this.PositionPictureBox();

            this.AllowedExtensions = new List<string>();
            this.AllowedExtensions.Add(".jpg");
            this.AllowedExtensions.Add(".png");
            this.AllowedExtensions.Add(".gif");
            this.AllowedExtensions.Add(".bmp");

            this.Rotator = new ImageRotator();

            if (args.Length == 1 && args[0] != "")
            {
                FileInfo file = new FileInfo(args[0]);
                if (file.Exists && this.AllowedExtensions.Contains(file.Extension.ToLower()))
                {
                    this.loadRotator(file.DirectoryName, file.FullName);
                }
            }

            this.updateStatusBar();
        }

        private void ChangeTitle(string title)
        {
            this.Text = "TouchLessViewer - " + title;
        }

        private void loadRotator(string path)
        {
            this.loadRotator(path, null);
        }

        private void loadRotator(string path, string filename)
        {
            this.Rotator.ImagePath = path;
            this.Rotator.AllowedExtensions = this.AllowedExtensions;
            this.Rotator.PictureBox = this.pictureBoxImage;
            this.Rotator.FormTitle = this.ChangeTitle;

            this.ChangeTitle("Loading...");
            this.Rotator.LoadImages();

            if (filename != null)
                this.Rotator.FindByFilename(filename);

            this.Rotator.Show();

        }
        #endregion

        #region Resizing and positioning of MainWindow & PictureBox
        private void MainWindow_ResizeBegin(object sender, EventArgs e)
        {
            // avoid "jumping around" when image is centered before resizing
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            this.PositionPictureBox();
            this.Rotator.Show();
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void PositionPictureBox()
        {
            this.pictureBoxImage.Width = this.ClientSize.Width;
            this.pictureBoxImage.Height = this.ClientSize.Height - this.MainMenuStrip.Height - this.statusStrip.Height;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, this.MainMenuStrip.Height);
            this.pictureBoxImage.Refresh();
        }
        #endregion

        #region Drag&Drop
        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string filename;
            bool isValid = CheckDragAndDropItem(out filename, e);

            if (isValid)
            {
                FileInfo file = new FileInfo(filename);
                if (file.Exists)
                {
                    this.ChangeTitle("Loading...");
                    this.loadRotator(file.DirectoryName, file.FullName);
                }
            }
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            string filename;
            bool isValid = CheckDragAndDropItem(out filename, e);

            if (isValid)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private bool CheckDragAndDropItem(out string filename, DragEventArgs e)
        {
            filename = String.Empty;
            bool isValid = false;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        if (this.AllowedExtensions.Contains(Path.GetExtension(filename).ToLower()))
                        {
                            isValid = true;
                        }
                    }
                }
            }

            return isValid;
        }
        #endregion

        #region Keyboard events
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.P || e.KeyCode == Keys.B)
                this.Rotator.ShowPrevious();
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.N)
                this.Rotator.ShowNext();
        }
        #endregion

        #region Threading to fade pictures

        /*Thread img_left = new Thread(new ThreadStart(Image_Left));
        Thread img_right = new Thread(new ThreadStart(Image_Right));*/

        Thread shiftThread;
        
        /*private void Image_Left()
        {
            Thread.Sleep(200);
            this.Rotator.ShowNext();
        }

        private static void Image_Right()
        {
            Thread.Sleep(200);
            this.Rotator.ShowPrevious();
        }*/

        /*private void StartThread(int position)
        {
            if (position == 0)
            {
                //img_left.Start();
                this.shiftThread = new Thread(new ThreadStart(this.Rotator.ThreadTest));

            }

            else if (position == 2)
            {
                img_right.Start();
            }
        }*/

        /*private void StopThread(int position)
        {
            if (position == 0)
            {
                if(img_left.ThreadState & ThreadState.Running == 1)
                {
                    img_left.Abort();
                }
            }

            else if (position == 2)
            {
                if (img_right.ThreadState & ThreadState.Running == 1)
                {
                    img_right.Abort();
                }
            }
        }*/

        #endregion

        #region Mainmenu
        private void fileChangeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select a directory.";

            if (this.Rotator != null)
                dialog.SelectedPath = this.Rotator.ImagePath;

            DialogResult dResult = dialog.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                this.loadRotator(dialog.SelectedPath);
            }
        }

        private void fileQuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.applicationSettings.ShowDialog();
        }

        private void cameraSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cameraSettings.FormClosed += new FormClosedEventHandler(cameraSettings_FormClosed);
            this.cameraSettings.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.aboutWindow.ShowDialog();
        }

        private void cameraSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.setTouchlessEvents();
            this.updateStatusBar();
        }

        private void setTouchlessEvents()
        {
            if (this.tMgr.Touchless.CurrentCamera != null && this.tMgr.Touchless.MarkerCount == 1)
            {
                if (this.tMgr.Touchless.Markers[0] != this.tMgr._currentMarker)
                {
                    this.tMgr._currentMarker = this.tMgr.Touchless.Markers[0];
                    this.tMgr._currentMarker.OnChange += new EventHandler<TouchlessLib.MarkerEventArgs>(_currentMarker_OnChange);
                    this.pictureBoxImage.Paint += new PaintEventHandler(pictureBoxImage_Paint);

                }
            }
            else
            {
                this.pictureBoxImage.Paint -= new PaintEventHandler(pictureBoxImage_Paint);
            }
        }
        #endregion

        #region wichtig
        void pictureBoxImage_Paint(object sender, PaintEventArgs e)
        {
            Point markerLocation = this.getMarkerLocation();

            // Draws an ellipse that indicates the current marker position on the picture
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red)), markerLocation.X, markerLocation.Y, 15, 15);
            this.toolStripStatusCursorPosition.Text = "Cursor X: " + markerLocation.X + " Y: " + markerLocation.Y;
        }


        delegate void RotatorNext();

        void _currentMarker_OnChange(object sender, TouchlessLib.MarkerEventArgs e)
        {
            Point markerLocation = this.getMarkerLocation();
            double activeArea = this.pictureBoxImage.Width * this.pictureBoxActiveArea;


            int position = 1; // 0 = left, 1 = center, 2 = right

            if (markerLocation.X >= 0 && markerLocation.X < activeArea) 
            {
                position = 0; // Ellipse is in Left Area
                this.toolStripStatusAreaPosition.Text = "Left";
            }
            else if (markerLocation.X >= (this.pictureBoxImage.Width - activeArea) && markerLocation.X <= this.pictureBoxImage.Width)
            {
                position = 2; // Ellipse is in Center Area
                this.toolStripStatusAreaPosition.Text = "Right";  
            }
            else
            {
                position = 1; // Ellipse is in Right Area
                this.toolStripStatusAreaPosition.Text = "Center";
            }            
            

            if(position == 0) // Left Enter
            {
                if (!this.leftActive)
                {
                    this.leftActive = true;
                    pictureBoxImage.Invoke(new RotatorNext(this.Rotator.ShowPrevious));
                }
            }
            
            if(position == 2) // Right Enter
            {
                if (!this.rightActive)
                {
                    this.rightActive = true;
                    pictureBoxImage.Invoke(new RotatorNext(this.Rotator.ShowNext));
                }
            }

            if(this.leftActive) // Left leave check
            {
                if (position != 0)
                {
                    this.leftActive = false;
                }
            }
            
            if(this.rightActive) // Right leave check
            {
                if (position != 2)
                {
                    this.rightActive = false;
                }
            }

            this.toolStripStatusMarkerPosition.Text = "Marker X: " + tMgr._currentMarker.CurrentData.X + " Y: " + tMgr._currentMarker.CurrentData.Y;

            // cause PictureBox.Paint
            this.pictureBoxImage.Invalidate();
        }

        /// <summary>
        /// Calculate marker position in pictureBox
        /// </summary>
        /// <returns></returns>
        private Point getMarkerLocation()
        {
            double percentageX = (double)this.tMgr._currentMarker.CurrentData.X / (double)this.tMgr.Touchless.CurrentCamera.CaptureWidth;
            double percentageY = (double)this.tMgr._currentMarker.CurrentData.Y / (double)this.tMgr.Touchless.CurrentCamera.CaptureHeight;

            int positionX = (int)(this.pictureBoxImage.Width * percentageX);
            int positionY = (int)(this.pictureBoxImage.Height * percentageY);

            return new Point(positionX, positionY);
        }

        private void updateStatusBar()
        {
            if (this.tMgr.Touchless.CurrentCamera != null)
            {
                this.toolStripCameraStatus.Text = "Camera: " + this.tMgr.Touchless.CurrentCamera.ToString() + ".";
            }
            else
            {
                this.toolStripCameraStatus.Text = "No Camera loaded.";
            }

            if (this.tMgr.Touchless.MarkerCount > 0)
            {
                this.toolStripMarkerStatus.Text = "Marker ready.";
            }
            else
            {
                this.toolStripMarkerStatus.Text = "No Markers set.";
            }
        }
        #endregion
    }
}
