namespace EyeCT4RailsPasswordGenerator
{
	partial class FrmMain
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
			this.lblPlainText = new System.Windows.Forms.Label();
			this.txtPlainText = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnConvertToPlain = new System.Windows.Forms.Button();
			this.btnConvertToPassword = new System.Windows.Forms.Button();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPlainText
			// 
			this.lblPlainText.AutoSize = true;
			this.lblPlainText.Location = new System.Drawing.Point(21, 46);
			this.lblPlainText.Name = "lblPlainText";
			this.lblPlainText.Size = new System.Drawing.Size(53, 13);
			this.lblPlainText.TabIndex = 0;
			this.lblPlainText.Text = "&Plaintext: ";
			// 
			// txtPlainText
			// 
			this.txtPlainText.Location = new System.Drawing.Point(80, 43);
			this.txtPlainText.Name = "txtPlainText";
			this.txtPlainText.Size = new System.Drawing.Size(192, 20);
			this.txtPlainText.TabIndex = 1;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(21, 76);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(56, 13);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "P&assword:";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(80, 73);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(192, 20);
			this.txtPassword.TabIndex = 3;
			// 
			// btnConvertToPlain
			// 
			this.btnConvertToPlain.Location = new System.Drawing.Point(20, 104);
			this.btnConvertToPlain.Name = "btnConvertToPlain";
			this.btnConvertToPlain.Size = new System.Drawing.Size(95, 23);
			this.btnConvertToPlain.TabIndex = 4;
			this.btnConvertToPlain.Text = "&ConvertToPlain";
			this.btnConvertToPlain.UseVisualStyleBackColor = true;
			this.btnConvertToPlain.Click += new System.EventHandler(this.btnConvertToPlain_Click);
			// 
			// btnConvertToPassword
			// 
			this.btnConvertToPassword.Location = new System.Drawing.Point(166, 104);
			this.btnConvertToPassword.Name = "btnConvertToPassword";
			this.btnConvertToPassword.Size = new System.Drawing.Size(114, 23);
			this.btnConvertToPassword.TabIndex = 5;
			this.btnConvertToPassword.Text = "C&onvertToPassword";
			this.btnConvertToPassword.UseVisualStyleBackColor = true;
			this.btnConvertToPassword.Click += new System.EventHandler(this.btnConvertToPassword_Click);
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(80, 17);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(192, 20);
			this.txtUserName.TabIndex = 7;
			this.txtUserName.Text = "User1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "&Username: ";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 137);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConvertToPassword);
			this.Controls.Add(this.btnConvertToPlain);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.txtPlainText);
			this.Controls.Add(this.lblPlainText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmMain";
			this.Text = "PasswordGenerator";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPlainText;
		private System.Windows.Forms.TextBox txtPlainText;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnConvertToPlain;
		private System.Windows.Forms.Button btnConvertToPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label1;
	}
}

