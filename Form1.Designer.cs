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
			this.NetworkTextInputControl = new System.Windows.Forms.TextBox();
			this.RunNetworkCommandButtonControl = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DevTextboxControl
			// 
			this.DevTextboxControl.AcceptsReturn = true;
			this.DevTextboxControl.AcceptsTab = true;
			this.DevTextboxControl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DevTextboxControl.Location = new System.Drawing.Point(136, 8);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.RunNetworkCommandButtonControl);
			this.Controls.Add(this.NetworkTextInputControl);
			this.Controls.Add(this.DevTextboxControl);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox DevTextboxControl;
		public System.Windows.Forms.TextBox NetworkTextInputControl;
		private System.Windows.Forms.Button RunNetworkCommandButtonControl;
	}
}

