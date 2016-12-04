namespace EyeCT4Rails
{
    partial class UCRepairOverview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpvoor = new System.Windows.Forms.DateTimePicker();
            this.dtpna = new System.Windows.Forms.DateTimePicker();
            this.lblvoor = new System.Windows.Forms.Label();
            this.lblna = new System.Windows.Forms.Label();
            this.livReparatie = new System.Windows.Forms.ListView();
            this.colTram = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatumTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colwerkzaamheden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDoor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelReparatie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpvoor
            // 
            this.dtpvoor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpvoor.Location = new System.Drawing.Point(438, 38);
            this.dtpvoor.Name = "dtpvoor";
            this.dtpvoor.Size = new System.Drawing.Size(163, 20);
            this.dtpvoor.TabIndex = 1;
            this.dtpvoor.ValueChanged += new System.EventHandler(this.dtpvoor_ValueChanged);
            // 
            // dtpna
            // 
            this.dtpna.Location = new System.Drawing.Point(32, 38);
            this.dtpna.Name = "dtpna";
            this.dtpna.Size = new System.Drawing.Size(200, 20);
            this.dtpna.TabIndex = 2;
            this.dtpna.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpna.ValueChanged += new System.EventHandler(this.dtpna_ValueChanged);
            // 
            // lblvoor
            // 
            this.lblvoor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblvoor.AutoSize = true;
            this.lblvoor.Location = new System.Drawing.Point(401, 44);
            this.lblvoor.Name = "lblvoor";
            this.lblvoor.Size = new System.Drawing.Size(22, 13);
            this.lblvoor.TabIndex = 3;
            this.lblvoor.Text = "tot:";
            // 
            // lblna
            // 
            this.lblna.AutoSize = true;
            this.lblna.Location = new System.Drawing.Point(4, 44);
            this.lblna.Name = "lblna";
            this.lblna.Size = new System.Drawing.Size(28, 13);
            this.lblna.TabIndex = 4;
            this.lblna.Text = "van:";
            // 
            // livReparatie
            // 
            this.livReparatie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livReparatie.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTram,
            this.colDatumTime,
            this.colwerkzaamheden,
            this.colDoor});
            this.livReparatie.FullRowSelect = true;
            this.livReparatie.Location = new System.Drawing.Point(3, 69);
            this.livReparatie.Name = "livReparatie";
            this.livReparatie.Size = new System.Drawing.Size(598, 223);
            this.livReparatie.TabIndex = 5;
            this.livReparatie.UseCompatibleStateImageBehavior = false;
            this.livReparatie.View = System.Windows.Forms.View.Details;
            this.livReparatie.DoubleClick += new System.EventHandler(this.livReparatie_DoubleClick);
            // 
            // colTram
            // 
            this.colTram.Tag = "Tram";
            this.colTram.Text = "Tram";
            this.colTram.Width = 171;
            // 
            // colDatumTime
            // 
            this.colDatumTime.Tag = "Datum/Tijd";
            this.colDatumTime.Text = "Date/Time";
            this.colDatumTime.Width = 133;
            // 
            // colwerkzaamheden
            // 
            this.colwerkzaamheden.Tag = "Werkzaamheden";
            this.colwerkzaamheden.Text = "Werkzaamheden";
            this.colwerkzaamheden.Width = 193;
            // 
            // colDoor
            // 
            this.colDoor.Tag = "Door";
            this.colDoor.Text = "Door";
            this.colDoor.Width = 97;
            // 
            // labelReparatie
            // 
            this.labelReparatie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelReparatie.AutoSize = true;
            this.labelReparatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelReparatie.Location = new System.Drawing.Point(176, 4);
            this.labelReparatie.Name = "labelReparatie";
            this.labelReparatie.Size = new System.Drawing.Size(242, 31);
            this.labelReparatie.TabIndex = 6;
            this.labelReparatie.Text = "Reparatieoverzicht";
            this.labelReparatie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCRepairOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelReparatie);
            this.Controls.Add(this.livReparatie);
            this.Controls.Add(this.lblna);
            this.Controls.Add(this.lblvoor);
            this.Controls.Add(this.dtpna);
            this.Controls.Add(this.dtpvoor);
            this.Name = "UCRepairOverview";
            this.Size = new System.Drawing.Size(604, 295);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpvoor;
        private System.Windows.Forms.DateTimePicker dtpna;
        private System.Windows.Forms.Label lblvoor;
        private System.Windows.Forms.Label lblna;
        private System.Windows.Forms.ListView livReparatie;
        private System.Windows.Forms.ColumnHeader colTram;
        private System.Windows.Forms.ColumnHeader colDatumTime;
        private System.Windows.Forms.ColumnHeader colwerkzaamheden;
        private System.Windows.Forms.ColumnHeader colDoor;
        private System.Windows.Forms.Label labelReparatie;
    }
}
