using ExtendedObservableCollection;
using System;
using System.ComponentModel;

namespace EyeCT4RailsBackend
{
	public abstract class Activity : ExtendedNotifyPropertyChanged, IModel, IEquatable<Activity>
	{
		#region Enums
		public enum Type
		{
			[Description("reparatietaak")]
			Reparation,
			[Description("schoonmaaktaak")]
			Cleaning
		}
		#endregion

		#region Properties
		public int ID
		{
			get { return id; }
			set { SetField(this, ref id, value); }
		}

		public string WorkNote
		{
			get { return workNote; }
			set { SetField(this, ref workNote, value); }
		}

		public Type ActivityType
		{
			get { return activityType; }
			set { SetField(this, ref activityType, value); }
		}

		public User PerformedBy
		{
			get { return performedBy; }
			set { SetField(this, ref performedBy, value); }
		}

		public Tram Tram
		{
			get { return tram; }
			set { SetField(this, ref tram, value); }
		}
		#endregion

		#region Fields
		private int id;
		private string workNote;
		private Type activityType;
		private User performedBy;
		private Tram tram;
		#endregion

		#region Constructors
		/// <summary>
		/// Baseconstructor voor Activity
		/// </summary>
		/// <param name="workNote">Werkomschrijving</param>
		/// <param name="activityType">Activiteitstype, Enum</param>
		/// <param name="performedBy">Uitgevoerd door of gepland voor</param>
		public Activity(int id, string workNote, Type activityType, User performedBy, Tram tram)
		{
			ID = id;
			WorkNote = workNote;
			ActivityType = activityType;
			PerformedBy = performedBy;
			Tram = tram;
		}

		public Activity(int id)
		{
			ID = id;
		}
		#endregion

		#region Methods
		public bool Equals(Activity other)
		{
			if (other == null) return false;

			if (ID == other.ID) return true;

			return false;
		}
		#endregion
	}

	public class NotPeriodicActivity : Activity
	{
		#region Properties
		public string Remark
		{
			get { return remark; }
			set { SetField(this, ref remark, value); }
		}

		public DateTime? Date
		{
			get { return date; }
			set { SetField(this, ref date, value); }
		}

		public PeriodicActivity PeriodicActivity
		{
			get { return periodicActivity; }
			set { SetField(this, ref periodicActivity, value); }
		}

		public bool MailSent
		{
			get { return mailSent; }
			set { SetField(this, ref mailSent, value); }
		}
		#endregion

		#region Fields
		private string remark;
		private DateTime? date;
		private PeriodicActivity periodicActivity;
		private bool mailSent;
		#endregion

		#region Constructors
		/// <summary>
		/// Aanmaken van een historische activiteit zonder een PeriodicActivity gekoppeld
		/// </summary>
		/// <param name="date"></param>
		/// <param name="workNote"></param>
		/// <param name="activityType"></param>
		/// <param name="performedBy"></param>
		/// <param name="remark"></param>
		/// <param name="id"></param>
		/// <param name="tram"></param>
		public NotPeriodicActivity(int id, DateTime? date, string workNote, Type activityType, User performedBy, string remark, Tram tram, bool mailSent) : base(id, workNote, activityType, performedBy, tram)
		{
			Initialize(remark, date, mailSent);
		}

		/// <summary>
		/// Aanmaken van een historische activiteit met een PeriodicActivity gekoppeld.
		/// </summary>
		/// <param name="date"></param>
		/// <param name="workNote"></param>
		/// <param name="activityType"></param>
		/// <param name="performedBy"></param>
		/// <param name="remark"></param>
		/// <param name="id"></param>
		/// <param name="tram"></param>
		/// <param name="periodicActivity"></param>
		public NotPeriodicActivity(int id, DateTime? date, string workNote, Type activityType, User performedBy, string remark, PeriodicActivity periodicActivity, Tram tram, bool mailSent)
			: base(id, workNote, activityType, performedBy, tram)
		{
			PeriodicActivity = periodicActivity;
			Initialize(remark, date, mailSent);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Method to initialize baseclass 
		/// </summary>
		private void Initialize(string remark, DateTime? date, bool mailSent = false)
		{
			Remark = remark;
			Date = date;
			MailSent = mailSent;
		}
		#endregion
	}

	public class PeriodicActivity : Activity
	{
		#region Properties
		public int Period
		{
			get { return period; }
			set { SetField(this, ref period, value); }
		}
		#endregion

		#region Fields
		private int period;
		#endregion

		#region Constuctors
		/// <summary>
		/// Constructor voor het aanmaken van een Periodieke activiteit
		/// </summary>
		/// <param name="date">Datum van de gebeurtenis</param>
		/// <param name="workNote">Werkomschrijving</param>
		/// <param name="activityType">Type activiteit</param>
		/// <param name="performedBy">Uitgevoerd door</param>
		/// <param name="period">Periode van de periodieke taken in aantal dagen</param>
		public PeriodicActivity(int id, string workNote, Type activityType, User performedBy, int period, Tram tram) : base(id, workNote, activityType, performedBy, tram)
		{
			Period = period;
		}

		public PeriodicActivity(int id) : base(id)
		{

		}
		#endregion
	}
}
