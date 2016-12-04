using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EyeCT4Rails
{
	public partial class FrmTramData : Form
	{
		#region Enums
		private enum Filter
		{
			[Description("Alle")]
			All,
			[Description("Periodieke taken")]
			PeriodicActivities,
			[Description("Uitgevoerde taken")]
			NotPeriodicActivities
		}
		#endregion

		#region Properties
		public Tram Tram { get; private set; }
		public List<Activity> EditedActivities { get; set; }
		#endregion

		#region Fields
		private List<User> users;
		private User userLoggedIn;
		#endregion

		#region Constructor
		/// <summary>
		/// Tramdata Form openen
		/// </summary>
		/// <param name="UserLoggedIn">De ingelogde user</param>
		/// <param name="lstUsers">Lijst met alle gebruikers</param>
		/// <param name="tram">De tram waar details over geopend moeten worden</param>
		/// <param name="tabIndex">Tabindex, 0 = Algemeen, 1 = Schoonmaak, 2 = Reparatie</param>
		public FrmTramData(User userLoggedIn, List<User> users, Tram tram, int tabIndex = 0)
		{
			InitializeComponent();
			this.userLoggedIn = userLoggedIn;
			this.users = users;
			Tram = tram;
			tclTramData.SelectedIndex = tabIndex;
			EditedActivities = new List<Activity>();
		}
		#endregion

		#region Methods
		#region ShowNewActivityForm
		/// <summary>
		/// Laat scherm voor nieuwe activiteit in te plannen zien
		/// </summary>
		/// <param name="activityType">Type van de activiteit</param>
		private void ShowNewActivityForm(Activity.Type activityType)
		{
			FrmNewActivity newActivityForm = new FrmNewActivity(activityType, users, Tram, userLoggedIn);
			newActivityForm.ShowDialog();
			if (newActivityForm.DialogResult == DialogResult.OK)
			{
				EditedActivities.AddRange(newActivityForm.NewActivities);
				switch (activityType)
				{
					case Activity.Type.Reparation:
						foreach(Activity a in newActivityForm.NewActivities)
						{
							AddActivityToView(dgvReparation, a, Filter.All);
						}
						break;
					case Activity.Type.Cleaning:
						foreach(Activity a in newActivityForm.NewActivities)
						{
							AddActivityToView(dgvCleaning, a, Filter.All);
						}
						break;
				}
			}
		}
		#endregion
		#region SetTramStateMethod
		private void SetTramState()
		{
			bool cleaning = chkCleanState.Checked;
			bool reparation = chkReparationState.Checked;
			if (cleaning && reparation)
			{
				Tram.TramState = Tram.State.ReparationDirty;
			}
			else if (cleaning)
			{
				Tram.TramState = Tram.State.Dirty;
			}
			else if (reparation)
			{
				Tram.TramState = Tram.State.Reparation;
			}
			else
			{
				Tram.TramState = Tram.State.Ok;
			}
		}
		#endregion
		#region  StateCanChange
		private bool StateCanChange(Activity.Type type)
		{
			foreach (PeriodicActivity periodicActivity in Tram.Activities.FindAll(a => a is PeriodicActivity && a.ActivityType == type))
			{
				List<Activity> lstAct = Tram.Activities.FindAll(a => a is NotPeriodicActivity && a.ActivityType == type);
				foreach (Activity notPeriodicActivity in lstAct)
				{
					if (((NotPeriodicActivity)notPeriodicActivity).Date == null || EditedActivities.Exists(a => a is NotPeriodicActivity && a.ID == ((NotPeriodicActivity)notPeriodicActivity).ID))
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion
		#region LoadActivities
		private void LoadActivities(DataGridView dataGridView, Activity.Type type, Filter filter = Filter.All)
		{
			dataGridView.Rows.Clear();
			if (Tram.Activities != null)
			{
				foreach (Activity activity in Tram.Activities.FindAll(a => a.ActivityType == type))
				{
					Activity editedActivity = EditedActivities.Find(a => a.ID == activity.ID);
					if (editedActivity != null && editedActivity.GetType() == activity.GetType())
					{
						AddActivityToView(dataGridView, editedActivity, filter);
					}
					else
					{
						AddActivityToView(dataGridView, activity, filter);
					}
				}
				foreach (Activity activity in EditedActivities.FindAll(ea => ea.ID == 0))
				{
					AddActivityToView(dataGridView, activity, filter);
				}
			}
		}
		#endregion
		#region AddActivityToView
		private void AddActivityToView(DataGridView dataGridView, Activity activity, Filter filter)
		{
			string[] periodNameDescription = EnumDescriptionConverter.GetDescriptionStringList(typeof(PeriodConversion.Name));

			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.Tag = activity;
			dataGridViewRow.Resizable = DataGridViewTriState.False;

			if (activity is PeriodicActivity && (filter == Filter.PeriodicActivities || filter == Filter.All))
			{
				dataGridViewRow.DefaultCellStyle.BackColor = Color.LightBlue;
				PeriodicActivity periodicActivity = activity as PeriodicActivity;
				KeyValuePair<int, PeriodConversion.Name> period = PeriodConversion.ConvertBack(periodicActivity.Period);
				dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = period.Key });
				dataGridViewRow.Cells.Add(new DataGridViewComboBoxCell { Items = { periodNameDescription[0], periodNameDescription[1], periodNameDescription[2], periodNameDescription[3] }, Value = EnumDescriptionConverter.GetDescriptionFromEnum(period.Value) });
				dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = periodicActivity.WorkNote });
				if((Permission.Check(userLoggedIn,Permission.Permissions.CanViewUsersInCleanTaskDialog) && activity.ActivityType == Activity.Type.Cleaning) || (Permission.Check(userLoggedIn, Permission.Permissions.CanViewUsersInReparationTaskDialog) && activity.ActivityType == Activity.Type.Reparation))
				{
					dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = periodicActivity.PerformedBy.ToString() });
				}
				else
				{
					dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
				}
				
				dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = periodicActivity.ActivityType });
				dataGridView.Rows.Add(dataGridViewRow);
			}
			else if (activity is NotPeriodicActivity && (filter == Filter.NotPeriodicActivities || filter == Filter.All))
			{
				dataGridViewRow.DefaultCellStyle.BackColor = Color.LightYellow;
				NotPeriodicActivity notPeriodicActivity = activity as NotPeriodicActivity;
				if (notPeriodicActivity.Date == null) dataGridViewRow.DefaultCellStyle.BackColor = Color.OrangeRed;
				dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = notPeriodicActivity.Date.ToString() });
				dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = notPeriodicActivity.WorkNote });
				dataGridViewRow.Cells.Add(new DataGridViewCheckBoxCell { Value = notPeriodicActivity.Date <= DateTime.Now && notPeriodicActivity.Date != null ? true : false }); //checkboxState
				if ((Permission.Check(userLoggedIn, Permission.Permissions.CanViewUsersInCleanTaskDialog) && activity.ActivityType == Activity.Type.Cleaning) || (Permission.Check(userLoggedIn, Permission.Permissions.CanViewUsersInReparationTaskDialog) && activity.ActivityType == Activity.Type.Reparation))
				{
					dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = notPeriodicActivity.PerformedBy.ToString() });
				}
				else
				{
					dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
				}
				dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = notPeriodicActivity.Remark });
				dataGridView.Rows.Add(dataGridViewRow);
			}
		}
		#endregion
		#endregion

		#region EventHandlers
		#region FormLoadEvent
		private void FrmTramData_Load(object sender, EventArgs e)
		{
			//Permission Checks
			txtNote.Enabled = Permission.Check(userLoggedIn, Permission.Permissions.CanEditTramNote);
			if(!Permission.Check(userLoggedIn, Permission.Permissions.CanViewTabTramClean))
			{
				tclTramData.Controls.Remove(tpCleaning);
			}
			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanViewTabTramReparation))
			{
				tclTramData.Controls.Remove(tpMaintenance);
			}

			chkCleanState.Enabled = Permission.Check(userLoggedIn, Permission.Permissions.CanSetTramCleanState);
			chkReparationState.Enabled = Permission.Check(userLoggedIn, Permission.Permissions.CanSetTramReparationState);

			//Set TramData form title
			lblTramTrackInfo.Text = "Tram: " + Tram.Number;
			if (Tram.Sector != null)
			{
				lblTramTrackInfo.Text += " - Spoor: " + Tram.Sector.Track.TrackNumber;
			}
			txtNote.Text = Tram.Note;

			//SetInitialCheckBoxState for Tramstate
			chkCleanState.CheckedChanged -= chkCleanState_CheckedChanged;
			chkReparationState.CheckedChanged -= chkReparationState_CheckedChanged;
			chkCleanState.Checked = Tram.TramState == Tram.State.Dirty || Tram.TramState == Tram.State.ReparationDirty ? true : false;
			chkReparationState.Checked = Tram.TramState == Tram.State.Reparation || Tram.TramState == Tram.State.ReparationDirty ? true : false;
			chkCleanState.CheckedChanged += chkCleanState_CheckedChanged;
			chkReparationState.CheckedChanged += chkReparationState_CheckedChanged;

			//Initialize Filter choices
			comFilterClean.Items.AddRange(EnumDescriptionConverter.GetDescriptionStringList(typeof(Filter)));
			comFilterReparation.Items.AddRange(EnumDescriptionConverter.GetDescriptionStringList(typeof(Filter)));
			comFilterClean.SelectedIndex = 0;
			comFilterReparation.SelectedIndex = 0;
		}
		#endregion
		#region SaveButton
		private void btnSave_Click(object sender, EventArgs e)
		{
			Tram.Note = txtNote.Text;

			foreach (Activity activity in EditedActivities)
			{
				if(activity.ID == 0)
				{
					Tram.Activities.Add(activity);
				}
				else
				{
					Tram.Activities[Tram.Activities.FindIndex(a => activity.ID == a.ID && a.GetType() == activity.GetType())] = activity;
				}
			}
		}
		#endregion
		#region DataGridCellChanged
		private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(((DataGridView)sender).SelectedRows.Count > 0)
			{
				DataGridViewRow dgvr = ((DataGridView)sender).SelectedRows[0];
				Activity originalActivity = (Activity)((DataGridView)sender).SelectedRows[0].Tag;
				Activity editedActivity = null;

				if (originalActivity is PeriodicActivity)
				{
					editedActivity = new PeriodicActivity(
						originalActivity.ID,
						dgvr.Cells[2].Value.ToString(),
						originalActivity.ActivityType,
						originalActivity.PerformedBy,
						PeriodConversion.Convert(Convert.ToInt32(dgvr.Cells[0].Value),EnumDescriptionConverter.GetEnumFromDescription<PeriodConversion.Name>(((DataGridView)sender).SelectedRows[0].Cells[1].Value.ToString())),
						Tram);
				}
				else if (originalActivity is NotPeriodicActivity)
				{
					DateTime? date;
					if (dgvr.Cells[0].Value.ToString() == "" || dgvr.Cells[0].Value == null)
						date = null;
					else
						date = Convert.ToDateTime(dgvr.Cells[0].Value);
					string remark = "";
					if (dgvr.Cells[4].Value != null)
					{
						remark = dgvr.Cells[4].Value.ToString();
					}
					editedActivity = new NotPeriodicActivity(
						originalActivity.ID,
						date,
						dgvr.Cells[1].Value.ToString(),
						originalActivity.ActivityType,
						originalActivity.PerformedBy,
						remark,
						Tram,
						false
						);
					if((bool)dgvr.Cells[2].Value && ((NotPeriodicActivity)originalActivity).Date == null)
					{
						if(dgvr.Cells[4].Value.ToString() != "")
							((NotPeriodicActivity)editedActivity).Date = DateTime.Now;
						else
							MessageBox.Show("Vul een notitie in voordat u de taak afvinkt!");
					}
					else if (!(bool)dgvr.Cells[2].Value)
					{
						((NotPeriodicActivity)editedActivity).Date = null;
					}
				}

				if (EditedActivities.Exists(a=>a.ID == originalActivity.ID))
				{
					EditedActivities[EditedActivities.FindIndex(a => a.ID == originalActivity.ID)] = editedActivity;
				}
				else
				{
					EditedActivities.Add(editedActivity);
				}
				switch (originalActivity.ActivityType)
				{
					case Activity.Type.Reparation:
						LoadActivities(dgvReparation, originalActivity.ActivityType);
						break;
					case Activity.Type.Cleaning:
						LoadActivities(dgvCleaning, originalActivity.ActivityType);
						break;
				}
			}
		}
		#endregion
		#region FilterChanged
		private void comFilterClean_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadActivities(dgvCleaning, Activity.Type.Cleaning, EnumDescriptionConverter.GetEnumFromDescription<Filter>(comFilterClean.Text));
		}

		private void comFilterReparation_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadActivities(dgvReparation, Activity.Type.Reparation, EnumDescriptionConverter.GetEnumFromDescription<Filter>(comFilterReparation.Text));
		}
		#endregion
		#region CheckBoxTramStateChanged
		private void chkReparationState_CheckedChanged(object sender, EventArgs e)
		{
			chkReparationState.CheckedChanged -= chkReparationState_CheckedChanged;
			SetReparationCheckbox(true);
			chkReparationState.CheckedChanged += chkReparationState_CheckedChanged;
		}
		private void SetReparationCheckbox(bool showMessage = false)
		{
			if (!StateCanChange(Activity.Type.Reparation))
			{
				chkReparationState.Checked = true;
				if(showMessage)
					MessageBox.Show("De status van de tram kan niet worden gewijzigd, er staan nog reparatietaken open voor deze tram!");
			}
			SetTramState();
		}

		private void chkCleanState_CheckedChanged(object sender, EventArgs e)
		{
			chkCleanState.CheckedChanged -= chkCleanState_CheckedChanged;
			SetCleaningCheckbox(true);
			chkCleanState.CheckedChanged += chkCleanState_CheckedChanged;
		}

		private void SetCleaningCheckbox(bool showMessage = false)
		{
			if (!StateCanChange(Activity.Type.Cleaning))
			{
				chkCleanState.Checked = true;
				if (showMessage)
				{
					MessageBox.Show("De status van de tram kan niet worden gewijzigd, er staan nog schoonmaaktaken open voor deze tram!");
				}
			}
			SetTramState();
		}
		#endregion
		#region CancelButton
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion
		#region PlanNewActivityButtons
		private void btnPlanCleaning_Click(object sender, EventArgs e)
		{
			ShowNewActivityForm(Activity.Type.Cleaning);
		}

		private void btnPlanMaintenance_Click(object sender, EventArgs e)
		{
			ShowNewActivityForm(Activity.Type.Reparation);
		}
		#endregion
		#endregion
	}
}
