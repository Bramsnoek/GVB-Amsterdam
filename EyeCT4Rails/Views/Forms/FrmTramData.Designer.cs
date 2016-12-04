namespace EyeCT4Rails
{
	partial class FrmTramData
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTramData));
			this.lblTramTrackInfo = new System.Windows.Forms.Label();
			this.tclTramData = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.grbTramState = new System.Windows.Forms.GroupBox();
			this.chkReparationState = new System.Windows.Forms.CheckBox();
			this.chkCleanState = new System.Windows.Forms.CheckBox();
			this.txtNote = new System.Windows.Forms.TextBox();
			this.lblRemark = new System.Windows.Forms.Label();
			this.tpCleaning = new System.Windows.Forms.TabPage();
			this.lblFilter = new System.Windows.Forms.Label();
			this.comFilterClean = new System.Windows.Forms.ComboBox();
			this.dgvCleaning = new System.Windows.Forms.DataGridView();
			this.chDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chWorkDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chPerformed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chPlannedFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnPlanCleaning = new System.Windows.Forms.Button();
			this.tpMaintenance = new System.Windows.Forms.TabPage();
			this.lblFilterRep = new System.Windows.Forms.Label();
			this.comFilterReparation = new System.Windows.Forms.ComboBox();
			this.dgvReparation = new System.Windows.Forms.DataGridView();
			this.btnPlanMaintenance = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.chDateTimeRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chWorkNoteRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chPerformedRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chPlannedForRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chNoteRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tclTramData.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.grbTramState.SuspendLayout();
			this.tpCleaning.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCleaning)).BeginInit();
			this.tpMaintenance.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReparation)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTramTrackInfo
			// 
			this.lblTramTrackInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTramTrackInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTramTrackInfo.Location = new System.Drawing.Point(8, 9);
			this.lblTramTrackInfo.Name = "lblTramTrackInfo";
			this.lblTramTrackInfo.Size = new System.Drawing.Size(596, 24);
			this.lblTramTrackInfo.TabIndex = 0;
			this.lblTramTrackInfo.Text = "Tram: XXXX - Spoor: XX";
			this.lblTramTrackInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tclTramData
			// 
			this.tclTramData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tclTramData.Controls.Add(this.tpGeneral);
			this.tclTramData.Controls.Add(this.tpCleaning);
			this.tclTramData.Controls.Add(this.tpMaintenance);
			this.tclTramData.Location = new System.Drawing.Point(12, 51);
			this.tclTramData.Name = "tclTramData";
			this.tclTramData.SelectedIndex = 0;
			this.tclTramData.Size = new System.Drawing.Size(592, 433);
			this.tclTramData.TabIndex = 1;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.grbTramState);
			this.tpGeneral.Controls.Add(this.txtNote);
			this.tpGeneral.Controls.Add(this.lblRemark);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(584, 407);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "Algemeen";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// grbTramState
			// 
			this.grbTramState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbTramState.Controls.Add(this.chkReparationState);
			this.grbTramState.Controls.Add(this.chkCleanState);
			this.grbTramState.Location = new System.Drawing.Point(9, 6);
			this.grbTramState.Name = "grbTramState";
			this.grbTramState.Size = new System.Drawing.Size(569, 42);
			this.grbTramState.TabIndex = 2;
			this.grbTramState.TabStop = false;
			this.grbTramState.Text = "Tramstatus";
			// 
			// chkReparationState
			// 
			this.chkReparationState.AutoSize = true;
			this.chkReparationState.Location = new System.Drawing.Point(107, 19);
			this.chkReparationState.Name = "chkReparationState";
			this.chkReparationState.Size = new System.Drawing.Size(76, 17);
			this.chkReparationState.TabIndex = 1;
			this.chkReparationState.Text = "Repareren";
			this.chkReparationState.UseVisualStyleBackColor = true;
			this.chkReparationState.CheckedChanged += new System.EventHandler(this.chkReparationState_CheckedChanged);
			// 
			// chkCleanState
			// 
			this.chkCleanState.AutoSize = true;
			this.chkCleanState.Location = new System.Drawing.Point(6, 19);
			this.chkCleanState.Name = "chkCleanState";
			this.chkCleanState.Size = new System.Drawing.Size(95, 17);
			this.chkCleanState.TabIndex = 0;
			this.chkCleanState.Text = "Schoonmaken";
			this.chkCleanState.UseVisualStyleBackColor = true;
			this.chkCleanState.CheckedChanged += new System.EventHandler(this.chkCleanState_CheckedChanged);
			// 
			// txtNote
			// 
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.Location = new System.Drawing.Point(0, 67);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(584, 340);
			this.txtNote.TabIndex = 1;
			// 
			// lblRemark
			// 
			this.lblRemark.AutoSize = true;
			this.lblRemark.Location = new System.Drawing.Point(6, 51);
			this.lblRemark.Name = "lblRemark";
			this.lblRemark.Size = new System.Drawing.Size(61, 13);
			this.lblRemark.TabIndex = 0;
			this.lblRemark.Text = "Opmerking:";
			// 
			// tpCleaning
			// 
			this.tpCleaning.Controls.Add(this.lblFilter);
			this.tpCleaning.Controls.Add(this.comFilterClean);
			this.tpCleaning.Controls.Add(this.dgvCleaning);
			this.tpCleaning.Controls.Add(this.btnPlanCleaning);
			this.tpCleaning.Location = new System.Drawing.Point(4, 22);
			this.tpCleaning.Name = "tpCleaning";
			this.tpCleaning.Padding = new System.Windows.Forms.Padding(3);
			this.tpCleaning.Size = new System.Drawing.Size(584, 407);
			this.tpCleaning.TabIndex = 1;
			this.tpCleaning.Text = "Schoonmaak";
			this.tpCleaning.UseVisualStyleBackColor = true;
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(343, 9);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(32, 13);
			this.lblFilter.TabIndex = 5;
			this.lblFilter.Text = "Filter:";
			// 
			// comFilterClean
			// 
			this.comFilterClean.FormattingEnabled = true;
			this.comFilterClean.Location = new System.Drawing.Point(381, 6);
			this.comFilterClean.Name = "comFilterClean";
			this.comFilterClean.Size = new System.Drawing.Size(197, 21);
			this.comFilterClean.TabIndex = 4;
			this.comFilterClean.SelectedIndexChanged += new System.EventHandler(this.comFilterClean_SelectedIndexChanged);
			// 
			// dgvCleaning
			// 
			this.dgvCleaning.AllowUserToAddRows = false;
			this.dgvCleaning.AllowUserToDeleteRows = false;
			this.dgvCleaning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCleaning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCleaning.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvCleaning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCleaning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chDateTime,
            this.chWorkDescription,
            this.chPerformed,
            this.chPlannedFor,
            this.chRemark});
			this.dgvCleaning.Location = new System.Drawing.Point(0, 32);
			this.dgvCleaning.MultiSelect = false;
			this.dgvCleaning.Name = "dgvCleaning";
			this.dgvCleaning.RowHeadersVisible = false;
			this.dgvCleaning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCleaning.ShowCellErrors = false;
			this.dgvCleaning.ShowCellToolTips = false;
			this.dgvCleaning.ShowEditingIcon = false;
			this.dgvCleaning.ShowRowErrors = false;
			this.dgvCleaning.Size = new System.Drawing.Size(584, 375);
			this.dgvCleaning.TabIndex = 3;
			this.dgvCleaning.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
			// 
			// chDateTime
			// 
			this.chDateTime.HeaderText = "Datum / tijd";
			this.chDateTime.Name = "chDateTime";
			// 
			// chWorkDescription
			// 
			this.chWorkDescription.HeaderText = "Werkomschrijving";
			this.chWorkDescription.Name = "chWorkDescription";
			// 
			// chPerformed
			// 
			this.chPerformed.HeaderText = "Uitgevoerd";
			this.chPerformed.Name = "chPerformed";
			// 
			// chPlannedFor
			// 
			this.chPlannedFor.HeaderText = "Gepland voor";
			this.chPlannedFor.Name = "chPlannedFor";
			// 
			// chRemark
			// 
			this.chRemark.HeaderText = "Notitie";
			this.chRemark.Name = "chRemark";
			// 
			// btnPlanCleaning
			// 
			this.btnPlanCleaning.Location = new System.Drawing.Point(3, 3);
			this.btnPlanCleaning.Name = "btnPlanCleaning";
			this.btnPlanCleaning.Size = new System.Drawing.Size(115, 23);
			this.btnPlanCleaning.TabIndex = 2;
			this.btnPlanCleaning.Text = "Plan Schoonmaak";
			this.btnPlanCleaning.UseVisualStyleBackColor = true;
			this.btnPlanCleaning.Click += new System.EventHandler(this.btnPlanCleaning_Click);
			// 
			// tpMaintenance
			// 
			this.tpMaintenance.Controls.Add(this.lblFilterRep);
			this.tpMaintenance.Controls.Add(this.comFilterReparation);
			this.tpMaintenance.Controls.Add(this.dgvReparation);
			this.tpMaintenance.Controls.Add(this.btnPlanMaintenance);
			this.tpMaintenance.Location = new System.Drawing.Point(4, 22);
			this.tpMaintenance.Name = "tpMaintenance";
			this.tpMaintenance.Size = new System.Drawing.Size(584, 407);
			this.tpMaintenance.TabIndex = 2;
			this.tpMaintenance.Text = "Onderhoud";
			this.tpMaintenance.UseVisualStyleBackColor = true;
			// 
			// lblFilterRep
			// 
			this.lblFilterRep.AutoSize = true;
			this.lblFilterRep.Location = new System.Drawing.Point(343, 9);
			this.lblFilterRep.Name = "lblFilterRep";
			this.lblFilterRep.Size = new System.Drawing.Size(32, 13);
			this.lblFilterRep.TabIndex = 6;
			this.lblFilterRep.Text = "Filter:";
			// 
			// comFilterReparation
			// 
			this.comFilterReparation.FormattingEnabled = true;
			this.comFilterReparation.Location = new System.Drawing.Point(381, 6);
			this.comFilterReparation.Name = "comFilterReparation";
			this.comFilterReparation.Size = new System.Drawing.Size(197, 21);
			this.comFilterReparation.TabIndex = 6;
			this.comFilterReparation.SelectedIndexChanged += new System.EventHandler(this.comFilterReparation_SelectedIndexChanged);
			// 
			// dgvReparation
			// 
			this.dgvReparation.AllowUserToAddRows = false;
			this.dgvReparation.AllowUserToDeleteRows = false;
			this.dgvReparation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvReparation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvReparation.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvReparation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReparation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chDateTimeRep,
            this.chWorkNoteRep,
            this.chPerformedRep,
            this.chPlannedForRep,
            this.chNoteRep});
			this.dgvReparation.Location = new System.Drawing.Point(0, 32);
			this.dgvReparation.MultiSelect = false;
			this.dgvReparation.Name = "dgvReparation";
			this.dgvReparation.RowHeadersVisible = false;
			this.dgvReparation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvReparation.ShowCellErrors = false;
			this.dgvReparation.ShowCellToolTips = false;
			this.dgvReparation.ShowEditingIcon = false;
			this.dgvReparation.ShowRowErrors = false;
			this.dgvReparation.Size = new System.Drawing.Size(584, 375);
			this.dgvReparation.TabIndex = 7;
			this.dgvReparation.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
			// 
			// btnPlanMaintenance
			// 
			this.btnPlanMaintenance.Location = new System.Drawing.Point(3, 3);
			this.btnPlanMaintenance.Name = "btnPlanMaintenance";
			this.btnPlanMaintenance.Size = new System.Drawing.Size(115, 23);
			this.btnPlanMaintenance.TabIndex = 6;
			this.btnPlanMaintenance.Text = "Plan Onderhoud";
			this.btnPlanMaintenance.UseVisualStyleBackColor = true;
			this.btnPlanMaintenance.Click += new System.EventHandler(this.btnPlanMaintenance_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(12, 490);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(115, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Annuleren";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(485, 490);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(115, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Opslaan";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// chDateTimeRep
			// 
			this.chDateTimeRep.HeaderText = "Datum / tijd";
			this.chDateTimeRep.Name = "chDateTimeRep";
			// 
			// chWorkNoteRep
			// 
			this.chWorkNoteRep.HeaderText = "Werkomschrijving";
			this.chWorkNoteRep.Name = "chWorkNoteRep";
			// 
			// chPerformedRep
			// 
			this.chPerformedRep.HeaderText = "Uitgevoerd";
			this.chPerformedRep.Name = "chPerformedRep";
			// 
			// chPlannedForRep
			// 
			this.chPlannedForRep.HeaderText = "Gepland voor";
			this.chPlannedForRep.Name = "chPlannedForRep";
			// 
			// chNoteRep
			// 
			this.chNoteRep.HeaderText = "Notitie";
			this.chNoteRep.Name = "chNoteRep";
			// 
			// FrmTramData
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(616, 525);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tclTramData);
			this.Controls.Add(this.lblTramTrackInfo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmTramData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GVB Trams - Tramgegevens";
			this.Load += new System.EventHandler(this.FrmTramData_Load);
			this.tclTramData.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.tpGeneral.PerformLayout();
			this.grbTramState.ResumeLayout(false);
			this.grbTramState.PerformLayout();
			this.tpCleaning.ResumeLayout(false);
			this.tpCleaning.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCleaning)).EndInit();
			this.tpMaintenance.ResumeLayout(false);
			this.tpMaintenance.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReparation)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTramTrackInfo;
		private System.Windows.Forms.TabControl tclTramData;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabPage tpCleaning;
		private System.Windows.Forms.Button btnPlanCleaning;
		private System.Windows.Forms.TabPage tpMaintenance;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblRemark;
		private System.Windows.Forms.Button btnPlanMaintenance;
		private System.Windows.Forms.TextBox txtNote;
		private System.Windows.Forms.DataGridView dgvCleaning;
		private System.Windows.Forms.DataGridViewTextBoxColumn chDateTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn chWorkDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn chPerformed;
		private System.Windows.Forms.DataGridViewTextBoxColumn chPlannedFor;
		private System.Windows.Forms.DataGridViewTextBoxColumn chRemark;
		private System.Windows.Forms.DataGridView dgvReparation;
		private System.Windows.Forms.ComboBox comFilterClean;
		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.ComboBox comFilterReparation;
		private System.Windows.Forms.Label lblFilterRep;
		private System.Windows.Forms.GroupBox grbTramState;
		private System.Windows.Forms.CheckBox chkReparationState;
		private System.Windows.Forms.CheckBox chkCleanState;
		private System.Windows.Forms.DataGridViewTextBoxColumn chDateTimeRep;
		private System.Windows.Forms.DataGridViewTextBoxColumn chWorkNoteRep;
		private System.Windows.Forms.DataGridViewTextBoxColumn chPerformedRep;
		private System.Windows.Forms.DataGridViewTextBoxColumn chPlannedForRep;
		private System.Windows.Forms.DataGridViewTextBoxColumn chNoteRep;
	}
}