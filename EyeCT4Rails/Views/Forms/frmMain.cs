using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragDrop;

namespace EyeCT4Rails
{
	#region Delegates + public enum
	public enum HandlerStatus
	{
		Add,
		Update,
		Show,
		Remove
	}

	public delegate void TrackHandler(object sender, Track track, HandlerStatus handlerStatus, bool updateList = false);
	public delegate void SectorHandler(object sender, Sector sector, HandlerStatus handlerStatus);
	public delegate void TramHandler(object sender, Tram tram, HandlerStatus handlerStatus, int tabIndex = 0);
	public delegate void RefreshAllHandler(object sender);
	#endregion

	public partial class FrmMain : Form
	{
		#region Fields
		private event TrackHandler onTrackEvent;
		private event SectorHandler onSectorEvent;
		private event TramHandler onTramEvent;
		private event RefreshAllHandler onRefreshAllHandler;

		private Remise remise;
		private UCRemiseOverview ucRemiseOverview;
		private UCRepairOverview ucRepariationOverview;
		private UCCleaningOverview ucCleaningOverview;
		#endregion

		#region Constructor
		public FrmMain(User loggedInUser)
		{
			InitializeComponent();

			remise = new Remise(loggedInUser);

			List<NotPeriodicActivity> notPeriodicActivities = remise.Activities.Select(x => x as NotPeriodicActivity).ToList();
			notPeriodicActivities.RemoveAll(x => x == null);

			ucRemiseOverview = new UCRemiseOverview(remise.UserLoggedIn, remise.GetNotArrangedTrams(), remise.Tracks, 216);
			ucRepariationOverview = new UCRepairOverview(notPeriodicActivities);
			ucCleaningOverview = new UCCleaningOverview(notPeriodicActivities);

			onTrackEvent += FrmMain_onTrackEvent;
			onSectorEvent += FrmMain_onSectorEvent;
			onTramEvent += FrmMain_onTramEvent;
			onRefreshAllHandler += FrmMain_onRefreshAllHandler;

			remise.TrackHandler = new TrackHandler(onTrackEvent);
			remise.RefreshAllHandler = new RefreshAllHandler(onRefreshAllHandler);

			ucRemiseOverview.TrackHandler = new TrackHandler(onTrackEvent);
			ucRemiseOverview.SectorHandler = new SectorHandler(onSectorEvent);
			ucRemiseOverview.TramHandler = new TramHandler(onTramEvent);

			ucRepariationOverview.TramHandler = new TramHandler(onTramEvent);
			ucCleaningOverview.TramHandler = new TramHandler(onTramEvent);
		}
		#endregion

		#region Event Handlers
		private void FrmMain_Load(object sender, EventArgs e)
		{
			if (Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanEditFilters))
			{
				comFilter.SelectedIndex = 0; //Geen
			}
			else
			{
				if (Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewReparationView))
				{
					comFilter.SelectedIndex = 1; //Reparatie
				}
				else if (Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewCleaningView))
				{
					comFilter.SelectedIndex = 2; //Schoonmaak

				}
				else
				{
					comFilter.SelectedIndex = 0; //Geen	
				}

				comFilter.Enabled = false;
			}		
			
			comSearch.DataSource = remise.Trams;
			comSearch.Text = "";
			comMenu.SelectedIndex = 0;

			ucRemiseOverview.Dock = DockStyle.Fill;
			ucRepariationOverview.Dock = DockStyle.Fill;
			ucCleaningOverview.Dock = DockStyle.Fill;
			pnlMain.Controls.Add(ucRemiseOverview);

			this.GiveFeedback += new GiveFeedbackEventHandler(DragDropLogic.UpdateCursor);
			foreach (Control control in this.Controls)
			{
				control.AllowDrop = true;
			}

			this.DialogResult = DialogResult.OK;

			//Permissions
			menuItemUserManagement.Enabled = Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewUsermanagement);
			menuItemAddTrack.Enabled = Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanAddTracks);
			menuItemRunSimulation.Enabled = Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanRunSimulation);
			comFilter.Enabled = Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanEditFilters);
		}

		private void FrmMain_onTrackEvent(object sender, Track track, HandlerStatus handlerStatus, bool updateList = false)
		{
			switch (handlerStatus)
			{
				case HandlerStatus.Add:
					remise.EditTrack(track, Remise.UpdateMode.Add);
					ucRemiseOverview.AddTrack(track);
					break;

				case HandlerStatus.Update:
					remise.EditTrack(track, Remise.UpdateMode.Update);
					ucRemiseOverview.UpdateTrack(track, updateList);
					break;

				case HandlerStatus.Show:
					FrmTrackData frmTrackData = new FrmTrackData(track);
					if (frmTrackData.ShowDialog() == DialogResult.OK)
					{
						track = frmTrackData.Track;
						goto case HandlerStatus.Update;
					}
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(handlerStatus), handlerStatus, null);
			}
		}

		private void FrmMain_onSectorEvent(object sender, Sector sector, HandlerStatus handlerStatus)
		{
			switch (handlerStatus)
			{
				case HandlerStatus.Add:
					remise.EditSector(sector, Remise.UpdateMode.Add);
					break;

				case HandlerStatus.Update:
					remise.EditSector(sector, Remise.UpdateMode.Update);
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(handlerStatus), handlerStatus, null);
			}
		}

		private void FrmMain_onTramEvent(object sender, Tram tram, HandlerStatus handlerStatus, int tabIndex = 0)
		{
			if (tram == null) throw new ArgumentNullException();

			switch (handlerStatus)
			{
				//case HandlerStatus.Add:
				//	remise.EditTram(tram, Remise.UpdateMode.Add);
				//	break;

				case HandlerStatus.Update:
					remise.EditTram(tram, Remise.UpdateMode.Update);
					ucRemiseOverview.UpdateTram(tram);
					break;

				case HandlerStatus.Show:
					FrmTramData frmTramData = new FrmTramData(remise.UserLoggedIn, remise.Users, tram, tabIndex);
					if (frmTramData.ShowDialog() == DialogResult.OK)
					{
						tram = frmTramData.Tram;
						if (frmTramData.EditedActivities.Count > 0)
						{
							remise.CheckEditMode(frmTramData.EditedActivities, remise.EditActivity);
						}
						
						goto case HandlerStatus.Update;
					}
					break;

				case HandlerStatus.Remove:
					tram.Sector.ListedTram = null;
					tram.Sector = null;
					goto case HandlerStatus.Update;

				default:
					throw new ArgumentOutOfRangeException(nameof(handlerStatus), handlerStatus, null);
			}
		}

		private void FrmMain_onRefreshAllHandler(object sender)
		{
			ucRemiseOverview.RefreshMeAndSubs(remise.GetNotArrangedTrams(), remise.Tracks);
		}

		private void menuItemUserManagement_Click(object sender, EventArgs e)
		{
			FrmManageUsers frmManageUsers = new FrmManageUsers(remise.UserLoggedIn, remise.Users, remise.Groups);
			if (frmManageUsers.ShowDialog() == DialogResult.OK)
			{
				remise.CheckEditMode(frmManageUsers.EditedUsers, remise.EditUser);
			}
		}

		private void menuItemAddTrack_Click(object sender, EventArgs e)
		{
			FrmAddTrack frmAddTrack = new FrmAddTrack(remise.UserLoggedIn, remise.Tracks);
			if (frmAddTrack.ShowDialog() == DialogResult.OK)
			{
				onTrackEvent(this, frmAddTrack.Track, HandlerStatus.Add);
			}
		}

		private void menuItemRunSimulation_Click(object sender, EventArgs e)
		{
			remise.PerformSimulation(menuItemRunSimulation.Checked);
		}

		private void menuItemLogOut_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Retry;
			this.Close();
		}

		private void menuItemExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void comSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
			if (string.IsNullOrWhiteSpace(comSearch.Text))
			{
				MessageBox.Show("Het tramnummer kan niet leeg zijn!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (comSearch.SelectedItem == null)
			{
				MessageBox.Show("Het ingevoerde tramnummer bestaat niet!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			onTramEvent(sender, (Tram)comSearch.SelectedItem, HandlerStatus.Show);
		}

		private void comFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comFilter.SelectedIndex)
			{
				case 0: //Geen
					ucRemiseOverview.FilterView(Tram.State.Ok);
					break;
				case 1: //Reparatie
					ucRemiseOverview.FilterView(Tram.State.Reparation);
					break;
				case 2: //Schoonmaker
					ucRemiseOverview.FilterView(Tram.State.Dirty);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void comMenu_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<NotPeriodicActivity> notPeriodicActivities = remise.Activities.Select(x => x as NotPeriodicActivity).ToList();
			notPeriodicActivities.RemoveAll(x => x == null);

			pnlMain.Controls.Clear();

			switch (comMenu.SelectedIndex)
			{
				case -1: //Invalid permission
					comMenu.SelectedIndex = 0;
					MessageBox.Show("U heeft niet genoeg rechten om naar dit overzicht te gaan!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;

				case 0: //Remise
					pnlMain.Controls.Add(ucRemiseOverview);
					break;

				case 1: //Reparatie
					if (!Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewReparationView)) goto case -1;

					pnlMain.Controls.Add(ucRepariationOverview);
					ucRepariationOverview.UpdateTable(notPeriodicActivities);
					break;

				case 2: //Schoonmaak
					if (!Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewCleaningView)) goto case -1;

					pnlMain.Controls.Add(ucCleaningOverview);
					ucCleaningOverview.UpdateTable(notPeriodicActivities);
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		#endregion
	}
}