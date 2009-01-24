namespace TouchlessViewer
{
    partial class CameraSettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.groupBoxCamera = new System.Windows.Forms.GroupBox();
            this.groupBoxCamSettings = new System.Windows.Forms.GroupBox();
            this.buttonAdjustCamera = new System.Windows.Forms.Button();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.groupBoxMarker = new System.Windows.Forms.GroupBox();
            this.textBoxMarkerData = new System.Windows.Forms.TextBox();
            this.groupBoxMarkerSettings = new System.Windows.Forms.GroupBox();
            this.numericUpDownThreshold = new System.Windows.Forms.NumericUpDown();
            this.labelMarkerTreshold = new System.Windows.Forms.Label();
            this.checkBoxSmoothMarker = new System.Windows.Forms.CheckBox();
            this.checkBoxHighlight = new System.Windows.Forms.CheckBox();
            this.buttonAddMarker = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.groupBoxCamera.SuspendLayout();
            this.groupBoxCamSettings.SuspendLayout();
            this.groupBoxMarker.SuspendLayout();
            this.groupBoxMarkerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxCamera.Location = new System.Drawing.Point(338, 12);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxCamera.TabIndex = 0;
            this.pictureBoxCamera.TabStop = false;
            this.pictureBoxCamera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCamera_MouseMove);
            this.pictureBoxCamera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCamera_MouseDown);
            this.pictureBoxCamera.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCamera_MouseUp);
            // 
            // groupBoxCamera
            // 
            this.groupBoxCamera.Controls.Add(this.groupBoxCamSettings);
            this.groupBoxCamera.Controls.Add(this.comboBoxCameras);
            this.groupBoxCamera.Location = new System.Drawing.Point(13, 13);
            this.groupBoxCamera.Name = "groupBoxCamera";
            this.groupBoxCamera.Size = new System.Drawing.Size(319, 106);
            this.groupBoxCamera.TabIndex = 1;
            this.groupBoxCamera.TabStop = false;
            this.groupBoxCamera.Text = "Camera";
            // 
            // groupBoxCamSettings
            // 
            this.groupBoxCamSettings.Controls.Add(this.buttonAdjustCamera);
            this.groupBoxCamSettings.Location = new System.Drawing.Point(7, 48);
            this.groupBoxCamSettings.Name = "groupBoxCamSettings";
            this.groupBoxCamSettings.Size = new System.Drawing.Size(306, 53);
            this.groupBoxCamSettings.TabIndex = 1;
            this.groupBoxCamSettings.TabStop = false;
            this.groupBoxCamSettings.Text = "Settings";
            // 
            // buttonAdjustCamera
            // 
            this.buttonAdjustCamera.Location = new System.Drawing.Point(7, 20);
            this.buttonAdjustCamera.Name = "buttonAdjustCamera";
            this.buttonAdjustCamera.Size = new System.Drawing.Size(169, 23);
            this.buttonAdjustCamera.TabIndex = 0;
            this.buttonAdjustCamera.Text = "Adjust Camera Settings";
            this.buttonAdjustCamera.UseVisualStyleBackColor = true;
            this.buttonAdjustCamera.Click += new System.EventHandler(this.buttonAdjustCamera_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(7, 20);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(306, 21);
            this.comboBoxCameras.TabIndex = 0;
            this.comboBoxCameras.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameras_SelectedIndexChanged);
            this.comboBoxCameras.DropDown += new System.EventHandler(this.comboBoxCameras_DropDown);
            // 
            // groupBoxMarker
            // 
            this.groupBoxMarker.Controls.Add(this.textBoxMarkerData);
            this.groupBoxMarker.Controls.Add(this.groupBoxMarkerSettings);
            this.groupBoxMarker.Controls.Add(this.buttonAddMarker);
            this.groupBoxMarker.Location = new System.Drawing.Point(13, 125);
            this.groupBoxMarker.Name = "groupBoxMarker";
            this.groupBoxMarker.Size = new System.Drawing.Size(319, 338);
            this.groupBoxMarker.TabIndex = 1;
            this.groupBoxMarker.TabStop = false;
            this.groupBoxMarker.Text = "Marker";
            // 
            // textBoxMarkerData
            // 
            this.textBoxMarkerData.Location = new System.Drawing.Point(7, 128);
            this.textBoxMarkerData.Multiline = true;
            this.textBoxMarkerData.Name = "textBoxMarkerData";
            this.textBoxMarkerData.ReadOnly = true;
            this.textBoxMarkerData.Size = new System.Drawing.Size(306, 204);
            this.textBoxMarkerData.TabIndex = 2;
            // 
            // groupBoxMarkerSettings
            // 
            this.groupBoxMarkerSettings.Controls.Add(this.numericUpDownThreshold);
            this.groupBoxMarkerSettings.Controls.Add(this.labelMarkerTreshold);
            this.groupBoxMarkerSettings.Controls.Add(this.checkBoxSmoothMarker);
            this.groupBoxMarkerSettings.Controls.Add(this.checkBoxHighlight);
            this.groupBoxMarkerSettings.Enabled = false;
            this.groupBoxMarkerSettings.Location = new System.Drawing.Point(7, 50);
            this.groupBoxMarkerSettings.Name = "groupBoxMarkerSettings";
            this.groupBoxMarkerSettings.Size = new System.Drawing.Size(306, 71);
            this.groupBoxMarkerSettings.TabIndex = 1;
            this.groupBoxMarkerSettings.TabStop = false;
            this.groupBoxMarkerSettings.Text = "Settings";
            // 
            // numericUpDownThreshold
            // 
            this.numericUpDownThreshold.Location = new System.Drawing.Point(97, 42);
            this.numericUpDownThreshold.Name = "numericUpDownThreshold";
            this.numericUpDownThreshold.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownThreshold.TabIndex = 3;
            this.numericUpDownThreshold.ValueChanged += new System.EventHandler(this.numericUpDownThreshold_ValueChanged);
            // 
            // labelMarkerTreshold
            // 
            this.labelMarkerTreshold.AutoSize = true;
            this.labelMarkerTreshold.Location = new System.Drawing.Point(7, 44);
            this.labelMarkerTreshold.Name = "labelMarkerTreshold";
            this.labelMarkerTreshold.Size = new System.Drawing.Size(84, 13);
            this.labelMarkerTreshold.TabIndex = 2;
            this.labelMarkerTreshold.Text = "Marker Treshold";
            // 
            // checkBoxSmoothMarker
            // 
            this.checkBoxSmoothMarker.AutoSize = true;
            this.checkBoxSmoothMarker.Checked = true;
            this.checkBoxSmoothMarker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSmoothMarker.Location = new System.Drawing.Point(116, 19);
            this.checkBoxSmoothMarker.Name = "checkBoxSmoothMarker";
            this.checkBoxSmoothMarker.Size = new System.Drawing.Size(124, 17);
            this.checkBoxSmoothMarker.TabIndex = 0;
            this.checkBoxSmoothMarker.Text = "Smooth Marker Data";
            this.checkBoxSmoothMarker.UseVisualStyleBackColor = true;
            this.checkBoxSmoothMarker.CheckedChanged += new System.EventHandler(this.checkBoxSmoothMarker_CheckedChanged);
            // 
            // checkBoxHighlight
            // 
            this.checkBoxHighlight.AutoSize = true;
            this.checkBoxHighlight.Checked = true;
            this.checkBoxHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHighlight.Location = new System.Drawing.Point(7, 20);
            this.checkBoxHighlight.Name = "checkBoxHighlight";
            this.checkBoxHighlight.Size = new System.Drawing.Size(103, 17);
            this.checkBoxHighlight.TabIndex = 0;
            this.checkBoxHighlight.Text = "Highlight Marker";
            this.checkBoxHighlight.UseVisualStyleBackColor = true;
            this.checkBoxHighlight.CheckedChanged += new System.EventHandler(this.checkBoxHighlight_CheckedChanged);
            // 
            // buttonAddMarker
            // 
            this.buttonAddMarker.Location = new System.Drawing.Point(7, 20);
            this.buttonAddMarker.Name = "buttonAddMarker";
            this.buttonAddMarker.Size = new System.Drawing.Size(176, 23);
            this.buttonAddMarker.TabIndex = 0;
            this.buttonAddMarker.Text = "Add Marker";
            this.buttonAddMarker.UseVisualStyleBackColor = true;
            this.buttonAddMarker.Click += new System.EventHandler(this.buttonAddMarker_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(251, 469);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // CameraSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 506);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxMarker);
            this.Controls.Add(this.groupBoxCamera);
            this.Controls.Add(this.pictureBoxCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraSettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera Settings";
            this.Load += new System.EventHandler(this.CameraSettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.groupBoxCamera.ResumeLayout(false);
            this.groupBoxCamSettings.ResumeLayout(false);
            this.groupBoxMarker.ResumeLayout(false);
            this.groupBoxMarker.PerformLayout();
            this.groupBoxMarkerSettings.ResumeLayout(false);
            this.groupBoxMarkerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.GroupBox groupBoxCamera;
        private System.Windows.Forms.GroupBox groupBoxCamSettings;
        private System.Windows.Forms.Button buttonAdjustCamera;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.GroupBox groupBoxMarker;
        private System.Windows.Forms.GroupBox groupBoxMarkerSettings;
        private System.Windows.Forms.Label labelMarkerTreshold;
        private System.Windows.Forms.CheckBox checkBoxSmoothMarker;
        private System.Windows.Forms.CheckBox checkBoxHighlight;
        private System.Windows.Forms.Button buttonAddMarker;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxMarkerData;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshold;
    }
}