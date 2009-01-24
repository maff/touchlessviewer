using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TouchlessLib;

namespace TouchlessViewer
{
    public partial class CameraSettingsWindow : Form
    {
        private TouchlessManager tMgr = TouchlessManager.Instance;

        public CameraSettingsWindow()
        {
            InitializeComponent();

            loadCameraComboBox();
            activateCamera();
        }


        private void CameraSettingsWindow_Load(object sender, EventArgs e)
        {
            if (tMgr.checkCameras())
            {
                Common.ShowError("No cameras found. Touchless functionality will be disabled.");
                this.Close();
            }
        }

        private void buttonAdjustCamera_Click(object sender, EventArgs e)
        {
            if (comboBoxCameras.SelectedIndex < 0)
                return;

            Camera c = (Camera) comboBoxCameras.SelectedItem;
            c.ShowPropertiesDialog(this.Handle);
        }

        private void comboBoxCameras_DropDown(object sender, EventArgs e)
        {
            comboBoxCameras.Items.Clear();
            foreach (Camera cam in tMgr.Touchless.Cameras)
                comboBoxCameras.Items.Add(cam);
        }

        private void loadCameraComboBox()
        {
            comboBoxCameras.Items.Clear();
            int i = 0;
            int index = 0;
            foreach (Camera cam in tMgr.Touchless.Cameras)
            {
                comboBoxCameras.Items.Add(cam);
                if (cam == this.tMgr.Touchless.CurrentCamera)
                    index = i;

                i++;
            }

            this.comboBoxCameras.SelectedIndex = index;
        }

        private void activateCamera()
        {
            // Early return if we've selected the current camera
            if (this.tMgr.Touchless.CurrentCamera == (Camera)this.comboBoxCameras.SelectedItem)
                return;

            // Trash the old camera
            if (this.tMgr.Touchless.CurrentCamera != null)
            {

            }

            try
            {
                Camera c = (Camera)comboBoxCameras.SelectedItem;
                c.OnImageCaptured += new EventHandler<CameraEventArgs>(c_OnImageCaptured);
                this.tMgr.Touchless.CurrentCamera = c;
                this.tMgr._dtFrameLast = DateTime.Now;

                pictureBoxCamera.Paint += new PaintEventHandler(pictureBoxCamera_Paint);
            }
            catch (Exception ex)
            {
                Common.ShowError(ex.Message);
            }
        }

        private void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.activateCamera();
        }

        private void pictureBoxCamera_Paint(object sender, PaintEventArgs e)
        {
            if (this.tMgr._latestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(this.tMgr._latestFrame, 0, 0, this.pictureBoxCamera.Width, this.pictureBoxCamera.Height);

                // Draw the selection adornment
                if (this.tMgr._drawSelectionAdornment)
                {
                    Pen pen = new Pen(Brushes.Red, 1);
                    e.Graphics.DrawEllipse(pen, this.tMgr._markerCenter.X - this.tMgr._markerRadius, this.tMgr._markerCenter.Y - this.tMgr._markerRadius, 2 * this.tMgr._markerRadius, 2 * this.tMgr._markerRadius);
                }
            }
        }

        private void c_OnImageCaptured(object sender, CameraEventArgs e)
        {
            // Calculate FPS (only update the display once every second)
            ++this.tMgr._nFrameCount;
            double milliseconds = (DateTime.Now.Ticks - this.tMgr._dtFrameLast.Ticks) / TimeSpan.TicksPerMillisecond;
            if (milliseconds >= 1000)
            {
                //this.BeginInvoke(new Action<double>(UpdateFPSInUI), new object[] { this.tMgr._nFrameCount * 1000.0 / milliseconds });
                this.tMgr._nFrameCount = 0;
                this.tMgr._dtFrameLast = DateTime.Now;
            }

            // Save the latest image for drawing
            if (!this.tMgr._addingMarker)
            {
                // Cause display update
                this.tMgr._latestFrame = e.Image;
                pictureBoxCamera.Invalidate();
            }
        }



        private void buttonAddMarker_Click(object sender, EventArgs e)
        {
            bool switchState = true;

            if (!this.tMgr._addingMarker && this.tMgr.Touchless.MarkerCount == 0)
            {
                buttonAddMarker.Text = "Cancel Adding Marker";
            }
            else if (!this.tMgr._addingMarker && this.tMgr.Touchless.MarkerCount > 0)
            {
                buttonAddMarker.Text = "Add Marker";
                removeMarker();
                switchState = false;
            }

            if(switchState)
                this.tMgr._addingMarker = !this.tMgr._addingMarker;
        }

        private void removeMarker()
        {
            for(int i = 0; i < this.tMgr.Touchless.MarkerCount; i++)
            {
                this.tMgr.Touchless.RemoveMarker(i);
            }

            this.groupBoxMarkerSettings.Enabled = false;
            this.numericUpDownThreshold.Value = 0;
            this.textBoxMarkerData.Lines = null;
        }






        private void pictureBoxCamera_MouseDown(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker center on mouse down
            if (this.tMgr._addingMarker)
            {
                this.tMgr._markerCenter = e.Location;
                this.tMgr._markerRadius = 0;

                // Begin drawing the selection adornment
                this.tMgr._drawSelectionAdornment = true;
            }
        }

        private void pictureBoxCamera_MouseUp(object sender, MouseEventArgs e)
        {
            // If we are adding a marker - get the marker radius on mouse up, add the marker
            if (this.tMgr._addingMarker)
            {
                int dx = e.X - this.tMgr._markerCenter.X;
                int dy = e.Y - this.tMgr._markerCenter.Y;
                this.tMgr._markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);
                
                // Adjust for the image/display scaling (assumes proportional scaling)
                this.tMgr._markerCenter.X = (this.tMgr._markerCenter.X * this.tMgr._latestFrame.Width) / pictureBoxCamera.Width;
                this.tMgr._markerCenter.Y = (this.tMgr._markerCenter.Y * this.tMgr._latestFrame.Height) / pictureBoxCamera.Height;
                this.tMgr._markerRadius = (this.tMgr._markerRadius * this.tMgr._latestFrame.Height) / pictureBoxCamera.Height;
                
                // Add the marker
                Marker marker = this.tMgr.Touchless.AddMarker("Marker", (Bitmap)this.tMgr._latestFrame, this.tMgr._markerCenter, this.tMgr._markerRadius);
                marker.SmoothingEnabled = this.checkBoxSmoothMarker.Checked;
                marker.Highlight = this.checkBoxHighlight.Checked;
                marker.OnChange += new EventHandler<MarkerEventArgs>(OnMarkerUpdate);

                this.groupBoxMarkerSettings.Enabled = true;
                this.numericUpDownThreshold.Value = (decimal)(marker.Threshold);

                // Restore the app to its normal state and clear the selection area adorment
                this.tMgr._addingMarker = false;
                this.buttonAddMarker.Text = "Remove Marker";

                this.tMgr._markerCenter = new Point();
                this.tMgr._drawSelectionAdornment = false;
                pictureBoxCamera.Image = new Bitmap(pictureBoxCamera.Width, pictureBoxCamera.Height);
            }
        }

        private void pictureBoxCamera_MouseMove(object sender, MouseEventArgs e)
        {
            // If the user is selecting a marker, draw a circle of their selection as a selection adornment
            if (this.tMgr._addingMarker)
            {
                // Get the current radius
                int dx = e.X - this.tMgr._markerCenter.X;
                int dy = e.Y - this.tMgr._markerCenter.Y;
                this.tMgr._markerRadius = (float)Math.Sqrt(dx * dx + dy * dy);

                // Cause display update
                pictureBoxCamera.Invalidate();
            }
        }

        /// <summary>
        /// Event Handler from the selected marker in the Marker Mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnMarkerUpdate(object sender, MarkerEventArgs args)
        {
            try
            {
                this.BeginInvoke(new Action<MarkerEventData>(UpdateMarkerDataInUI), new object[] { args.EventData });
            }
            catch { } // TODO: fix this
        }

        private void UpdateMarkerDataInUI(MarkerEventData data)
        {
            if (data.Present)
            {
                string text =
                      "Center X:  " + data.X + "#"
                    + "Center Y:  " + data.Y + "#"
                    + "DX:        " + data.DX + "#"
                    + "DY:        " + data.DY + "#"
                    + "Area:      " + data.Area + "#"
                    + "Left:      " + data.Bounds.Left + "#"
                    + "Right:     " + data.Bounds.Right + "#"
                    + "Top:       " + data.Bounds.Top + "#"
                    + "Bottom:    " + data.Bounds.Bottom + "#";

                this.textBoxMarkerData.Lines = text.Split('#');
            }
            else
                this.textBoxMarkerData.Text = "Marker not present";
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (this.tMgr.Touchless.MarkerCount == 1)
                this.tMgr.Touchless.Markers[0].Threshold = (int) this.numericUpDownThreshold.Value;
        }

        private void checkBoxHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tMgr.Touchless.MarkerCount == 1)
                this.tMgr.Touchless.Markers[0].Highlight = this.checkBoxHighlight.Checked;
        }

        private void checkBoxSmoothMarker_CheckedChanged(object sender, EventArgs e)
        {
            if(this.tMgr.Touchless.MarkerCount == 1)
                this.tMgr.Touchless.Markers[0].SmoothingEnabled = this.checkBoxSmoothMarker.Checked;
        }

    }
}
