namespace EyeCT4Rails
{
	partial class FrmNewActivity
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewActivity));
			this.lblWorkNote = new System.Windows.Forms.Label();
			this.txtWorkNote = new System.Windows.Forms.TextBox();
			this.chkPeriodicTask = new System.Windows.Forms.CheckBox();
			this.btnAnnuleer = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.comPlannedFor = new System.Windows.Forms.ComboBox();
			this.lblPlannedFor = new System.Windows.Forms.Label();
			this.grbPeriodicTask = new System.Windows.Forms.GroupBox();
			this.comPeriod = new System.Windows.Forms.ComboBox();
			this.txtPeriodNumber = new System.Windows.Forms.TextBox();
			this.lblPeriodEvery = new System.Windows.Forms.Label();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.lblRemark = new System.Windows.Forms.Label();
			this.grbPeriodicTask.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblWorkNote
			// 
			this.lblWorkNote.AutoSize = true;
			this.lblWorkNote.Location = new System.Drawing.Point(13, 15);
			this.lblWorkNote.Name = "lblWorkNote";
			this.lblWorkNote.Size = new System.Drawing.Size(91, 13);
			this.lblWorkNote.TabIndex = 2;
			this.lblWorkNote.Text = "Werkzaamheden:";
			// 
			// txtWorkNote
			// 
			this.txtWorkNote.Location = new System.Drawing.Point(116, 12);
			this.txtWorkNote.Name = "txtWorkNote";
			this.txtWorkNote.Size = new System.Drawing.Size(200, 20);
			this.txtWorkNote.TabIndex = 3;
			// 
			// chkPeriodicTask
			// 
			this.chkPeriodicTask.AutoSize = true;
			this.chkPeriodicTask.Location = new System.Drawing.Point(13, 130);
			this.chkPeriodicTask.Name = "chkPeriodicTask";
			this.chkPeriodicTask.Size = new System.Drawing.Size(134, 17);
			this.chkPeriodicTask.TabIndex = 5;
			this.chkPeriodicTask.Text = "Activeer terugkerende ";
			this.chkPeriodicTask.UseVisualStyleBackColor = true;
			this.chkPeriodicTask.CheckedChanged += new System.EventHandler(this.chkPeriodicTask_CheckedChanged);
			// 
			// btnAnnuleer
			// 
			this.btnAnnuleer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnuleer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnuleer.Location = new System.Drawing.Point(9, 222);
			this.btnAnnuleer.Name = "btnAnnuleer";
			this.btnAnnuleer.Size = new System.Drawing.Size(75, 23);
			this.btnAnnuleer.TabIndex = 6;
			this.btnAnnuleer.Text = "Annuleer";
			this.btnAnnuleer.UseVisualStyleBackColor = true;
			this.btnAnnuleer.Click += new System.EventHandler(this.btnAnnuleer_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(241, 222);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Opslaan";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// comPlannedFor
			// 
			this.comPlannedFor.FormattingEnabled = true;
			this.comPlannedFor.Location = new System.Drawing.Point(116, 38);
			this.comPlannedFor.Name = "comPlannedFor";
			this.comPlannedFor.Size = new System.Drawing.Size(200, 21);
			this.comPlannedFor.TabIndex = 8;
			// 
			// lblPlannedFor
			// 
			this.lblPlannedFor.AutoSize = true;
			this.lblPlannedFor.Location = new System.Drawing.Point(13, 41);
			this.lblPlannedFor.Name = "lblPlannedFor";
			this.lblPlannedFor.Size = new System.Drawing.Size(74, 13);
			this.lblPlannedFor.TabIndex = 9;
			this.lblPlannedFor.Text = "Gepland voor:";
			// 
			// grbPeriodicTask
			// 
			this.grbPeriodicTask.Controls.Add(this.comPeriod);
			this.grbPeriodicTask.Controls.Add(this.txtPeriodNumber);
			this.grbPeriodicTask.Controls.Add(this.lblPeriodEvery);
			this.grbPeriodicTask.Enabled = false;
			this.grbPeriodicTask.Location = new System.Drawing.Point(13, 153);
			this.grbPeriodicTask.Name = "grbPeriodicTask";
			this.grbPeriodicTask.Size = new System.Drawing.Size(300, 61);
			this.grbPeriodicTask.TabIndex = 10;
			this.grbPeriodicTask.TabStop = false;
			this.grbPeriodicTask.Text = "Terugkerende ";
			// 
			// comPeriod
			// 
			this.comPeriod.FormattingEnabled = true;
			this.comPeriod.Location = new System.Drawing.Point(178, 23);
			this.comPeriod.Name = "comPeriod";
			this.comPeriod.Size = new System.Drawing.Size(94, 21);
			this.comPeriod.TabIndex = 11;
			// 
			// txtPeriodNumber
			// 
			this.txtPeriodNumber.Location = new System.Drawing.Point(100, 23);
			this.txtPeriodNumber.Name = "txtPeriodNumber";
			this.txtPeriodNumber.Size = new System.Drawing.Size(72, 20);
			this.txtPeriodNumber.TabIndex = 11;
			// 
			// lblPeriodEvery
			// 
			this.lblPeriodEvery.AutoSize = true;
			this.lblPeriodEvery.Location = new System.Drawing.Point(16, 26);
			this.lblPeriodEvery.Name = "lblPeriodEvery";
			this.lblPeriodEvery.Size = new System.Drawing.Size(69, 13);
			this.lblPeriodEvery.TabIndex = 11;
			this.lblPeriodEvery.Text = "Periode elke:";
			// 
			// txtRemark
			// 
			this.txtRemark.Location = new System.Drawing.Point(16, 83);
			this.txtRemark.Multiline = true;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(300, 41);
			this.txtRemark.TabIndex = 11;
			// 
			// lblRemark
			// 
			this.lblRemark.AutoSize = true;
			this.lblRemark.Location = new System.Drawing.Point(13, 67);
			this.lblRemark.Name = "lblRemark";
			this.lblRemark.Size = new System.Drawing.Size(40, 13);
			this.lblRemark.TabIndex = 12;
			this.lblRemark.Text = "Notitie:";
			// 
			// FrmNewActivity
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAnnuleer;
			this.ClientSize = new System.Drawing.Size(328, 257);
			this.Controls.Add(this.lblRemark);
			this.Controls.Add(this.txtRemark);
			this.Controls.Add(this.grbPeriodicTask);
			this.Controls.Add(this.lblPlannedFor);
			this.Controls.Add(this.comPlannedFor);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnAnnuleer);
			this.Controls.Add(this.chkPeriodicTask);
			this.Controls.Add(this.txtWorkNote);
			this.Controls.Add(this.lblWorkNote);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmNewActivity";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GVB Trams - Nieuwe ";
			this.Load += new System.EventHandler(this.FrmNewActivity_Load);
			this.grbPeriodicTask.ResumeLayout(false);
			this.grbPeriodicTask.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblWorkNote;
		private System.Windows.Forms.TextBox txtWorkNote;
		private System.Windows.Forms.CheckBox chkPeriodicTask;
		private System.Windows.Forms.Button btnAnnuleer;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ComboBox comPlannedFor;
		private System.Windows.Forms.Label lblPlannedFor;
		private System.Windows.Forms.GroupBox grbPeriodicTask;
		private System.Windows.Forms.ComboBox comPeriod;
		private System.Windows.Forms.TextBox txtPeriodNumber;
		private System.Windows.Forms.Label lblPeriodEvery;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label lblRemark;
	}
}