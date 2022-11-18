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
			this.DevTextboxControl = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DevTextboxControl
			// 
			this.DevTextboxControl.AcceptsReturn = true;
			this.DevTextboxControl.AcceptsTab = true;
			this.DevTextboxControl.Location = new System.Drawing.Point(72, 40);
			this.DevTextboxControl.Multiline = true;
			this.DevTextboxControl.Name = "DevTextboxControl";
			this.DevTextboxControl.Size = new System.Drawing.Size(640, 368);
			this.DevTextboxControl.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.DevTextboxControl);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox DevTextboxControl;
	}
}

