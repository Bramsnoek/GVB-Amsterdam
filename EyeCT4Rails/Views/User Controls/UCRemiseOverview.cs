using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DragDrop;

namespace EyeCT4Rails
{
	public partial class UCRemiseOverview : UserControl
	{
		#region Properties
		public TrackHandler TrackHandler { get; set; }
		public SectorHandler SectorHandler { get; set; }
		public TramHandler TramHandler { get; set; }
		#endregion

		#region Fields
		private UCRemiseSystem ucRemiseSystem;
		private User UserLoggedIn;
		private List<Track> tracks;
		private List<Tram> trams;
		private Label lblDragText;
		private int splitterDistance;
		#endregion

		#region Constructor
		public UCRemiseOverview(User userLoggedIn, List<Tram> trams, List<Track> tracks, int splitterDistance = -1)
		{	
			InitializeComponent();

			UserLoggedIn = userLoggedIn;
			this.trams = trams;
			this.tracks = tracks;

			this.splitterDistance = splitterDistance;
		}
		#endregion

		#region Event Handlers
		private void UCRemiseOverzicht_Load(object sender, EventArgs e)
		{
			checkUCRemiseSystem();

			ucRemiseSystem.TrackHandler = TrackHandler;
			ucRemiseSystem.SectorHandler = SectorHandler;
			ucRemiseSystem.TramHandler = TramHandler;

			RefreshTrams();

			ucRemiseSystem.Dock = DockStyle.Fill;
			pnlMain.Panel2.Controls.Add(ucRemiseSystem);

			pnlMain.Panel1Collapsed = !Permission.Check(UserLoggedIn, Permission.Permissions.CanDragTrams);
		}

		private void UCRemiseOverview_Layout(object sender, LayoutEventArgs e)
		{
			if (splitterDistance != -1) pnlMain.SplitterDistance = splitterDistance;
		}

		private void txtTramFilter_TextChanged(object sender, EventArgs e)
		{
			RefreshTrams();
		}

		private void trvTrams_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TramHandler(this, (Tram)e.Node.Tag, HandlerStatus.Show);
		}
		private void trvTrams_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(typeof(Tram))) return;

			e.Effect = DragDropEffects.Move;
		}

		private void trvTrams_DragDrop(object sender, DragEventArgs e)
		{
			trams.Add((Tram)e.Data.GetData(typeof(Tram)));
			RefreshTrams();
		}

		private void trvTrams_ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode treeNode = (TreeNode)e.Item;

			lblDragText.Text = ((Tram)treeNode.Tag).Number.ToString();

			switch (((Tram)treeNode.Tag).TramState)
			{
				case Tram.State.Ok:
					lblDragText.Image = Properties.Resources.TRAM_NOR;
					break;
				case Tram.State.Dirty:
					lblDragText.Image = Properties.Resources.TRAM_SCH;
					break;
				case Tram.State.Reparation:
					lblDragText.Image = Properties.Resources.TRAM_REP;
					break;
				case Tram.State.ReparationDirty:
					lblDragText.Image = Properties.Resources.TRAM_SRE;
					break;
			}

			if (DragDropLogic.DoDragDrop(lblDragText, this.ParentForm, new MouseEventArgs(e.Button, 1, 1, 1, 0), (Tram)treeNode.Tag, 1 , DragDropEffects.Move))
			{
				trams.Remove((Tram)treeNode.Tag);
				RefreshTrams();
			}
		}
		#endregion

		#region Methods
		public void RefreshTrams()
		{
			trvTrams.BeginUpdate();
			trvTrams.Nodes.Clear();

			List<Tram> tmpTrams = trams.FindAll(tram => tram.Number.ToString().Contains(txtTramFilter.Text));
			tmpTrams.Sort();

			foreach (Tram tram in tmpTrams)
			{
				trvTrams.Nodes.Add(new TreeNode(tram.Number.ToString()) { Tag = tram });
			}

			trvTrams.EndUpdate();
		}

		public void AddTrack(Track track)
		{
			ucRemiseSystem.AddTrack(track);
		}

		public void UpdateTrack(Track track, bool updateList = false)
		{
			if (updateList) RefreshTrams();

			ucRemiseSystem.UpdateTrack(track);
		}

		public void UpdateTram(Tram tram)
		{
			ucRemiseSystem.UpdateSector(tram);
		}

		public void RefreshMeAndSubs(List<Tram> notArrangedTrams, List<Track> tracks)
		{
			if (notArrangedTrams != null) trams = notArrangedTrams;
			checkUCRemiseSystem();

			RefreshTrams();
			ucRemiseSystem.RefreshAll(tracks);
		}

		public void FilterView(Tram.State state)
		{
			if (ucRemiseSystem == null) return;

			ucRemiseSystem.FilterTram(state);
		}

		private void checkUCRemiseSystem()
		{
			if (ucRemiseSystem != null) return;

			int textSize = 18;
			lblDragText = new Label();
			lblDragText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblDragText.ForeColor = System.Drawing.Color.White;
			lblDragText.Font = new System.Drawing.Font("Microsoft Sans Serif", textSize);
			lblDragText.Width = textSize * 4;
			lblDragText.Height = textSize + 10;

			ucRemiseSystem = new UCRemiseSystem(tracks, lblDragText, UserLoggedIn);
		}
		#endregion
	}
}