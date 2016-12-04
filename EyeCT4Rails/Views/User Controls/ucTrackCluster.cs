using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DragDrop;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace EyeCT4Rails
{
	public partial class
		UCTrackCluster : UserControl
	{
		#region properties

		public Track CurrentTrack { get; set; }
		public TramHandler TramHandler { get; set; }
		public TrackHandler TrackHandler { get; set; }
		public SectorHandler SectorHandler { get; set; }
		public List<Sector> Sectors { get; set; }
		public List<Track> Tracks { get; set; }

		private int tempX = 3;
		private int buttonNumber;
		private Label lbl;
		private User user;
		private Tram.State state;
		private List<Sector> manuallyBlocked;
		#endregion

		public UCTrackCluster(int buttonNumber, int clusterCount, List<Sector> sectors, Tram.State state, Track CurrentTrack, List<Track> Tracks, Label lbl, User user)
		{
			InitializeComponent();

			this.lbl = lbl;
			this.user = user;
			this.CurrentTrack = CurrentTrack;
			this.Tracks = Tracks;
			this.buttonNumber = buttonNumber;
			this.Sectors = sectors;

			manuallyBlocked = new List<Sector>();

			Filter(state);
		}
	

		private void Pnl_DragDrop(object sender, DragEventArgs e)
		{
			Panel sectorPanel = (Panel)sender;
			Sector toBeChangedSector = Sectors[(int.Parse(Regex.Match(sectorPanel.Name, @"\d+").Value))];
			Label tramLabel = sectorPanel.Controls.Find("lblNumber", false).FirstOrDefault() as Label;
			Tram currentTram = (Tram)e.Data.GetData(typeof(Tram));

			//if (toBeChangedSector.ListedTram != null) return;
			if (!e.Data.GetDataPresent(typeof(Tram))) return;
			else
			{
				toBeChangedSector.ListedTram = currentTram;
				currentTram.Sector = toBeChangedSector;

				if (toBeChangedSector.Enabled == false) return;

				SectorHandler(this, toBeChangedSector, HandlerStatus.Update);

				sectorPanel.BackColor = GetColor(toBeChangedSector.ListedTram.TramState, toBeChangedSector, tramLabel, sectorPanel);

				tramLabel.Text = toBeChangedSector.ListedTram.Number.ToString();
				GetBlockedSectors(toBeChangedSector.Track);
			}
		}
		private void Pnl_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(typeof(Tram))) return;

			Panel sectorPanel = (Panel)sender;
			Sector toBeChangedSector = Sectors[(int.Parse(Regex.Match(sectorPanel.Name, @"\d+").Value))];
			if (!toBeChangedSector.Enabled) return;
			if (toBeChangedSector.ListedTram != null) return;

			e.Effect = DragDropEffects.Move;
		}

	

		public void Filter(Tram.State state)
		{
			this.state = state;
			int i = 0;
			foreach (Sector s in Sectors)
			{
				Label lblTramNumber = new Label();

				if (s.ListedTram != null)
				{
					lblTramNumber.Text = s.ListedTram.Number.ToString();
				}

				if (!s.Enabled)
					manuallyBlocked.Add(s);

				#region panel
				Panel pnl = new Panel();
				pnl.Name = "Panel" + i.ToString();
				pnl.Size = new Size(((430 / Sectors.Count)), 89);
				pnl.Location = new Point(tempX, 3);
				pnl.BorderStyle = BorderStyle.Fixed3D;
				pnl.BackColor = GetColor(state, s, lblTramNumber, pnl);

				pnl.AllowDrop = true;

				#endregion

				#region roundbutton
				GaryPerkin.UserControls.Buttons.RoundButton roundbutton = new GaryPerkin.UserControls.Buttons.RoundButton();
				roundbutton.Text = buttonNumber.ToString();
				roundbutton.Font = new Font("Sans Serif", 16);
				roundbutton.Size = new Size(80, 80);
				roundbutton.Location = new Point(12, 5);

				#endregion

				#region lbltramnumber
				lblTramNumber.Size = new Size(200, 200);
				lblTramNumber.Font = new Font("Sans Serif", 80 / Sectors.Count);
				if(lblTramNumber.Font.Size >= 60)
				{
					lblTramNumber.Font = new Font("Sans Serif", 50);
				}
				lblTramNumber.Name = "lblNumber";
				lblTramNumber.Parent = panel1;
				lblTramNumber.BackColor = Color.Transparent;

				if (Sectors.Count == 1)
				{
					lblTramNumber.Location = new Point(135 / Sectors.Count, 2);
					lblTramNumber.Size = new Size(250, 200);
				}
				else if(Sectors.Count > 8)
				{
					lblTramNumber.Location = new Point(78 / Sectors.Count, (int)((Sectors.Count / 0.23f)));
				}
				else if (Sectors.Count < 6)
					lblTramNumber.Location = new Point(95 / Sectors.Count, (int)((Sectors.Count / 0.16f)));
				else if (Sectors.Count == 7 || Sectors.Count == 6)
					lblTramNumber.Location = new Point(100 / Sectors.Count, (int)((Sectors.Count / 0.19f)));
				else if (Sectors.Count == 8)
					lblTramNumber.Location = new Point(78 / Sectors.Count, (int)((Sectors.Count / 0.23f)));
				#endregion

				pnl.MouseDown += Pnl_MouseDown;
				lblTramNumber.MouseDown += LblTramNumber_MouseDown;

				if (Permission.Check(user, Permission.Permissions.CanDragTrams))
				{
					pnl.DragDrop += Pnl_DragDrop;
					pnl.DragEnter += Pnl_DragEnter;
				}
				if (Permission.Check(user, Permission.Permissions.CanEditTramNote))
				{
					lblTramNumber.DoubleClick += LblTramNumber_DoubleClick;
					pnl.DoubleClick += Pnl_DoubleClick;
				}
				if (Permission.Check(user, Permission.Permissions.CanEditTrack))
					roundbutton.MouseUp += Roundbutton_Click;
				else
					roundbutton.Enabled = false;

				this.Controls.Add(roundbutton);
				pnl.Controls.Add(lblTramNumber);
				panel1.Controls.Add(pnl);
				tempX = tempX + pnl.Size.Width;

				i++;
			}
			GetBlockedSectors(CurrentTrack);
		}

		private void Pnl_DoubleClick(object sender, EventArgs e)
		{
			Panel sectorPanel = (Panel)sender;

			doubleClickTram(sectorPanel);
		}

		private void LblTramNumber_DoubleClick(object sender, EventArgs e)
		{
			Label lblTramNumber = (Label)sender;
			Panel sectorPanel = (Panel)lblTramNumber.Parent;

			doubleClickTram(sectorPanel);
		}

	
		private void UCTrackCluster_Click(object sender, EventArgs e)
		{
			MenuItem cm = sender as MenuItem;
			ContextMenu contextmenu = cm.Parent as ContextMenu;
			Sector currentSector = contextmenu.Tag as Sector;

			switch (cm.Text.ToString())
			{
				case "Open Tram":
					TramHandler(this, currentSector.ListedTram, HandlerStatus.Show, 0);
					break;
				case "Open Spoor":
					TrackHandler(this, currentSector.Track, HandlerStatus.Show);
					break;
				case "Wacht op reparatie":
					TramHandler(this, currentSector.ListedTram, HandlerStatus.Show, 2);
					break;
				case "Wacht op schoonmaken":
					TramHandler(this, currentSector.ListedTram, HandlerStatus.Show, 1);
					break;
				case "Blokkeer sector":
					if (currentSector.Enabled)
					{
						currentSector.Enabled = false;
						manuallyBlocked.Add(currentSector);
					}
					else
					{
						currentSector.Enabled = true;
						manuallyBlocked.Remove(currentSector);
					}

					UpdateSector(currentSector, currentSector.Enabled);
					SectorHandler(this, currentSector, HandlerStatus.Update);
					GetBlockedSectors(currentSector.Track);
					break;
			}
		}

		private void LblTramNumber_MouseDown(object sender, MouseEventArgs e)
		{
			Label lblTramNumber = (Label)sender;
			Panel sectorPanel = (Panel)lblTramNumber.Parent;

			
			ShowContextMenu(e, sectorPanel);
			if (e.Button != MouseButtons.Left) return;
			if (e.Clicks == 1)
				if (Permission.Check(user, Permission.Permissions.CanDragTrams))
					dragToTreeview(sectorPanel);
		}

		private void Pnl_MouseDown(object sender, MouseEventArgs e)
		{
			Panel sectorPanel = (Panel)sender;
			ShowContextMenu(e, sectorPanel);

			if (e.Button != MouseButtons.Left) return;

			if (e.Clicks == 1)
				if (Permission.Check(user, Permission.Permissions.CanDragTrams))
					dragToTreeview(sectorPanel);
		}

		private void Roundbutton_Click(object sender, EventArgs e)
		{
			Button s = (Button)sender;
			Track t = Tracks.Find(x => x.TrackNumber == int.Parse(s.Text));

			TrackHandler(this, t, HandlerStatus.Show);
		}

		private bool canDragTram(Tram tram)
		{
			Sector currentSector = tram.Sector;

			if ((Sectors.IndexOf(currentSector) - 1 < 0 || (Sectors.IndexOf(currentSector) + 1 >= Sectors.Count)))
				return true;

			Sector previousSector = Sectors[(Sectors.IndexOf(currentSector) - 1)];
			Sector nextSector = Sectors[(Sectors.IndexOf(currentSector) + 1)];

			if ((previousSector.ListedTram != null || !previousSector.Enabled) && (nextSector.ListedTram != null || !nextSector.Enabled))
				return false;
			else
				return true;
		}

		private Label getDragLabel(Sector s)
		{
			lbl.Text = s.ListedTram.Number.ToString();

			switch (s.ListedTram.TramState)
			{
				case Tram.State.Ok:
					lbl.Image = Properties.Resources.TRAM_NOR;
					break;
				case Tram.State.Dirty:
					lbl.Image = Properties.Resources.TRAM_SCH;
					break;
				case Tram.State.Reparation:
					lbl.Image = Properties.Resources.TRAM_REP;
					break;
				case Tram.State.ReparationDirty:
					lbl.Image = Properties.Resources.TRAM_SRE;
					break;
				default:
					break;
			}

			return lbl;
		}

	
		private Color GetColor(Tram.State state, Sector s, Label lblTramNumber, Panel pnl)
		{
			Color panelColor = Color.Gray;
			if (!s.Enabled)
			{
				pnl.BackgroundImage = resizeImage(Properties.Resources.blocked, pnl.Size.Width, pnl.Size.Height);
				lblTramNumber.Text = "";
				return panelColor;
			}
			if (!(CurrentTrack.Enabled))
			{
				pnl.BackgroundImage = resizeImage(Properties.Resources.blocked, pnl.Size.Width, pnl.Size.Height);
				pnl.Enabled = false;
				lblTramNumber.Text = "";
				return panelColor;
			}

			if (s.ListedTram != null)
			{
				switch (s.ListedTram.TramState)
				{
					case Tram.State.Ok:
						if (state == Tram.State.Ok)
						{
							panelColor = Color.FromArgb(92, 184, 92);
						}
						else
						{
							lblTramNumber.ForeColor = Color.FromArgb(10, 80, 80, 80);
							panelColor = Color.FromArgb(150, 120, 120, 120);
						}
						break;
					case Tram.State.Dirty:
						if (state == Tram.State.Ok || state == Tram.State.Dirty)
						{
							panelColor = Color.FromArgb(51, 122, 183);
						}
						else
						{
							lblTramNumber.ForeColor = Color.FromArgb(10, 80, 80, 80);
							panelColor = Color.FromArgb(150, 120, 120, 120);
						}
						break;
					case Tram.State.Reparation:
						if (state == Tram.State.Ok || state == Tram.State.Reparation)
						{
							panelColor = Color.FromArgb(217, 83, 79);
						}
						else
						{
							lblTramNumber.ForeColor = Color.FromArgb(10, 80, 80, 80);
							panelColor = Color.FromArgb(150, 120, 120, 120);
						}
						break;
					case Tram.State.ReparationDirty:
						panelColor = Color.FromArgb(240, 240, 173, 78);
						break;
				}
				return panelColor;
			}

			return Color.Gray;
		}
		public void UpdateSector(Sector s, bool enabled)
		{
			int i = 0;
			foreach (Sector se in Sectors)
			{
				if (se == s)
				{
					string pnlName = "Panel" + i.ToString();
					Panel sectorPanel = panel1.Controls.Find(pnlName, false).FirstOrDefault() as Panel;
					if (s.ListedTram != null)
					{
						switch (s.ListedTram.TramState)
						{
							case Tram.State.Ok:
								sectorPanel.BackColor = Color.FromArgb(92, 184, 92);
								break;
							case Tram.State.Dirty:
								sectorPanel.BackColor = Color.FromArgb(51, 122, 183);
								break;
							case Tram.State.Reparation:
								sectorPanel.BackColor = Color.FromArgb(217, 83, 79);
								break;
							case Tram.State.ReparationDirty:
								sectorPanel.BackColor = Color.FromArgb(1, 240, 173, 78);
								break;
						}
					}
					else
					{
						if (!enabled)
						{
							sectorPanel.BackgroundImage = resizeImage(Properties.Resources.blocked, sectorPanel.Width, sectorPanel.Height);
							Label tramLabel = sectorPanel.Controls.Find("lblNumber", false).FirstOrDefault() as Label;
							tramLabel.Text = "";
						}
						if (enabled)
						{
							sectorPanel.BackgroundImage = null;
						}
					}
				}
				i++;
			}
		}

		public void UpdateTrack()
		{
			Track t = Tracks.Find(x => x.ID == CurrentTrack.ID);
			if (!CurrentTrack.Enabled)
			{
				int i = 0;
				foreach (Sector se in t.Sectors)
				{
					string pnlName = "Panel" + i.ToString();
					Panel sectorPanel = panel1.Controls.Find(pnlName, false).FirstOrDefault() as Panel;
					sectorPanel.BackgroundImage = resizeImage(Properties.Resources.blocked, sectorPanel.Width, sectorPanel.Height);
					i++;
				}
			}
			else
			{
				int i = 0;
				foreach (Sector se in t.Sectors)
				{
					string pnlName = "Panel" + i.ToString();
					Panel sectorPanel = panel1.Controls.Find(pnlName, false).FirstOrDefault() as Panel;
					Label tramLabel = sectorPanel.Controls.Find("lblNumber", false).FirstOrDefault() as Label;
					sectorPanel.BackgroundImage = null;

					if (se.ListedTram != null)
					{
						sectorPanel.BackColor = GetColor(se.ListedTram.TramState, se, tramLabel, sectorPanel);
						tramLabel.Text = se.ListedTram.Number.ToString();
					}
					else
					{
						sectorPanel.BackColor = Color.Gray;
						tramLabel.Text = "";
					}
					i++;
				}
			}
			GetBlockedSectors(t);
		}

		private Bitmap resizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
		public void GetBlockedSectors(Track t)
		{
			RunBlockAlgorithm(t, false);
			RunBlockAlgorithm(t, true);
		}

		public void RunBlockAlgorithm(Track t, bool reversed)
		{
			int? startIndex = null;
			int? endIndex = null;

			List<Sector> tempSectors = new List<Sector>(t.Sectors);

			if (reversed)
				t.Sectors.Reverse();

			foreach (Sector currentSector in t.Sectors)
			{
				if ((currentSector.ListedTram != null || (!currentSector.Enabled && manuallyBlocked.Contains(currentSector))) && startIndex == null && endIndex == null)
					if (!reversed)
						startIndex = (t.Sectors.IndexOf(currentSector) + 1);
					else
						endIndex = (tempSectors.IndexOf(currentSector) - 1);
				else if ((currentSector.ListedTram != null || (!currentSector.Enabled && manuallyBlocked.Contains(currentSector))) && startIndex == null && endIndex != null && reversed)
				{
					startIndex = (tempSectors.IndexOf(currentSector) + 1);
				}
				else if ((currentSector.ListedTram != null || (!currentSector.Enabled && manuallyBlocked.Contains(currentSector))) && startIndex != null && endIndex == null && !reversed)
				{
					endIndex = (t.Sectors.IndexOf(currentSector) - 1);
				}

				else if (startIndex != null && endIndex != null)
				{
					for (int s = (int)startIndex; s <= endIndex; s++)
					{
						if (t.Sectors[s].ListedTram == null && !reversed)
							blockSector(t.Sectors[s], s, true);
					}

					if (!reversed)
					{
						startIndex = endIndex + 1;
						endIndex = null;
					}
					else
					{
						endIndex = startIndex - 1;
						startIndex = null;
					}
				}
			}
			if (endIndex != null & startIndex != null)
			{
				for (int s = (int)startIndex; s <= endIndex; s++)
				{
					if (t.Sectors[s].ListedTram == null && !reversed)
						blockSector(t.Sectors[s], s, true);
				}
			}
			if (startIndex == null || endIndex == null)
			{
				if (startIndex == null && endIndex == null)
				{
					for (int b = 0; b < t.Sectors.Count; b++)
					{
						if (t.Sectors[b].ListedTram != null && manuallyBlocked.Contains(t.Sectors[b]) && !reversed)
							blockSector(t.Sectors[b], b, false);
					}
				}
				else if (startIndex != null && !reversed)
				{
					for (int b = (int)startIndex; b < t.Sectors.Count; b++)
					{
						if (!reversed)
							blockSector(t.Sectors[b], b, false);
					}
				}
				else if (endIndex != null)
				{
					for (int b = (int)endIndex; b >= 0; b--)
					{
						blockSector(tempSectors[b], b, false);
					}
				}
			}

			if (reversed)
				t.Sectors.Reverse();
		}

		private void blockSector(Sector s, int i, bool blocked)
		{
			string pnlName = "Panel" + i.ToString();
			Panel sectorPanel = panel1.Controls.Find(pnlName, false).FirstOrDefault() as Panel;
			Label tramLabel = sectorPanel.Controls.Find("lblNumber", false).FirstOrDefault() as Label;

			if (manuallyBlocked.Contains(s)) return;

			if (blocked)
			{
				sectorPanel.BackgroundImage = resizeImage(Properties.Resources.blocked, sectorPanel.Width, sectorPanel.Height);
				tramLabel.Text = "";
				s.Enabled = false;
				if (s.ListedTram != null)
				{
					s.ListedTram.Sector = null;
					s.ListedTram = null;
				}
			}
			else if (!blocked)
			{
				sectorPanel.BackgroundImage = null;
				s.Enabled = true;
			}
		}

		private void ShowContextMenu(MouseEventArgs e, Panel sectorPanel)
		{
			if (e.Button == MouseButtons.Right)
			{
				Sector toBeChangedSector = Sectors[(int.Parse(Regex.Match(sectorPanel.Name, @"\d+").Value))];

				if (toBeChangedSector.ListedTram != null)
				{
					ContextMenu cm = new ContextMenu()
					{
						Tag = toBeChangedSector
					};
					MenuItem openTram = new MenuItem("Open Tram");
					MenuItem openSpoor = new MenuItem("Open Spoor");
					MenuItem reparatie = new MenuItem("Wacht op reparatie");
					MenuItem schoonmaken = new MenuItem("Wacht op schoonmaken");


					openTram.Click += UCTrackCluster_Click;
					openSpoor.Click += UCTrackCluster_Click;
					reparatie.Click += UCTrackCluster_Click;
					schoonmaken.Click += UCTrackCluster_Click;
					if (!Permission.Check(user, Permission.Permissions.CanEditTramNote))
						openTram.Enabled = false;
					if (!Permission.Check(user, Permission.Permissions.CanEditTrack))
						openSpoor.Enabled = false;
					if (!Permission.Check(user, Permission.Permissions.CanViewCleaningView))
						reparatie.Enabled = false;
					if (!Permission.Check(user, Permission.Permissions.CanViewReparationView))
						reparatie.Enabled = false;

					switch (toBeChangedSector.ListedTram.TramState)
					{
						case Tram.State.Dirty:
							schoonmaken.Checked = true;
							break;
						case Tram.State.Reparation:
							reparatie.Checked = true;
							break;
						case Tram.State.ReparationDirty:
							schoonmaken.Checked = true;
							reparatie.Checked = true;
							break;
					}
					cm.MenuItems.Add(openTram);
					cm.MenuItems.Add(openSpoor);
					cm.MenuItems.Add("-");
					cm.MenuItems.Add(reparatie);
					cm.MenuItems.Add(schoonmaken);

					cm.Show(sectorPanel, e.Location);
				}
				else
				{
					ContextMenu cm = new ContextMenu()
					{
						Tag = toBeChangedSector
					};
					MenuItem openSpoor = new MenuItem("Open Spoor");
					openSpoor.Click += UCTrackCluster_Click;
					if (!Permission.Check(user, Permission.Permissions.CanEditTrack))
						openSpoor.Enabled = false;

					MenuItem sector = new MenuItem("Blokkeer sector");
					sector.Click += UCTrackCluster_Click;
					if (!Permission.Check(user, Permission.Permissions.CanEditSector))
						sector.Enabled = false;
					if (!CurrentTrack.Enabled)
						sector.Enabled = false;


					if (toBeChangedSector.Enabled == false)
						sector.Checked = true;

					cm.MenuItems.Add(sector);
					cm.MenuItems.Add(openSpoor);
					cm.Show(sectorPanel, e.Location);
				}
			}
		}
		private void doubleClickTram(Panel sectorPanel)
		{
			Sector toBeChangedSector = Sectors[(int.Parse(Regex.Match(sectorPanel.Name, @"\d+").Value))];
			Label tramLabel = sectorPanel.Controls.Find("lblNumber", false).FirstOrDefault() as Label;

			if (!toBeChangedSector.Enabled) return;
			if (toBeChangedSector.ListedTram == null) return;

			TramHandler(this, toBeChangedSector.ListedTram, HandlerStatus.Show);
		}

		private void dragToTreeview(Panel sectorPanel)
		{
			Sector toBeChangedSector = Sectors[(int.Parse(Regex.Match(sectorPanel.Name, @"\d+").Value))];
			Label tramLabel = sectorPanel.Controls.Find("lblNumber", false).FirstOrDefault() as Label;
			int tempSectorId = 0;

			if (toBeChangedSector.ListedTram != null)
			{
				if (!canDragTram(toBeChangedSector.ListedTram)) return;
				tempSectorId = toBeChangedSector.ListedTram.Sector.ID;
			}
			else
				return;


			if (toBeChangedSector.ListedTram.TramState != state && state != Tram.State.Ok && toBeChangedSector.ListedTram.TramState != Tram.State.ReparationDirty) { return; }


			if (!toBeChangedSector.Enabled) return;

			if (DragDropLogic.DoDragDrop(getDragLabel(toBeChangedSector), this.ParentForm, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0), toBeChangedSector.ListedTram, 1.0f, DragDropEffects.Move))
			{
				sectorPanel.BackColor = Color.Gray;
				tramLabel.Text = string.Empty;
				if (tempSectorId == toBeChangedSector.ListedTram.Sector.ID)
					TramHandler(this, toBeChangedSector.ListedTram, HandlerStatus.Remove);
				else
				{
					toBeChangedSector.ListedTram = null;
					SectorHandler(this, toBeChangedSector, HandlerStatus.Update);
				}
				GetBlockedSectors(CurrentTrack);
			}
		}



	}
}
