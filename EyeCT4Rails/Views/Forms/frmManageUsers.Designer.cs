namespace EyeCT4Rails
{
    partial class FrmManageUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageUsers));
            this.colGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.livUsers = new System.Windows.Forms.ListView();
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbUsers = new System.Windows.Forms.GroupBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.grbHistory = new System.Windows.Forms.GroupBox();
            this.livHistory = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.comGroup = new System.Windows.Forms.ComboBox();
            this.grbOptions = new System.Windows.Forms.GroupBox();
            this.grbPassword = new System.Windows.Forms.GroupBox();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grbModify = new System.Windows.Forms.GroupBox();
            this.grbUsers.SuspendLayout();
            this.grbHistory.SuspendLayout();
            this.grbOptions.SuspendLayout();
            this.grbPassword.SuspendLayout();
            this.grbModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // colGroup
            // 
            this.colGroup.Text = "Groep";
            this.colGroup.Width = 102;
            // 
            // colUsername
            // 
            this.colUsername.Text = "Gebruikersnaam";
            this.colUsername.Width = 171;
            // 
            // colName
            // 
            this.colName.Text = "Naam";
            this.colName.Width = 158;
            // 
            // livUsers
            // 
            this.livUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colUsername,
            this.colEmail,
            this.colGroup});
            this.livUsers.FullRowSelect = true;
            this.livUsers.HideSelection = false;
            this.livUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.livUsers.Location = new System.Drawing.Point(8, 23);
            this.livUsers.MultiSelect = false;
            this.livUsers.Name = "livUsers";
            this.livUsers.Size = new System.Drawing.Size(659, 291);
            this.livUsers.TabIndex = 4;
            this.livUsers.UseCompatibleStateImageBehavior = false;
            this.livUsers.View = System.Windows.Forms.View.Details;
            this.livUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // colEmail
            // 
            this.colEmail.Text = "E-mail";
            this.colEmail.Width = 222;
            // 
            // grbUsers
            // 
            this.grbUsers.Controls.Add(this.livUsers);
            this.grbUsers.Location = new System.Drawing.Point(12, 12);
            this.grbUsers.Name = "grbUsers";
            this.grbUsers.Size = new System.Drawing.Size(673, 320);
            this.grbUsers.TabIndex = 20;
            this.grbUsers.TabStop = false;
            this.grbUsers.Text = "Gebruikers";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(3, 159);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 13);
            this.lblGroup.TabIndex = 14;
            this.lblGroup.Text = "Groep";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 116);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(61, 13);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "E-mailadres";
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(8, 202);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(145, 23);
            this.btnCreateUser.TabIndex = 6;
            this.btnCreateUser.Text = "Gebruiker aanmaken";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // grbHistory
            // 
            this.grbHistory.Controls.Add(this.livHistory);
            this.grbHistory.Location = new System.Drawing.Point(326, 338);
            this.grbHistory.Name = "grbHistory";
            this.grbHistory.Size = new System.Drawing.Size(359, 233);
            this.grbHistory.TabIndex = 22;
            this.grbHistory.TabStop = false;
            this.grbHistory.Text = "Inlog geschiedenis";
            // 
            // livHistory
            // 
            this.livHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate});
            this.livHistory.Location = new System.Drawing.Point(7, 23);
            this.livHistory.Name = "livHistory";
            this.livHistory.Size = new System.Drawing.Size(346, 202);
            this.livHistory.TabIndex = 5;
            this.livHistory.UseCompatibleStateImageBehavior = false;
            this.livHistory.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Datum / tijd";
            this.colDate.Width = 341;
            // 
            // txtFullName
            // 
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(6, 44);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(129, 20);
            this.txtFullName.TabIndex = 8;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Enabled = false;
            this.btnResetPassword.Location = new System.Drawing.Point(6, 124);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(129, 23);
            this.btnResetPassword.TabIndex = 12;
            this.btnResetPassword.Text = "Reset wachtwoord";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(6, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(129, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // comGroup
            // 
            this.comGroup.Enabled = false;
            this.comGroup.FormattingEnabled = true;
            this.comGroup.Location = new System.Drawing.Point(6, 175);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(129, 21);
            this.comGroup.TabIndex = 3;
            // 
            // grbOptions
            // 
            this.grbOptions.Controls.Add(this.grbPassword);
            this.grbOptions.Controls.Add(this.btnCreateUser);
            this.grbOptions.Location = new System.Drawing.Point(12, 338);
            this.grbOptions.Name = "grbOptions";
            this.grbOptions.Size = new System.Drawing.Size(157, 233);
            this.grbOptions.TabIndex = 21;
            this.grbOptions.TabStop = false;
            this.grbOptions.Text = "Opties";
            // 
            // grbPassword
            // 
            this.grbPassword.Controls.Add(this.lblRepeatPassword);
            this.grbPassword.Controls.Add(this.txtPasswordConfirm);
            this.grbPassword.Controls.Add(this.lblPassword);
            this.grbPassword.Controls.Add(this.txtPassword);
            this.grbPassword.Controls.Add(this.btnResetPassword);
            this.grbPassword.Location = new System.Drawing.Point(8, 23);
            this.grbPassword.Name = "grbPassword";
            this.grbPassword.Size = new System.Drawing.Size(143, 153);
            this.grbPassword.TabIndex = 23;
            this.grbPassword.TabStop = false;
            this.grbPassword.Text = "Verander wachtwoord";
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.AutoSize = true;
            this.lblRepeatPassword.Location = new System.Drawing.Point(6, 68);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(105, 13);
            this.lblRepeatPassword.TabIndex = 20;
            this.lblRepeatPassword.Text = "Herhaal wachtwoord";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Enabled = false;
            this.txtPasswordConfirm.Location = new System.Drawing.Point(6, 85);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(129, 20);
            this.txtPasswordConfirm.TabIndex = 19;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 23);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 13);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Wachtwoord";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(6, 40);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(129, 20);
            this.txtPassword.TabIndex = 13;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(6, 202);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(129, 23);
            this.btnEditUser.TabIndex = 17;
            this.btnEditUser.Text = "Gebruiker aanpassen";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 71);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 13);
            this.lblUsername.TabIndex = 15;
            this.lblUsername.Text = "Gebruikersnaam";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(6, 88);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(129, 20);
            this.txtUsername.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Voor- en -achternaam";
            // 
            // grbModify
            // 
            this.grbModify.Controls.Add(this.btnEditUser);
            this.grbModify.Controls.Add(this.comGroup);
            this.grbModify.Controls.Add(this.lblUsername);
            this.grbModify.Controls.Add(this.txtEmail);
            this.grbModify.Controls.Add(this.txtUsername);
            this.grbModify.Controls.Add(this.txtFullName);
            this.grbModify.Controls.Add(this.lblGroup);
            this.grbModify.Controls.Add(this.lblName);
            this.grbModify.Controls.Add(this.lblEmail);
            this.grbModify.Location = new System.Drawing.Point(175, 338);
            this.grbModify.Name = "grbModify";
            this.grbModify.Size = new System.Drawing.Size(145, 233);
            this.grbModify.TabIndex = 18;
            this.grbModify.TabStop = false;
            this.grbModify.Text = "Aanpassen";
            // 
            // FrmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(694, 578);
            this.Controls.Add(this.grbModify);
            this.Controls.Add(this.grbUsers);
            this.Controls.Add(this.grbHistory);
            this.Controls.Add(this.grbOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmManageUsers";
            this.Text = "GVB Trams - Gebruikersbeheer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmManageUsers_FormClosed);
            this.grbUsers.ResumeLayout(false);
            this.grbHistory.ResumeLayout(false);
            this.grbOptions.ResumeLayout(false);
            this.grbPassword.ResumeLayout(false);
            this.grbPassword.PerformLayout();
            this.grbModify.ResumeLayout(false);
            this.grbModify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colGroup;
        private System.Windows.Forms.ColumnHeader colUsername;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ListView livUsers;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.GroupBox grbUsers;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.GroupBox grbHistory;
        private System.Windows.Forms.ListView livHistory;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox comGroup;
        private System.Windows.Forms.GroupBox grbOptions;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.GroupBox grbPassword;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grbModify;
	}
}