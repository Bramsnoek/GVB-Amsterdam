namespace EyeCT4Rails
{
	partial class FrmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemUserManagement = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAddTrack = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemRunSimulation = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemLogOut = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.lblSearch = new System.Windows.Forms.Label();
			this.comSearch = new System.Windows.Forms.ComboBox();
			this.lblFilter = new System.Windows.Forms.Label();
			this.comFilter = new System.Windows.Forms.ComboBox();
			this.lblMenu = new System.Windows.Forms.Label();
			this.comMenu = new System.Windows.Forms.ComboBox();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.menuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(1350, 24);
			this.menuMain.TabIndex = 0;
			// 
			// menuItemFile
			// 
			this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUserManagement,
            this.menuItemAddTrack,
            this.menuItemRunSimulation,
            this.menuSeparator1,
            this.menuItemLogOut,
            this.menuItemExit});
			this.menuItemFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
			this.menuItemFile.Name = "menuItemFile";
			this.menuItemFile.Size = new System.Drawing.Size(61, 20);
			this.menuItemFile.Text = "&Bestand";
			// 
			// menuItemUserManagement
			// 
			this.menuItemUserManagement.Name = "menuItemUserManagement";
			this.menuItemUserManagement.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
			this.menuItemUserManagement.Size = new System.Drawing.Size(206, 22);
			this.menuItemUserManagement.Text = "&Gebruikersbeheer";
			this.menuItemUserManagement.Click += new System.EventHandler(this.menuItemUserManagement_Click);
			// 
			// menuItemAddTrack
			// 
			this.menuItemAddTrack.Name = "menuItemAddTrack";
			this.menuItemAddTrack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
			this.menuItemAddTrack.Size = new System.Drawing.Size(206, 22);
			this.menuItemAddTrack.Text = "&Spoor toevoegen";
			this.menuItemAddTrack.Click += new System.EventHandler(this.menuItemAddTrack_Click);
			// 
			// menuItemRunSimulation
			// 
			this.menuItemRunSimulation.CheckOnClick = true;
			this.menuItemRunSimulation.Name = "menuItemRunSimulation";
			this.menuItemRunSimulation.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.menuItemRunSimulation.Size = new System.Drawing.Size(206, 22);
			this.menuItemRunSimulation.Text = "S&imulatie";
			this.menuItemRunSimulation.Click += new System.EventHandler(this.menuItemRunSimulation_Click);
			// 
			// menuSeparator1
			// 
			this.menuSeparator1.Name = "menuSeparator1";
			this.menuSeparator1.Size = new System.Drawing.Size(203, 6);
			// 
			// menuItemLogOut
			// 
			this.menuItemLogOut.Name = "menuItemLogOut";
			this.menuItemLogOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.menuItemLogOut.Size = new System.Drawing.Size(206, 22);
			this.menuItemLogOut.Text = "&Uitloggen";
			this.menuItemLogOut.Click += new System.EventHandler(this.menuItemLogOut_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.menuItemExit.Size = new System.Drawing.Size(206, 22);
			this.menuItemExit.Text = "&Afsluiten";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItemEdit
			// 
			this.menuItemEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
			this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUndo,
            this.menuSeparator2,
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuSeparator3,
            this.menuItemSelectAll});
			this.menuItemEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
			this.menuItemEdit.Name = "menuItemEdit";
			this.menuItemEdit.Size = new System.Drawing.Size(70, 20);
			this.menuItemEdit.Text = "Be&werken";
			this.menuItemEdit.Click += new System.EventHandler(this.menuItemEdit_Click);
			// 
			// menuItemUndo
			// 
			this.menuItemUndo.Name = "menuItemUndo";
			this.menuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.menuItemUndo.Size = new System.Drawing.Size(209, 22);
			this.menuItemUndo.Text = "O&ngedaan maken";
			this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
			// 
			// menuSeparator2
			// 
			this.menuSeparator2.Name = "menuSeparator2";
			this.menuSeparator2.Size = new System.Drawing.Size(206, 6);
			// 
			// menuItemCut
			// 
			this.menuItemCut.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCut.Image")));
			this.menuItemCut.Name = "menuItemCut";
			this.menuItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.menuItemCut.Size = new System.Drawing.Size(209, 22);
			this.menuItemCut.Text = "&Knippen";
			this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
			// 
			// menuItemCopy
			// 
			this.menuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCopy.Image")));
			this.menuItemCopy.Name = "menuItemCopy";
			this.menuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.menuItemCopy.Size = new System.Drawing.Size(209, 22);
			this.menuItemCopy.Text = "K&opiëren";
			this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
			// 
			// menuItemPaste
			// 
			this.menuItemPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuItemPaste.Image")));
			this.menuItemPaste.Name = "menuItemPaste";
			this.menuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.menuItemPaste.Size = new System.Drawing.Size(209, 22);
			this.menuItemPaste.Text = "&Plakken";
			this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
			// 
			// menuSeparator3
			// 
			this.menuSeparator3.Name = "menuSeparator3";
			this.menuSeparator3.Size = new System.Drawing.Size(206, 6);
			// 
			// menuItemSelectAll
			// 
			this.menuItemSelectAll.Name = "menuItemSelectAll";
			this.menuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.menuItemSelectAll.Size = new System.Drawing.Size(209, 22);
			this.menuItemSelectAll.Text = "&Alles selecteren";
			this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
			// 
			// lblSearch
			// 
			this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(12, 33);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(47, 13);
			this.lblSearch.TabIndex = 1;
			this.lblSearch.Text = "&Zoeken:";
			// 
			// comSearch
			// 
			this.comSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comSearch.FormattingEnabled = true;
			this.comSearch.Location = new System.Drawing.Point(65, 30);
			this.comSearch.Name = "comSearch";
			this.comSearch.Size = new System.Drawing.Size(145, 21);
			this.comSearch.TabIndex = 2;
			this.comSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comSearch_KeyDown);
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(216, 33);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(32, 13);
			this.lblFilter.TabIndex = 3;
			this.lblFilter.Text = "&Filter:";
			// 
			// comFilter
			// 
			this.comFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comFilter.FormattingEnabled = true;
			this.comFilter.Items.AddRange(new object[] {
            "Geen",
            "Reparatie",
            "Schoonmakers"});
			this.comFilter.Location = new System.Drawing.Point(254, 30);
			this.comFilter.Name = "comFilter";
			this.comFilter.Size = new System.Drawing.Size(140, 21);
			this.comFilter.TabIndex = 4;
			this.comFilter.SelectedIndexChanged += new System.EventHandler(this.comFilter_SelectedIndexChanged);
			// 
			// lblMenu
			// 
			this.lblMenu.AutoSize = true;
			this.lblMenu.Location = new System.Drawing.Point(400, 33);
			this.lblMenu.Name = "lblMenu";
			this.lblMenu.Size = new System.Drawing.Size(37, 13);
			this.lblMenu.TabIndex = 5;
			this.lblMenu.Text = "&Menu:";
			// 
			// comMenu
			// 
			this.comMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comMenu.FormattingEnabled = true;
			this.comMenu.Items.AddRange(new object[] {
            "Remiseoverzicht",
            "Reperatieoverzicht",
            "Schoonmaakoverzicht"});
			this.comMenu.Location = new System.Drawing.Point(443, 30);
			this.comMenu.Name = "comMenu";
			this.comMenu.Size = new System.Drawing.Size(140, 21);
			this.comMenu.TabIndex = 6;
			this.comMenu.SelectedIndexChanged += new System.EventHandler(this.comMenu_SelectedIndexChanged);
			// 
			// pnlMain
			// 
			this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlMain.Location = new System.Drawing.Point(0, 57);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1350, 500);
			this.pnlMain.TabIndex = 7;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1350, 557);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.comMenu);
			this.Controls.Add(this.lblMenu);
			this.Controls.Add(this.comFilter);
			this.Controls.Add(this.lblFilter);
			this.Controls.Add(this.comSearch);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuMain;
			this.MinimumSize = new System.Drawing.Size(620, 400);
			this.Name = "FrmMain";
			this.Text = "GVB Trams";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#region Controls
		private void menuItemEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.TextBox txtCurrent = CheckActiveControl();

				if (txtCurrent == null)
				{
					ResetControlsToDefault();
					return;
				}

				menuItemUndo.Enabled = txtCurrent.CanUndo;
				menuItemCut.Enabled = txtCurrent.SelectionLength > 0 && !txtCurrent.ReadOnly && !txtCurrent.UseSystemPasswordChar;
				menuItemCopy.Enabled = txtCurrent.SelectionLength > 0 && !txtCurrent.UseSystemPasswordChar;
				menuItemPaste.Enabled = txtCurrent.Focused && System.Windows.Forms.Clipboard.ContainsText() && !txtCurrent.ReadOnly;
				menuItemSelectAll.Enabled = txtCurrent.Focused && !txtCurrent.ReadOnly;
			}
			catch
			{
				ResetControlsToDefault();
			}
		}

		private System.Windows.Forms.TextBox CheckActiveControl()
		{
			if (this.ActiveControl == ucRemiseOverview)
			{
				return ((System.Windows.Forms.SplitContainer)((System.Windows.Forms.UserControl)(this.ActiveControl)).ActiveControl).ActiveControl as System.Windows.Forms.TextBox;
			}
			else
			{
				return this.ActiveControl as System.Windows.Forms.TextBox;
			}
		}

		private void ResetControlsToDefault()
		{
			menuItemUndo.Enabled = false;
			menuItemCut.Enabled = false;
			menuItemCopy.Enabled = false;
			menuItemPaste.Enabled = false;
			menuItemSelectAll.Enabled = false;
		}

		private void menuItemUndo_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.TextBox txtCurrent = CheckActiveControl();
				if (txtCurrent == null) return;
				txtCurrent.Undo();
				menuItemEdit_Click(this, null);
			}
			catch
			{
				throw;
			}
		}

		private void menuItemCut_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.TextBox txtCurrent = CheckActiveControl();
				if (txtCurrent == null) return;
				txtCurrent.Cut();
				menuItemEdit_Click(this, null);
			}
			catch
			{
				throw;
			}
		}

		private void menuItemCopy_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.TextBox txtCurrent = CheckActiveControl();
				if (txtCurrent == null) return;
				txtCurrent.Copy();
				menuItemEdit_Click(this, null);
			}
			catch
			{
				throw;
			}
		}

		private void menuItemPaste_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.TextBox txtCurrent = CheckActiveControl();
				if (txtCurrent == null) return;
				txtCurrent.Paste();
				menuItemEdit_Click(this, null);
			}
			catch
			{
				throw;
			}
		}

		private void menuItemSelectAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.TextBox txtCurrent = CheckActiveControl();
				if (txtCurrent == null) return;
				txtCurrent.SelectAll();
				menuItemEdit_Click(this, null);
			}
			catch
			{
				throw;
			}
		}

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemUserManagement;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.ComboBox comSearch;
		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.ComboBox comFilter;
		private System.Windows.Forms.Label lblMenu;
		private System.Windows.Forms.ComboBox comMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
		private System.Windows.Forms.ToolStripMenuItem menuItemUndo;
		private System.Windows.Forms.ToolStripSeparator menuSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuItemCut;
		private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
		private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
		private System.Windows.Forms.ToolStripSeparator menuSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
		private System.Windows.Forms.ToolStripSeparator menuSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ToolStripMenuItem menuItemAddTrack;
		private System.Windows.Forms.ToolStripMenuItem menuItemLogOut;
		private System.Windows.Forms.ToolStripMenuItem menuItemRunSimulation;
		#endregion
	}
}

