namespace EyeCT4Rails
{
    partial class FrmAddTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddTrack));
            this.lblTrackNr = new System.Windows.Forms.Label();
            this.txtSpoorNummer = new System.Windows.Forms.TextBox();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.nudSectoren = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAantal = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.radInactive = new System.Windows.Forms.RadioButton();
            this.txtNotitie = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectoren)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrackNr
            // 
            this.lblTrackNr.AutoSize = true;
            this.lblTrackNr.Location = new System.Drawing.Point(12, 15);
            this.lblTrackNr.Name = "lblTrackNr";
            this.lblTrackNr.Size = new System.Drawing.Size(75, 13);
            this.lblTrackNr.TabIndex = 0;
            this.lblTrackNr.Text = "Spoor nummer";
            // 
            // txtSpoorNummer
            // 
            this.txtSpoorNummer.Location = new System.Drawing.Point(201, 12);
            this.txtSpoorNummer.Name = "txtSpoorNummer";
            this.txtSpoorNummer.Size = new System.Drawing.Size(283, 20);
            this.txtSpoorNummer.TabIndex = 1;
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Checked = true;
            this.radActive.Location = new System.Drawing.Point(201, 54);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(52, 17);
            this.radActive.TabIndex = 2;
            this.radActive.TabStop = true;
            this.radActive.Text = "Actief";
            this.radActive.UseVisualStyleBackColor = true;
            // 
            // nudSectoren
            // 
            this.nudSectoren.Location = new System.Drawing.Point(201, 94);
            this.nudSectoren.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudSectoren.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSectoren.Name = "nudSectoren";
            this.nudSectoren.Size = new System.Drawing.Size(283, 20);
            this.nudSectoren.TabIndex = 3;
            this.nudSectoren.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(409, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 54);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            // 
            // lblAantal
            // 
            this.lblAantal.AutoSize = true;
            this.lblAantal.Location = new System.Drawing.Point(12, 94);
            this.lblAantal.Name = "lblAantal";
            this.lblAantal.Size = new System.Drawing.Size(81, 13);
            this.lblAantal.TabIndex = 6;
            this.lblAantal.Text = "Aantal sectoren";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 132);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(42, 13);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notities";
            // 
            // radInactive
            // 
            this.radInactive.AutoSize = true;
            this.radInactive.Location = new System.Drawing.Point(342, 54);
            this.radInactive.Name = "radInactive";
            this.radInactive.Size = new System.Drawing.Size(60, 17);
            this.radInactive.TabIndex = 8;
            this.radInactive.Text = "Inactief";
            this.radInactive.UseVisualStyleBackColor = true;
            // 
            // txtNotitie
            // 
            this.txtNotitie.Location = new System.Drawing.Point(201, 132);
            this.txtNotitie.Multiline = true;
            this.txtNotitie.Name = "txtNotitie";
            this.txtNotitie.Size = new System.Drawing.Size(283, 130);
            this.txtNotitie.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(15, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAddTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(496, 299);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNotitie);
            this.Controls.Add(this.radInactive);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblAantal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudSectoren);
            this.Controls.Add(this.radActive);
            this.Controls.Add(this.txtSpoorNummer);
            this.Controls.Add(this.lblTrackNr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddTrack";
            this.Text = "GVB Trams - Spoor toevoegen";
            ((System.ComponentModel.ISupportInitialize)(this.nudSectoren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrackNr;
        private System.Windows.Forms.TextBox txtSpoorNummer;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.NumericUpDown nudSectoren;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAantal;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.RadioButton radInactive;
        private System.Windows.Forms.TextBox txtNotitie;
        private System.Windows.Forms.Button btnCancel;
	}
}