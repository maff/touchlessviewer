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
        private ImageRotator Rotator;
        public List<string> AllowedExtensions;
        private TouchlessManager tMgr = TouchlessManager.Instance;

        private ApplicationSettingsWindow applicationSettings = new ApplicationSettingsWindow();
        private CameraSettingsWindow cameraSettings = new CameraSettingsWindow();
        private AboutWindow aboutWindow = new AboutWindow();

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
            this.Rotator = new ImageRotator();
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

        #region Resizing and positioning of MainWindow & PictureBox
        private void MainWindow_ResizeBegin(object sender, EventArgs e)
        {
            // avoid "jumping around" when image is centered before resizing
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;

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
                        if(this.AllowedExtensions.Contains(Path.GetExtension(filename).ToLower()))
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

        #region Mainmenu
        private void fileChangeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select a directory.";

            if(this.Rotator != null)
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

        void pictureBoxImage_Paint(object sender, PaintEventArgs e)
        {
            float x = getInterpolationX(); // interpolated X value
            float y = getInterpolationY(); // interpolated Y value
            // creates a Pen
            Pen pen = new Pen(Color.Red);
            this.toolStripStatusCursorPosition.Text = x + " " + y; // shows the interpolated marker values
            // Draws an ellipse that indicates the current marker position on the picture
            e.Graphics.DrawEllipse(pen, x, y, 20, 20);
            
        }

        void _currentMarker_OnChange(object sender, TouchlessLib.MarkerEventArgs e)
        {
            this.toolStripStatusMarkerPosition.Text = tMgr._currentMarker.CurrentData.X + " " + tMgr._currentMarker.CurrentData.Y;
            this.pictureBoxImage.Invalidate(); // causes PictureBox.Paint (refresh of the image)

            // Check for Left Upper "Button"
            float areaLUWidth = (this.pictureBoxImage.Width * 0.2); // 20% of the width left side
            float areaLUHeigth = (this.pictureBoxImage.Height * 0.2); // 20% of the Height left side
            float areaRUWidth = (this.pictureBoxImage.Width * 0.8); // 80% of the width right side

            if (((this.tMgr._currentMarker.CurrentData.X >= 0) && (this.tMgr._currentMarker.CurrentData.X <= areaLUWidth)) && ((this.tMgr._currentMarker.CurrentData.Y >= 0) && (this.tMgr._currentMarker.CurrentData.Y <= areaLUHeigth)))
            {
                // left
            }
            else if(((this.tMgr._currentMarker.CurrentData.X >= areaRUWidth) && (this.tMgr._currentMarker.CurrentData.X < this.pictureBoxImage.Width)) &&
                    ((this.tMgr._currentMarker.CurrentData.Y >= 0) && (this.tMgr._currentMarker.CurrentData.Y <= areaLUHeigth))
                   )
            {
                // right
            }


        }

        private float getInterpolationX()
        {
            // calculates the interpolated Position of the X value
            float x = this.tMgr._currentMarker.CurrentData.X * (this.pictureBoxImage.Width / this.tMgr.Touchless.CurrentCamera.CaptureWidth);
            return x;
        }

        private float getInterpolationY()
        {
            // calculates the interpolated Position of the X value
            float y = this.tMgr._currentMarker.CurrentData.Y * (this.pictureBoxImage.Height / this.tMgr.Touchless.CurrentCamera.CaptureHeight);
            return y;
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
