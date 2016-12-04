using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EyeCT4Rails
{
	public partial class UCRemiseSystem : UserControl
	{
		public TramHandler TramHandler { get; set; }
		public TrackHandler TrackHandler { get; set; }
		public SectorHandler SectorHandler { get; set; }
		public List<UCTrackCluster> TrackClusters = new List<UCTrackCluster>();

		private List<Track> tracks;
		private Label lbl;
		private User user;
		private Tram.State state;

		private int i;
		private int y;

		public UCRemiseSystem(List<Track> Tracks, Label lbl, User user)
		{
			InitializeComponent();

			this.tracks = Tracks;
			this.lbl = lbl;
			this.user = user;
		}

		public void FilterTram(Tram.State state)
		{
			this.Controls.Clear();
			i = 0;
			y = 3;
			this.state = state;
			InnitializeTracks(state);
		}

		private void InnitializeTracks(Tram.State state)
		{
			Panel scrollpnl = new Panel();
			scrollpnl.AutoScroll = true;
			scrollpnl.Dock = DockStyle.Fill;

			System.Threading.Thread.Sleep(1);
			foreach (Track t in tracks)
			{
				i++;

				Panel pnl = new Panel();
				pnl.Name = "pnl" + i.ToString();
				pnl.Size = new System.Drawing.Size(531, 89);

				if (i % 2 == 0)
				{
					pnl.Location = new System.Drawing.Point(556, y);
					y += 95;
				}
				else
					pnl.Location = new System.Drawing.Point(3, y);

				UCTrackCluster tr = new UCTrackCluster(t.TrackNumber, t.Sectors.Count, t.Sectors, state, t, tracks, lbl, user)
				{
					TramHandler = this.TramHandler,
					TrackHandler = this.TrackHandler,
					SectorHandler = this.SectorHandler,
				};

				pnl.Controls.Add(tr);
				TrackClusters.Add(tr);
				scrollpnl.Controls.Add(pnl);
			}

			this.Controls.Add(scrollpnl);
		}

		public void AddTrack(Track t)
		{
			UCTrackCluster tr = new UCTrackCluster(t.TrackNumber, t.Sectors.Count, t.Sectors, Tram.State.Ok, t, tracks, lbl, user);
			TrackClusters.Add(tr);
			RefreshAllVisual(tracks);
		}

		public void RefreshAll(List<Track> currentTracks)
		{
			this.tracks = currentTracks;
			FilterTram(state);
		}

		public void RefreshAllVisual(List<Track> currentTracks)
		{
			this.tracks = currentTracks;
			FilterTram(state);
		}

		public void UpdateSector(Tram tram)
		{
			if (tram.Sector == null) return;
			Track tramTrack = tram.Sector.Track;

			foreach(UCTrackCluster tr in TrackClusters.Where(tr => tr.CurrentTrack.ID == tramTrack.ID))
			{
				tr.UpdateSector(tram.Sector, true);
			}
		}

		public void UpdateTrack(Track track)
		{
			foreach (UCTrackCluster tr in TrackClusters.Where(tr => tr.CurrentTrack.ID == track.ID))
			{
				tr.UpdateTrack();
			}
		}

		private void UCRemiseSystem_Load(object sender, System.EventArgs e)
		{
			FilterTram(state);
		}
	}
}
