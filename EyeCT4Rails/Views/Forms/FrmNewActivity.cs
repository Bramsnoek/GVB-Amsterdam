using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace EyeCT4Rails
{
	public partial class FrmNewActivity : Form
	{
		#region Properties
		public List<Activity> NewActivities { get; set; }
		#endregion

		#region Fields
		private Activity.Type taskType;
		private List<User> users;
		private Tram tram;
		private User userLoggedIn;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor voor een nieuwe activity
		/// </summary>
		/// <param name="activityType">Geef hier "schoonmaak" of "onderhoud" mee. Dit komt in de titel van het form te staan</param>
		public FrmNewActivity(Activity.Type taskType, List<User> users, Tram tram, User userLoggedIn)
		{
			InitializeComponent();

			this.taskType = taskType;
			switch (taskType)
			{
				case Activity.Type.Reparation:
					chkPeriodicTask.Enabled = Permission.Check(userLoggedIn, Permission.Permissions.CanCreateRecursiveReparationTask);
					if (Permission.Check(userLoggedIn, Permission.Permissions.CanViewUsersInReparationTaskDialog))
						this.users = users.FindAll(u=>u.Group.ID == 4 || u.Group.ID == 5);
					else
					{
						this.users = new List<User>();
						this.users.Add(userLoggedIn);
					}
						
					break;
				case Activity.Type.Cleaning:
					chkPeriodicTask.Enabled = Permission.Check(userLoggedIn, Permission.Permissions.CanCreateRecursiveCleanTask);
					if (Permission.Check(userLoggedIn, Permission.Permissions.CanViewUsersInCleanTaskDialog))
						this.users = users.FindAll(u => u.Group.ID == 6 || u.Group.ID == 7);
					else
					{
						this.users = new List<User>();
						this.users.Add(userLoggedIn);
					}
					break;
			}
			
			this.tram = tram;
			this.userLoggedIn = userLoggedIn;
			NewActivities = new List<Activity>();
		}
		#endregion

		#region Methods
		#region ValidateFields Method
		/// <summary>
		/// Methode om invoervelden te valideren op ingevuld
		/// </summary>
		/// <returns></returns>
		private bool validateFields()
		{
			if (chkPeriodicTask.Checked && txtWorkNote.Text != string.Empty && comPlannedFor.SelectedIndex != -1 && txtPeriodNumber.Text != string.Empty && (Convert.ToInt32(txtPeriodNumber.Text) > 0))
			{
				return true;
			}
			else if (!chkPeriodicTask.Checked && txtWorkNote.Text != string.Empty && comPlannedFor.SelectedIndex != -1)
			{
				return true;
			}
			return false;
		}
		#endregion
		#endregion

		#region EventHandlers
		#region FormLoadEvent
		private void FrmNewActivity_Load(object sender, EventArgs e)
		{
			foreach (Enum name in Enum.GetValues(typeof(PeriodConversion.Name)))
			{
				comPeriod.Items.Add(EnumDescriptionConverter.GetDescriptionFromEnum(name));
			}

			foreach (User user in users)
			{
				comPlannedFor.Items.Add(user);
			}

			comPeriod.SelectedIndex = 0;

			Text += EnumDescriptionConverter.GetDescriptionFromEnum(taskType);
			grbPeriodicTask.Text = EnumDescriptionConverter.GetDescriptionFromEnum(taskType);
		}
		#endregion
		#region CheckboxPeriodicTask
		private void chkPeriodicTask_CheckedChanged(object sender, System.EventArgs e)
		{
			grbPeriodicTask.Enabled = chkPeriodicTask.Checked;
			lblRemark.Enabled = !chkPeriodicTask.Checked;
			txtRemark.Enabled = !chkPeriodicTask.Checked;
		}
		#endregion
		#region BtnCancel
		private void btnAnnuleer_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		#endregion
		#region BtnSave
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (validateFields())
			{
				if (chkPeriodicTask.Checked) //dan is het een periodieke taak
				{
					NewActivities.Add(new PeriodicActivity(0, txtWorkNote.Text, taskType, (User)comPlannedFor.SelectedItem, PeriodConversion.Convert(Convert.ToInt32(txtPeriodNumber.Text), EnumDescriptionConverter.GetEnumFromDescription<PeriodConversion.Name>(comPeriod.Text)), tram));
					Close();
				}
				else //dan moet het een historische taak zijn
				{
					NewActivities.Add(new NotPeriodicActivity(0, DateTime.Now, txtWorkNote.Text, taskType, (User)comPlannedFor.SelectedItem, txtRemark.Text, tram, false));
					Close();
				}
			}
		}
		#endregion
		#endregion
	}
}
