namespace EyeCT4Rails
{
	partial class UCRemiseOverview
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
			this.pnlMain = new System.Windows.Forms.SplitContainer();
			this.trvTrams = new System.Windows.Forms.TreeView();
			this.lblTramFilter = new System.Windows.Forms.Label();
			this.gbTramList = new System.Windows.Forms.GroupBox();
			this.txtTramFilter = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.gbTramList.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.trvTrams);
			this.pnlMain.Panel1.Controls.Add(this.lblTramFilter);
			this.pnlMain.Panel1.Controls.Add(this.gbTramList);
			this.pnlMain.Panel1MinSize = 180;
			this.pnlMain.Panel2MinSize = 220;
			this.pnlMain.Size = new System.Drawing.Size(600, 300);
			this.pnlMain.SplitterDistance = 180;
			this.pnlMain.SplitterWidth = 5;
			this.pnlMain.TabIndex = 8;
			// 
			// trvTrams
			// 
			this.trvTrams.AllowDrop = true;
			this.trvTrams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.trvTrams.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.trvTrams.FullRowSelect = true;
			this.trvTrams.Location = new System.Drawing.Point(12, 42);
			this.trvTrams.Name = "trvTrams";
			this.trvTrams.ShowRootLines = false;
			this.trvTrams.Size = new System.Drawing.Size(161, 246);
			this.trvTrams.TabIndex = 3;
			this.trvTrams.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvTrams_ItemDrag);
			this.trvTrams.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvTrams_NodeMouseDoubleClick);
			this.trvTrams.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvTrams_DragDrop);
			this.trvTrams.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvTrams_DragEnter);
			// 
			// lblTramFilter
			// 
			this.lblTramFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTramFilter.AutoSize = true;
			this.lblTramFilter.Location = new System.Drawing.Point(12, 15);
			this.lblTramFilter.Name = "lblTramFilter";
			this.lblTramFilter.Size = new System.Drawing.Size(32, 13);
			this.lblTramFilter.TabIndex = 1;
			this.lblTramFilter.Text = "F&ilter:";
			// 
			// gbTramList
			// 
			this.gbTramList.Controls.Add(this.txtTramFilter);
			this.gbTramList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbTramList.Location = new System.Drawing.Point(0, 0);
			this.gbTramList.Name = "gbTramList";
			this.gbTramList.Size = new System.Drawing.Size(180, 300);
			this.gbTramList.TabIndex = 0;
			this.gbTramList.TabStop = false;
			// 
			// txtTramFilter
			// 
			this.txtTramFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTramFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtTramFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtTramFilter.Location = new System.Drawing.Point(50, 11);
			this.txtTramFilter.Name = "txtTramFilter";
			this.txtTramFilter.Size = new System.Drawing.Size(124, 20);
			this.txtTramFilter.TabIndex = 2;
			this.txtTramFilter.TextChanged += new System.EventHandler(this.txtTramFilter_TextChanged);
			// 
			// UCRemiseOverview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlMain);
			this.Name = "UCRemiseOverview";
			this.Size = new System.Drawing.Size(600, 300);
			this.Load += new System.EventHandler(this.UCRemiseOverzicht_Load);
			this.Layout += new System.Windows.Forms.LayoutEventHandler(this.UCRemiseOverview_Layout);
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.gbTramList.ResumeLayout(false);
			this.gbTramList.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox gbTramList;
		private System.Windows.Forms.Label lblTramFilter;
		private System.Windows.Forms.TreeView trvTrams;
		private System.Windows.Forms.SplitContainer pnlMain;
		private System.Windows.Forms.TextBox txtTramFilter;
	}
}
