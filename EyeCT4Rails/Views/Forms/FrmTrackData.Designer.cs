namespace EyeCT4Rails
{
    partial class FrmTrackData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrackData));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.grbTrack = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.radClear = new System.Windows.Forms.RadioButton();
            this.radBlocked = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTrack = new System.Windows.Forms.Label();
            this.grbTrack.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(18, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(353, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 28);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(40, 174);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(390, 87);
            this.txtNote.TabIndex = 14;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            // 
            // grbTrack
            // 
            this.grbTrack.Controls.Add(this.lblNote);
            this.grbTrack.Controls.Add(this.radClear);
            this.grbTrack.Controls.Add(this.radBlocked);
            this.grbTrack.Controls.Add(this.lblStatus);
            this.grbTrack.Location = new System.Drawing.Point(18, 56);
            this.grbTrack.Name = "grbTrack";
            this.grbTrack.Size = new System.Drawing.Size(432, 224);
            this.grbTrack.TabIndex = 13;
            this.grbTrack.TabStop = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(19, 102);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(61, 13);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "Opmerking:";
            // 
            // radClear
            // 
            this.radClear.AutoSize = true;
            this.radClear.Checked = true;
            this.radClear.Location = new System.Drawing.Point(86, 39);
            this.radClear.Name = "radClear";
            this.radClear.Size = new System.Drawing.Size(39, 17);
            this.radClear.TabIndex = 2;
            this.radClear.TabStop = true;
            this.radClear.Text = "Vrij";
            this.radClear.UseVisualStyleBackColor = true;
            this.radClear.CheckedChanged += new System.EventHandler(this.radClear_CheckedChanged);
            // 
            // radBlocked
            // 
            this.radBlocked.AutoSize = true;
            this.radBlocked.Location = new System.Drawing.Point(86, 62);
            this.radBlocked.Name = "radBlocked";
            this.radBlocked.Size = new System.Drawing.Size(86, 17);
            this.radBlocked.TabIndex = 3;
            this.radBlocked.Text = "Geblokkeerd";
            this.radBlocked.UseVisualStyleBackColor = true;
            this.radBlocked.CheckedChanged += new System.EventHandler(this.radBlocked_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(19, 39);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // lblTrack
            // 
            this.lblTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrack.Location = new System.Drawing.Point(18, 18);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(432, 24);
            this.lblTrack.TabIndex = 18;
            this.lblTrack.Text = "Spoor: XX";
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTrackData
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 325);
            this.Controls.Add(this.lblTrack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.grbTrack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTrackData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GVB Trams - Spoorgegevens";
            this.grbTrack.ResumeLayout(false);
            this.grbTrack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.GroupBox grbTrack;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.RadioButton radClear;
        private System.Windows.Forms.RadioButton radBlocked;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTrack;
	}
}