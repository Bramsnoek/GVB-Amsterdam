namespace EyeCT4Rails
{
    partial class FrmCreateUser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateUser));
			this.btnSave = new System.Windows.Forms.Button();
			this.lblGroup = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPass = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.lblUser = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.lblLast = new System.Windows.Forms.Label();
			this.comGroup = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.lblFirst = new System.Windows.Forms.Label();
			this.txtPasswordRepeat = new System.Windows.Forms.TextBox();
			this.lblPassRepeat = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(336, 273);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Opslaan";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblGroup
			// 
			this.lblGroup.AutoSize = true;
			this.lblGroup.Location = new System.Drawing.Point(12, 232);
			this.lblGroup.Name = "lblGroup";
			this.lblGroup.Size = new System.Drawing.Size(39, 13);
			this.lblGroup.TabIndex = 27;
			this.lblGroup.Text = "Groep:";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(123, 194);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(278, 20);
			this.txtEmail.TabIndex = 6;
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(12, 197);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(64, 13);
			this.lblEmail.TabIndex = 25;
			this.lblEmail.Text = "E-mailadres:";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(123, 121);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(278, 20);
			this.txtPassword.TabIndex = 4;
			// 
			// lblPass
			// 
			this.lblPass.AutoSize = true;
			this.lblPass.Location = new System.Drawing.Point(12, 124);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new System.Drawing.Size(71, 13);
			this.lblPass.TabIndex = 23;
			this.lblPass.Text = "Wachtwoord:";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(123, 85);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(278, 20);
			this.txtUsername.TabIndex = 3;
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Location = new System.Drawing.Point(12, 88);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(87, 13);
			this.lblUser.TabIndex = 21;
			this.lblUser.Text = "Gebruikersnaam:";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(123, 50);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(278, 20);
			this.txtLastName.TabIndex = 2;
			// 
			// lblLast
			// 
			this.lblLast.AutoSize = true;
			this.lblLast.Location = new System.Drawing.Point(12, 53);
			this.lblLast.Name = "lblLast";
			this.lblLast.Size = new System.Drawing.Size(67, 13);
			this.lblLast.TabIndex = 19;
			this.lblLast.Text = "Achternaam:";
			// 
			// comGroup
			// 
			this.comGroup.FormattingEnabled = true;
			this.comGroup.Location = new System.Drawing.Point(123, 229);
			this.comGroup.Name = "comGroup";
			this.comGroup.Size = new System.Drawing.Size(278, 21);
			this.comGroup.TabIndex = 7;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(15, 273);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Annuleren";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(123, 15);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(278, 20);
			this.txtFirstName.TabIndex = 1;
			// 
			// lblFirst
			// 
			this.lblFirst.AutoSize = true;
			this.lblFirst.Location = new System.Drawing.Point(12, 18);
			this.lblFirst.Name = "lblFirst";
			this.lblFirst.Size = new System.Drawing.Size(58, 13);
			this.lblFirst.TabIndex = 15;
			this.lblFirst.Text = "Voornaam:";
			// 
			// txtPasswordRepeat
			// 
			this.txtPasswordRepeat.Location = new System.Drawing.Point(123, 159);
			this.txtPasswordRepeat.Name = "txtPasswordRepeat";
			this.txtPasswordRepeat.PasswordChar = '*';
			this.txtPasswordRepeat.Size = new System.Drawing.Size(278, 20);
			this.txtPasswordRepeat.TabIndex = 5;
			// 
			// lblPassRepeat
			// 
			this.lblPassRepeat.AutoSize = true;
			this.lblPassRepeat.Location = new System.Drawing.Point(12, 162);
			this.lblPassRepeat.Name = "lblPassRepeat";
			this.lblPassRepeat.Size = new System.Drawing.Size(108, 13);
			this.lblPassRepeat.TabIndex = 29;
			this.lblPassRepeat.Text = "Herhaal wachtwoord:";
			// 
			// FrmCreateUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 308);
			this.Controls.Add(this.txtPasswordRepeat);
			this.Controls.Add(this.lblPassRepeat);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblGroup);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.lblPass);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.txtLastName);
			this.Controls.Add(this.lblLast);
			this.Controls.Add(this.comGroup);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtFirstName);
			this.Controls.Add(this.lblFirst);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmCreateUser";
			this.Text = "GVB Trams - Nieuwe gebruiker toevoegen";
			this.Load += new System.EventHandler(this.FrmCreateUser_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.ComboBox comGroup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.TextBox txtPasswordRepeat;
        private System.Windows.Forms.Label lblPassRepeat;
	}
}