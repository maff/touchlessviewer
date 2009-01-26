namespace TouchlessViewer
{
    partial class MainWindow
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
            try
            {
                base.Dispose(disposing);
            }
            catch
            {

            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileChangeDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripCameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMarkerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusMarkerPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCursorPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusAreaPosition = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Black;
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 121);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(779, 395);
            this.pictureBoxImage.TabIndex = 4;
            this.pictureBoxImage.TabStop = false;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenuStrip.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(803, 24);
            this.mainMenuStrip.TabIndex = 5;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileChangeDirectoryToolStripMenuItem,
            this.fileQuitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileChangeDirectoryToolStripMenuItem
            // 
            this.fileChangeDirectoryToolStripMenuItem.Name = "fileChangeDirectoryToolStripMenuItem";
            this.fileChangeDirectoryToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.fileChangeDirectoryToolStripMenuItem.Text = "Change Directory";
            this.fileChangeDirectoryToolStripMenuItem.Click += new System.EventHandler(this.fileChangeDirectoryToolStripMenuItem_Click);
            // 
            // fileQuitToolStripMenuItem
            // 
            this.fileQuitToolStripMenuItem.Name = "fileQuitToolStripMenuItem";
            this.fileQuitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.fileQuitToolStripMenuItem.Text = "Quit";
            this.fileQuitToolStripMenuItem.Click += new System.EventHandler(this.fileQuitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // cameraSettingsToolStripMenuItem
            // 
            this.cameraSettingsToolStripMenuItem.Name = "cameraSettingsToolStripMenuItem";
            this.cameraSettingsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.cameraSettingsToolStripMenuItem.Text = "Camera";
            this.cameraSettingsToolStripMenuItem.Click += new System.EventHandler(this.cameraSettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCameraStatus,
            this.toolStripMarkerStatus,
            this.toolStripStatusMarkerPosition,
            this.toolStripStatusCursorPosition,
            this.toolStripStatusAreaPosition});
            this.statusStrip.Location = new System.Drawing.Point(0, 692);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(803, 22);
            this.statusStrip.TabIndex = 6;
            // 
            // toolStripCameraStatus
            // 
            this.toolStripCameraStatus.Name = "toolStripCameraStatus";
            this.toolStripCameraStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripMarkerStatus
            // 
            this.toolStripMarkerStatus.Name = "toolStripMarkerStatus";
            this.toolStripMarkerStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusMarkerPosition
            // 
            this.toolStripStatusMarkerPosition.Name = "toolStripStatusMarkerPosition";
            this.toolStripStatusMarkerPosition.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusCursorPosition
            // 
            this.toolStripStatusCursorPosition.Name = "toolStripStatusCursorPosition";
            this.toolStripStatusCursorPosition.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusAreaPosition
            // 
            this.toolStripStatusAreaPosition.Name = "toolStripStatusAreaPosition";
            this.toolStripStatusAreaPosition.Size = new System.Drawing.Size(0, 17);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(803, 714);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainWindow";
            this.ResizeBegin += new System.EventHandler(this.MainWindow_ResizeBegin);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileChangeDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileQuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCameraStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMarkerStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMarkerPosition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCursorPosition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAreaPosition;
    }
}

