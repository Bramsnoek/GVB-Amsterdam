namespace EyeCT4Rails
{
    partial class UCCleaningOverview
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
            this.livSchoonmaak = new System.Windows.Forms.ListView();
            this.colTram = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWerkzaamheden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDoor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblna = new System.Windows.Forms.Label();
            this.lblvoor = new System.Windows.Forms.Label();
            this.dtpvoor = new System.Windows.Forms.DateTimePicker();
            this.dtpna = new System.Windows.Forms.DateTimePicker();
            this.lblSchoonmaak = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // livSchoonmaak
            // 
            this.livSchoonmaak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livSchoonmaak.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTram,
            this.colDateTime,
            this.colWerkzaamheden,
            this.colDoor});
            this.livSchoonmaak.FullRowSelect = true;
            this.livSchoonmaak.Location = new System.Drawing.Point(3, 68);
            this.livSchoonmaak.Name = "livSchoonmaak";
            this.livSchoonmaak.Size = new System.Drawing.Size(598, 223);
            this.livSchoonmaak.TabIndex = 9;
            this.livSchoonmaak.UseCompatibleStateImageBehavior = false;
            this.livSchoonmaak.View = System.Windows.Forms.View.Details;
            this.livSchoonmaak.DoubleClick += new System.EventHandler(this.livSchoonmaak_DoubleClick);
            // 
            // colTram
            // 
            this.colTram.Tag = "Tram";
            this.colTram.Text = "Tram";
            this.colTram.Width = 175;
            // 
            // colDateTime
            // 
            this.colDateTime.Tag = "Date/Time";
            this.colDateTime.Text = "Date/Time";
            this.colDateTime.Width = 68;
            // 
            // colWerkzaamheden
            // 
            this.colWerkzaamheden.Tag = "Werkzaamheden";
            this.colWerkzaamheden.Text = "Werkzaamheden";
            this.colWerkzaamheden.Width = 244;
            // 
            // colDoor
            // 
            this.colDoor.Tag = "Door";
            this.colDoor.Text = "Door";
            this.colDoor.Width = 113;
            // 
            // lblna
            // 
            this.lblna.AutoSize = true;
            this.lblna.Location = new System.Drawing.Point(3, 44);
            this.lblna.Name = "lblna";
            this.lblna.Size = new System.Drawing.Size(28, 13);
            this.lblna.TabIndex = 8;
            this.lblna.Text = "van:";
            // 
            // lblvoor
            // 
            this.lblvoor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblvoor.AutoSize = true;
            this.lblvoor.Location = new System.Drawing.Point(401, 44);
            this.lblvoor.Name = "lblvoor";
            this.lblvoor.Size = new System.Drawing.Size(22, 13);
            this.lblvoor.TabIndex = 7;
            this.lblvoor.Text = "tot:";
            // 
            // dtpvoor
            // 
            this.dtpvoor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpvoor.Location = new System.Drawing.Point(438, 38);
            this.dtpvoor.Name = "dtpvoor";
            this.dtpvoor.Size = new System.Drawing.Size(163, 20);
            this.dtpvoor.TabIndex = 6;
            this.dtpvoor.ValueChanged += new System.EventHandler(this.dtpvoor_ValueChanged);
            // 
            // dtpna
            // 
            this.dtpna.Location = new System.Drawing.Point(31, 38);
            this.dtpna.Name = "dtpna";
            this.dtpna.Size = new System.Drawing.Size(200, 20);
            this.dtpna.TabIndex = 10;
            this.dtpna.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpna.ValueChanged += new System.EventHandler(this.dtpna_ValueChanged);
            // 
            // lblSchoonmaak
            // 
            this.lblSchoonmaak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSchoonmaak.AutoSize = true;
            this.lblSchoonmaak.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblSchoonmaak.Location = new System.Drawing.Point(168, 4);
            this.lblSchoonmaak.Name = "lblSchoonmaak";
            this.lblSchoonmaak.Size = new System.Drawing.Size(282, 31);
            this.lblSchoonmaak.TabIndex = 11;
            this.lblSchoonmaak.Text = "Schoonmaakoverzicht";
            this.lblSchoonmaak.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCCleaningOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSchoonmaak);
            this.Controls.Add(this.dtpna);
            this.Controls.Add(this.livSchoonmaak);
            this.Controls.Add(this.lblna);
            this.Controls.Add(this.lblvoor);
            this.Controls.Add(this.dtpvoor);
            this.Name = "UCCleaningOverview";
            this.Size = new System.Drawing.Size(604, 295);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView livSchoonmaak;
        private System.Windows.Forms.Label lblna;
        private System.Windows.Forms.Label lblvoor;
        private System.Windows.Forms.DateTimePicker dtpvoor;
        private System.Windows.Forms.DateTimePicker dtpna;
        private System.Windows.Forms.ColumnHeader colTram;
        private System.Windows.Forms.ColumnHeader colDateTime;
        private System.Windows.Forms.ColumnHeader colWerkzaamheden;
        private System.Windows.Forms.ColumnHeader colDoor;
        private System.Windows.Forms.Label lblSchoonmaak;
    }
}
