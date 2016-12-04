namespace EyeCT4Rails
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.picGVBLogo = new System.Windows.Forms.PictureBox();
            this.lblGebruikersnaam = new System.Windows.Forms.Label();
            this.lblWachtwoord = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtIPAdres = new System.Windows.Forms.TextBox();
            this.lblIPAdres = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGVBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picGVBLogo
            // 
            this.picGVBLogo.Image = global::EyeCT4Rails.Properties.Resources.GVBwagenpark_logo;
            this.picGVBLogo.Location = new System.Drawing.Point(31, 12);
            this.picGVBLogo.Name = "picGVBLogo";
            this.picGVBLogo.Size = new System.Drawing.Size(231, 75);
            this.picGVBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGVBLogo.TabIndex = 6;
            this.picGVBLogo.TabStop = false;
            // 
            // lblGebruikersnaam
            // 
            this.lblGebruikersnaam.AutoSize = true;
            this.lblGebruikersnaam.Location = new System.Drawing.Point(18, 138);
            this.lblGebruikersnaam.Name = "lblGebruikersnaam";
            this.lblGebruikersnaam.Size = new System.Drawing.Size(87, 13);
            this.lblGebruikersnaam.TabIndex = 7;
            this.lblGebruikersnaam.Text = "Gebruikersnaam:";
            // 
            // lblWachtwoord
            // 
            this.lblWachtwoord.AutoSize = true;
            this.lblWachtwoord.Location = new System.Drawing.Point(18, 164);
            this.lblWachtwoord.Name = "lblWachtwoord";
            this.lblWachtwoord.Size = new System.Drawing.Size(71, 13);
            this.lblWachtwoord.TabIndex = 8;
            this.lblWachtwoord.Text = "Wachtwoord:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(206, 198);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(111, 135);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(170, 20);
            this.txtUsername.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(21, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Afsluiten";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(111, 161);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(170, 20);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtIPAdres
            // 
            this.txtIPAdres.Location = new System.Drawing.Point(111, 109);
            this.txtIPAdres.Name = "txtIPAdres";
            this.txtIPAdres.Size = new System.Drawing.Size(170, 20);
            this.txtIPAdres.TabIndex = 13;
            this.txtIPAdres.Text = "192.168.20.7";
            // 
            // lblIPAdres
            // 
            this.lblIPAdres.AutoSize = true;
            this.lblIPAdres.Location = new System.Drawing.Point(18, 112);
            this.lblIPAdres.Name = "lblIPAdres";
            this.lblIPAdres.Size = new System.Drawing.Size(44, 13);
            this.lblIPAdres.TabIndex = 14;
            this.lblIPAdres.Text = "IPAdres";
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(293, 243);
            this.Controls.Add(this.lblIPAdres);
            this.Controls.Add(this.txtIPAdres);
            this.Controls.Add(this.lblGebruikersnaam);
            this.Controls.Add(this.lblWachtwoord);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.picGVBLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "GVB Trams - Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGVBLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picGVBLogo;
        private System.Windows.Forms.Label lblGebruikersnaam;
        private System.Windows.Forms.Label lblWachtwoord;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtIPAdres;
        private System.Windows.Forms.Label lblIPAdres;

	}
}