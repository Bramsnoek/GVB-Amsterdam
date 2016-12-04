using ExtendedObservableCollection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace EyeCT4RailsBackend
{
	public class ActivityOracleDBContext : IGenericContext<Activity>
	{
		private OracleDatabase database;

		public ActivityOracleDBContext()
		{
			database = new OracleDatabase();
		}

		public ExtendedObservableCollection<Activity> Get()
		{
			ExtendedObservableCollection<Activity> activities = new ExtendedObservableCollection<Activity>();
			DataTable dataPeriodic = database.SelectData(new OracleCommand("SELECT * FROM P_Activity"));
			DataTable dataNotPeriodicActivities = database.SelectData(new OracleCommand("SELECT * FROM NP_Activity"));

			if (dataPeriodic != null)
			{
				foreach (DataRow row in dataPeriodic.Rows)
				{
					activities.Add(new PeriodicActivity(Convert.ToInt32(row["ID"]), row["Note"].ToString(), (Activity.Type)Convert.ToInt32(row["Type"]),
						new User(Convert.ToInt32(row["User_ID"])),
						PeriodConversion.Convert(Convert.ToInt32(row["Period"]), PeriodConversion.Name.Days), new Tram(Convert.ToInt32(row["Tram_ID"]))));
				}
			}

			if (dataNotPeriodicActivities != null)
			{
				foreach (DataRow row in dataNotPeriodicActivities.Rows)
				{
					PeriodicActivity p_activity = null;
					DateTime? activitydate = null;

					if (row["P_ACTIVITY_ID"] != DBNull.Value) p_activity = new PeriodicActivity(Convert.ToInt32(row["P_ACTIVITY_ID"].ToString()));
					if (row["ActivityDate"] != DBNull.Value) activitydate = Convert.ToDateTime(row["ActivityDate"].ToString());

					activities.Add(new NotPeriodicActivity(Convert.ToInt32(row["ID"]), activitydate, row["WorkNote"].ToString(),
							(Activity.Type)Convert.ToInt32(row["Type"]),
							new User(Convert.ToInt32(row["User_ID"])), row["Remark"].ToString(),
							p_activity, new Tram(Convert.ToInt32(row["Tram_ID"])), Convert.ToBoolean(row["Mail_Sent"])));
				}
			}

			return activities;
		}

		public int Insert(Activity activity)
		{
			switch (activity.GetType().Name)
			{
				case "PeriodicActivity":
					PeriodicActivity periodicActivity = (PeriodicActivity)activity;

					periodicActivity.ID = database.CallFunction(new OracleCommand("INSERTPActivity"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
						{
							new CustomOracleParameter(OracleDbType.Int32, "TramID", periodicActivity.Tram.ID),
							new CustomOracleParameter(OracleDbType.Int32, "UserID", periodicActivity.PerformedBy.ID),
							new CustomOracleParameter(OracleDbType.Int32, "Period", periodicActivity.Period),
							new CustomOracleParameter(OracleDbType.Int32, "Type", Convert.ToInt32(periodicActivity.ActivityType)),
							new CustomOracleParameter(OracleDbType.Varchar2, "Note", periodicActivity.WorkNote)
						});
					return periodicActivity.ID;

				case "NotPeriodicActivity":
					NotPeriodicActivity notPeriodicActivity = (NotPeriodicActivity)activity;

					if (notPeriodicActivity.PeriodicActivity == null) 
					{
						notPeriodicActivity.ID = database.CallFunction(new OracleCommand("INSERTNPActivity2"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
						{
							new CustomOracleParameter(OracleDbType.Int32, "TramID", notPeriodicActivity.Tram.ID),
							new CustomOracleParameter(OracleDbType.Int32, "UserID", notPeriodicActivity.PerformedBy.ID),
							new CustomOracleParameter(OracleDbType.Int32, "Type", Convert.ToInt32(notPeriodicActivity.ActivityType)),
							new CustomOracleParameter(OracleDbType.Date, "ActivityDate", notPeriodicActivity.Date),
							new CustomOracleParameter(OracleDbType.Varchar2, "WorkNote", notPeriodicActivity.WorkNote),
							new CustomOracleParameter(OracleDbType.Varchar2, "Remark", notPeriodicActivity.Remark),
							new CustomOracleParameter(OracleDbType.Int32, "Mail_Sent", Convert.ToInt32(notPeriodicActivity.MailSent))
						});
						return notPeriodicActivity.ID;
					}
					else
					{
						notPeriodicActivity.ID =  database.CallFunction(new OracleCommand("INSERTNPActivity"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
						{
							new CustomOracleParameter(OracleDbType.Int32, "TramID", notPeriodicActivity.Tram.ID),
							new CustomOracleParameter(OracleDbType.Int32, "UserID", notPeriodicActivity.PerformedBy.ID),
							new CustomOracleParameter(OracleDbType.Int32, "P_Activity_ID", notPeriodicActivity.PeriodicActivity.ID),
							new CustomOracleParameter(OracleDbType.Int32, "Type", Convert.ToInt32(notPeriodicActivity.ActivityType)),
							new CustomOracleParameter(OracleDbType.Date, "ActivityDate", notPeriodicActivity.Date),
							new CustomOracleParameter(OracleDbType.Varchar2, "WorkNote", notPeriodicActivity.WorkNote),
							new CustomOracleParameter(OracleDbType.Varchar2, "Remark", notPeriodicActivity.Remark),
							new CustomOracleParameter(OracleDbType.Int32, "Mail_Sent", Convert.ToInt32(notPeriodicActivity.MailSent))
						});
						return notPeriodicActivity.ID;
					}

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Update(Activity activity)
		{
			switch (activity.GetType().Name)
			{
				case "PeriodicActivity":
					PeriodicActivity periodicActivity = (PeriodicActivity)activity;

					database.InsertData(new OracleCommand("UPDATE P_Activity SET Tram_ID = :TramID, User_ID = :UserID, Period = :Period, Type = :Type, Note = :Note WHERE ID = :ID")
						, new OracleParameter[]
						{
							new OracleParameter("ID", periodicActivity.ID),
							new OracleParameter("TramID", periodicActivity.Tram.ID),
							new OracleParameter("UserID", periodicActivity.PerformedBy.ID),
							new OracleParameter("Period", periodicActivity.Period),
							new OracleParameter("Type", Convert.ToInt32(periodicActivity.ActivityType)),
							new OracleParameter("Note", periodicActivity.WorkNote)
						});
					break;

				case "NotPeriodicActivity":
					NotPeriodicActivity notPeriodicActivity = (NotPeriodicActivity)activity;

					if (notPeriodicActivity.PeriodicActivity == null)
					{
						database.InsertData(new OracleCommand("UPDATE NP_Activity SET Tram_ID = :TramID, User_ID = :UserID, Type = :Type, ActivityDate = :ActivityDate, WorkNote = :WorkNote, Remark = :Remark, Mail_Sent = :Mail_Sent WHERE ID = :ID")
						, new OracleParameter[]
						{
							new OracleParameter("ID", notPeriodicActivity.ID),
							new OracleParameter("TramID", notPeriodicActivity.Tram.ID),
							new OracleParameter("UserID", notPeriodicActivity.PerformedBy.ID),
							new OracleParameter("Type", Convert.ToInt32(notPeriodicActivity.ActivityType)),
							new OracleParameter("ActivityDate", notPeriodicActivity.Date),
							new OracleParameter("WorkNote", notPeriodicActivity.WorkNote),
							new OracleParameter("Remark", notPeriodicActivity.Remark),
							new OracleParameter("Mail_Sent", Convert.ToInt32(notPeriodicActivity.MailSent))
						});
						return;
					}
					else
					{
						database.InsertData(new OracleCommand("UPDATE NP_Activity SET Tram_ID = :TramID, User_ID = :UserID, P_Activity_ID = :P_Activity_ID, Type = :Type, ActivityDate = :ActivityDate, WorkNote = :WorkNote, Remark = :Remark, Mail_Sent = :Mail_Sent WHERE ID = :ID")
						, new OracleParameter[]
						{
							new OracleParameter("ID", notPeriodicActivity.ID),
							new OracleParameter("TramID", notPeriodicActivity.Tram.ID),
							new OracleParameter("UserID", notPeriodicActivity.PerformedBy.ID),
							new OracleParameter("P_Activity_ID", notPeriodicActivity.PeriodicActivity.ID),
							new OracleParameter("Type", Convert.ToInt32(notPeriodicActivity.ActivityType)),
							new OracleParameter("ActivityDate", notPeriodicActivity.Date),
							new OracleParameter("WorkNote", notPeriodicActivity.WorkNote),
							new OracleParameter("Remark", notPeriodicActivity.Remark),
							new OracleParameter("Mail_Sent", Convert.ToInt32(notPeriodicActivity.MailSent))
						});
						return;
					}

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Remove(Activity activity)
		{
			switch (activity.GetType().Name)
			{
				case "PeriodicActivity":
					PeriodicActivity periodicActivity = (PeriodicActivity)activity;

					database.InsertData(new OracleCommand("DROP * FROM P_Activity WHERE ID = :ID")
						, new OracleParameter[]
						{
							new OracleParameter("ID", periodicActivity.ID)
						});
					break;
				case "NotPeriodicActivity":
					NotPeriodicActivity notPeriodicActivity = (NotPeriodicActivity)activity;

					database.InsertData(new OracleCommand("DROP * FROM NP_Activity WHERE ID = :ID")
						, new OracleParameter[]
						{
							new OracleParameter("ID", notPeriodicActivity.ID),
						});
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}