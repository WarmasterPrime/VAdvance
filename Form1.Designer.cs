namespace VAdvance
{
	partial class Form1
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
			if(disposing && (components != null))
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.DevTextboxControl = new System.Windows.Forms.TextBox();
			this.NetworkTextInputControl = new System.Windows.Forms.TextBox();
			this.RunNetworkCommandButtonControl = new System.Windows.Forms.Button();
			this.ImageControl = new System.Windows.Forms.PictureBox();
			this.AudioPlayerControl = new AxWMPLib.AxWindowsMediaPlayer();
			this.ScanImageBtnControl = new System.Windows.Forms.Button();
			this.ImageUploadBtnControl = new System.Windows.Forms.Button();
			this.folderBrowserDialogControl = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialogControl = new System.Windows.Forms.OpenFileDialog();
			this.ImageListControl = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.SectorSizeInputControl = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.ColorThresholdInputControl = new System.Windows.Forms.NumericUpDown();
			this.AdvOutChkControl = new System.Windows.Forms.CheckBox();
			this.labelControl_DebugLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ImageControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AudioPlayerControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SectorSizeInputControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorThresholdInputControl)).BeginInit();
			this.SuspendLayout();
			// 
			// DevTextboxControl
			// 
			this.DevTextboxControl.AcceptsReturn = true;
			this.DevTextboxControl.AcceptsTab = true;
			this.DevTextboxControl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DevTextboxControl.Location = new System.Drawing.Point(456, 0);
			this.DevTextboxControl.Multiline = true;
			this.DevTextboxControl.Name = "DevTextboxControl";
			this.DevTextboxControl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DevTextboxControl.Size = new System.Drawing.Size(648, 424);
			this.DevTextboxControl.TabIndex = 0;
			// 
			// NetworkTextInputControl
			// 
			this.NetworkTextInputControl.Location = new System.Drawing.Point(0, 0);
			this.NetworkTextInputControl.Multiline = true;
			this.NetworkTextInputControl.Name = "NetworkTextInputControl";
			this.NetworkTextInputControl.Size = new System.Drawing.Size(112, 168);
			this.NetworkTextInputControl.TabIndex = 1;
			this.NetworkTextInputControl.Text = "Get /";
			// 
			// RunNetworkCommandButtonControl
			// 
			this.RunNetworkCommandButtonControl.Location = new System.Drawing.Point(16, 176);
			this.RunNetworkCommandButtonControl.Name = "RunNetworkCommandButtonControl";
			this.RunNetworkCommandButtonControl.Size = new System.Drawing.Size(75, 23);
			this.RunNetworkCommandButtonControl.TabIndex = 2;
			this.RunNetworkCommandButtonControl.Text = "Execute";
			this.RunNetworkCommandButtonControl.UseVisualStyleBackColor = true;
			this.RunNetworkCommandButtonControl.Click += new System.EventHandler(this.RunNetworkCommandButtonControl_OnClick);
			// 
			// ImageControl
			// 
			this.ImageControl.BackColor = System.Drawing.Color.Transparent;
			this.ImageControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ImageControl.Image = ((System.Drawing.Image)(resources.GetObject("ImageControl.Image")));
			this.ImageControl.Location = new System.Drawing.Point(456, 0);
			this.ImageControl.Name = "ImageControl";
			this.ImageControl.Size = new System.Drawing.Size(600, 424);
			this.ImageControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ImageControl.TabIndex = 3;
			this.ImageControl.TabStop = false;
			this.ImageControl.Visible = false;
			// 
			// AudioPlayerControl
			// 
			this.AudioPlayerControl.Enabled = true;
			this.AudioPlayerControl.Location = new System.Drawing.Point(8, 416);
			this.AudioPlayerControl.Name = "AudioPlayerControl";
			this.AudioPlayerControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AudioPlayerControl.OcxState")));
			this.AudioPlayerControl.Size = new System.Drawing.Size(240, 79);
			this.AudioPlayerControl.TabIndex = 4;
			this.AudioPlayerControl.Visible = false;
			// 
			// ScanImageBtnControl
			// 
			this.ScanImageBtnControl.Location = new System.Drawing.Point(16, 336);
			this.ScanImageBtnControl.Name = "ScanImageBtnControl";
			this.ScanImageBtnControl.Size = new System.Drawing.Size(75, 23);
			this.ScanImageBtnControl.TabIndex = 5;
			this.ScanImageBtnControl.Text = "Scan Image";
			this.ScanImageBtnControl.UseVisualStyleBackColor = true;
			this.ScanImageBtnControl.Click += new System.EventHandler(this.ScanImageBtnControl_Click);
			// 
			// ImageUploadBtnControl
			// 
			this.ImageUploadBtnControl.Location = new System.Drawing.Point(16, 304);
			this.ImageUploadBtnControl.Name = "ImageUploadBtnControl";
			this.ImageUploadBtnControl.Size = new System.Drawing.Size(75, 23);
			this.ImageUploadBtnControl.TabIndex = 6;
			this.ImageUploadBtnControl.Text = "Upload Image";
			this.ImageUploadBtnControl.UseVisualStyleBackColor = true;
			this.ImageUploadBtnControl.Click += new System.EventHandler(this.ImageUploadBtnControl_Click);
			// 
			// openFileDialogControl
			// 
			this.openFileDialogControl.FileName = "openFileDialogControl";
			// 
			// ImageListControl
			// 
			this.ImageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListControl.ImageStream")));
			this.ImageListControl.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageListControl.Images.SetKeyName(0, "Missing.png");
			this.ImageListControl.Images.SetKeyName(1, "Processing.png");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 20);
			this.label1.TabIndex = 8;
			this.label1.Text = "Sector Size:";
			// 
			// SectorSizeInputControl
			// 
			this.SectorSizeInputControl.Location = new System.Drawing.Point(104, 224);
			this.SectorSizeInputControl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.SectorSizeInputControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SectorSizeInputControl.Name = "SectorSizeInputControl";
			this.SectorSizeInputControl.Size = new System.Drawing.Size(64, 20);
			this.SectorSizeInputControl.TabIndex = 9;
			this.SectorSizeInputControl.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 20);
			this.label2.TabIndex = 10;
			this.label2.Text = "Threshold:";
			// 
			// ColorThresholdInputControl
			// 
			this.ColorThresholdInputControl.Location = new System.Drawing.Point(104, 256);
			this.ColorThresholdInputControl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.ColorThresholdInputControl.Name = "ColorThresholdInputControl";
			this.ColorThresholdInputControl.Size = new System.Drawing.Size(64, 20);
			this.ColorThresholdInputControl.TabIndex = 11;
			this.ColorThresholdInputControl.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// AdvOutChkControl
			// 
			this.AdvOutChkControl.AutoSize = true;
			this.AdvOutChkControl.Location = new System.Drawing.Point(16, 280);
			this.AdvOutChkControl.Name = "AdvOutChkControl";
			this.AdvOutChkControl.Size = new System.Drawing.Size(119, 17);
			this.AdvOutChkControl.TabIndex = 12;
			this.AdvOutChkControl.Text = "Advanced Outlining";
			this.AdvOutChkControl.UseVisualStyleBackColor = true;
			// 
			// labelControl_DebugLabel
			// 
			this.labelControl_DebugLabel.AutoSize = true;
			this.labelControl_DebugLabel.Location = new System.Drawing.Point(496, 440);
			this.labelControl_DebugLabel.Name = "labelControl_DebugLabel";
			this.labelControl_DebugLabel.Size = new System.Drawing.Size(35, 13);
			this.labelControl_DebugLabel.TabIndex = 13;
			this.labelControl_DebugLabel.Text = "label3";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1102, 498);
			this.Controls.Add(this.labelControl_DebugLabel);
			this.Controls.Add(this.AdvOutChkControl);
			this.Controls.Add(this.ColorThresholdInputControl);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SectorSizeInputControl);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ImageUploadBtnControl);
			this.Controls.Add(this.ScanImageBtnControl);
			this.Controls.Add(this.AudioPlayerControl);
			this.Controls.Add(this.ImageControl);
			this.Controls.Add(this.RunNetworkCommandButtonControl);
			this.Controls.Add(this.NetworkTextInputControl);
			this.Controls.Add(this.DevTextboxControl);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.ImageControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AudioPlayerControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SectorSizeInputControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorThresholdInputControl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox DevTextboxControl;
		public System.Windows.Forms.TextBox NetworkTextInputControl;
		private System.Windows.Forms.Button RunNetworkCommandButtonControl;
		public AxWMPLib.AxWindowsMediaPlayer AudioPlayerControl;
		private System.Windows.Forms.Button ScanImageBtnControl;
		private System.Windows.Forms.Button ImageUploadBtnControl;
		public System.Windows.Forms.FolderBrowserDialog folderBrowserDialogControl;
		private System.Windows.Forms.OpenFileDialog openFileDialogControl;
		public System.Windows.Forms.PictureBox ImageControl;
		private System.Windows.Forms.ImageList ImageListControl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown SectorSizeInputControl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown ColorThresholdInputControl;
		private System.Windows.Forms.CheckBox AdvOutChkControl;
		private System.Windows.Forms.Label labelControl_DebugLabel;
	}
}

