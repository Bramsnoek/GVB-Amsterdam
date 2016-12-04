using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using ExtendedObservableCollection;
using System.Threading;

namespace EyeCT4RailsBackend
{
	public sealed class Remise : ExtendedNotifyPropertyChanged
	{
		#region Enums
		public enum UpdateMode
		{
			Add,
			Update
		}
		#endregion

		#region Properties
		public User UserLoggedIn
		{
			get { return userLoggedIn; }
			set { SetField(this, ref userLoggedIn, value); }
		} // User logged in

		public bool InSimulation
		{
			get { return inSimulation; }
			set { SetField(this, ref inSimulation, value); }
		} // Bool to check if simulation mode is turned on
		  //public TrackHandler TrackHandler { get; set; }
		  //public RefreshAllHandler RefreshAllHandler { get; set; }
		public int ID
		{
			get { return id; }
			set { SetField(this, ref id, value); }
		}
		public string Name
		{
			get { return name; }
			set { SetField(this, ref name, value); }
		}
		public int LargeRepairJobsPerDay
		{
			get { return largeRepairJobsPerDay; }
			set { SetField(this, ref largeRepairJobsPerDay, value); }
		}
		public int SmallRepairJobsPerDay
		{
			get { return smallRepairJobsPerDay; }
			set { SetField(this, ref smallRepairJobsPerDay, value); }
		}
		public int LargeCleaningJobsPerDay
		{
			get { return largeCleaningJobsPerDay; }
			set { SetField(this, ref largeCleaningJobsPerDay, value); }
		}
		public int SmallCleaningJobsPerDay
		{
			get { return smallCleaningJobsPerDay; }
			set { SetField(this, ref smallCleaningJobsPerDay, value); }
		}
        public int LargeRepairJobsPerYear
        {
            get { return largeRepairJobsPerYear; }
            set { SetField(this, ref largeRepairJobsPerYear, value); }
        }
        public int SmallRepairJobsPerYear
        {
            get { return smallRepairJobsPerYear; }
            set { SetField(this, ref smallRepairJobsPerYear, value); }
        }
        public int LargeCleaningJobsPerYear
        {
            get { return largeCleaningJobsPerYear; }
            set { SetField(this, ref largeCleaningJobsPerYear, value); }
        }
        public int SmallCleaningJobsPerYear
        {
            get { return smallCleaningJobsPerYear; }
            set { SetField(this, ref smallCleaningJobsPerYear, value); }
        }
        #endregion

        #region Fields
        private User userLoggedIn;
		private int id;
		private string name;
		private bool inSimulation;
		private int largeRepairJobsPerDay;
		private int smallRepairJobsPerDay;
		private int largeCleaningJobsPerDay;
		private int smallCleaningJobsPerDay;

        private int largeRepairJobsPerYear;
        private int smallRepairJobsPerYear;
        private int largeCleaningJobsPerYear;
        private int smallCleaningJobsPerYear;

        public TrackRepository TrackRepos { get; set; }
		public ADUserRepository AdUserRepos { get; set; }
		public TramRepository TramRepos { get; set; }
        public RemiseRepository RemiseRepo { get; set; }
		public UserRepository UserRepo { get; set; }
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor to create new Remise class
		/// </summary>
		/// <param name="rfidSerialPort">SerialPort for RFID scanner</param>
		public Remise(User userLoggedIn, string rfidSerialPort = "")
		{
			UserLoggedIn = userLoggedIn;

			UpdateAll();
		}
		public Remise(int ID, string Name, int LargeRepairJobsPerDay, int SmallRepairJobsPerDay, int LargeCleaningJobsPerDay, int SmallCleaningJobsPerDay)
		{
			this.ID = ID;
			this.Name = Name;
			this.LargeRepairJobsPerDay = LargeRepairJobsPerDay;
			this.SmallRepairJobsPerDay = SmallRepairJobsPerDay;
			this.LargeCleaningJobsPerDay = LargeCleaningJobsPerDay;
			this.SmallCleaningJobsPerDay = SmallCleaningJobsPerDay;
		}
		public Remise()
		{
			UpdateAll();
		}
		#endregion

		#region Initial database load and databinding
		private void UpdateAll()
		{
			TrackRepos = new TrackRepository(new TrackOracleDBContext(), new SectorOracleDBContext(), new ReservationOracleDBContext(), new BlockedConnectionOracleDBContext());
			AdUserRepos = new ADUserRepository(new UserADContext(), new GroupADContext());
			UserRepo = new UserRepository(new UserOracleDBContext(), new GroupMemoryContext());
			
			TramRepos = new TramRepository(new TramOracleDBContext(), new ActivityOracleDBContext(), new ReservationOracleDBContext());
            RemiseRepo = new RemiseRepository(new RemiseOracleDBContext(), new ConfigOracleDBContext());

            name = RemiseRepo.RemiseRepo.Collection[0].name;
            LargeRepairJobsPerDay = RemiseRepo.RemiseRepo.Collection[0].LargeRepairJobsPerDay;
            SmallRepairJobsPerDay = RemiseRepo.RemiseRepo.Collection[0].SmallRepairJobsPerDay;
            LargeCleaningJobsPerDay = RemiseRepo.RemiseRepo.Collection[0].LargeCleaningJobsPerDay;
            SmallCleaningJobsPerDay = RemiseRepo.RemiseRepo.Collection[0].SmallCleaningJobsPerDay;

            LargeRepairJobsPerYear = RemiseRepo.ConfigRepo.Collection[0].LargeRepairJobsPerYear;
            SmallRepairJobsPerYear = RemiseRepo.ConfigRepo.Collection[0].SmallRepairJobsPerYear;
            LargeCleaningJobsPerYear = RemiseRepo.ConfigRepo.Collection[0].LargeCleaningJobsPerYear;
            SmallCleaningJobsPerYear = RemiseRepo.ConfigRepo.Collection[0].SmallCleaningJobsPerYear;

            foreach (Sector sector in TrackRepos.SectorRepo.Collection) // Bind tram to Sector AND bind trams to a sector
			{
				if (sector.ListedTram != null)
				{
					sector.ListedTram = TramRepos.TramRepo.Collection.First(x => x.ID == sector.ListedTram.ID);
					sector.ListedTram.Sector = sector;
				}	
			}
			foreach (Activity activity in TramRepos.ActivityRepo.Collection) // Bind Users to Activities
			{
				activity.PerformedBy = AdUserRepos.Users.Find(x => x.ID == activity.PerformedBy.ID);
			}

			foreach(Tram tram in TramRepos.TramRepo.Collection)
			{
				foreach (Reservation reservation in TrackRepos.ReservationRepo.Collection.Where(x => x.Tram.ID == tram.ID))
				{
					if (tram.Reservations == null)
						tram.Reservations = new ExtendedBindingList<Reservation>();
					tram.Reservations.Add(reservation);
					reservation.Tram = tram;
				}
			}

			


			UpdateTramStates();
            CheckExpiredReservations();
        }
		#endregion

		#region UpdateTramStates and Insert new activity if Periodic is expired
		/// <summary>
		/// Method to update all tramstates
		/// </summary>
		private void UpdateTramStates()
		{
			foreach (Tram tram in TramRepos.TramRepo.Collection.Where(t => t.Activities.Count > 0))
			{
				foreach (PeriodicActivity periodicActivity in tram.Activities.Where(a => a is PeriodicActivity))
				{
					List<Activity> lstAct = new List<Activity>();

					foreach (Activity activity in tram.Activities.Where(a => a is NotPeriodicActivity))
					{
						lstAct.Add(activity);
					}

					foreach (Activity notPeriodicActivity in lstAct)
					{
						NotPeriodicActivity notPeriodic = notPeriodicActivity as NotPeriodicActivity;
						if (notPeriodic.PeriodicActivity != null && notPeriodic.PeriodicActivity.ID == periodicActivity.ID && DateTime.Now.AddDays(-periodicActivity.Period) > notPeriodic.Date)
						{
							Activity newNotPeriodicActivity = new NotPeriodicActivity(0, null, periodicActivity.WorkNote, periodicActivity.ActivityType, periodicActivity.PerformedBy, "", tram, false);
							tram.Activities.Add(newNotPeriodicActivity);
						}
					}
				}
				ChangeTramState(tram);
			}
		}
        #endregion

        #region CheckExpiredReservations

        private void CheckExpiredReservations()
        {
            foreach(Reservation reservation in TrackRepos.ReservationRepo.Collection.Where(x => x.State == Reservation.ReservationState.Pending))
            {
                if(reservation.Date.Day < DateTime.Now.Day)
                {
                    reservation.State = Reservation.ReservationState.Canceled;
                }
            }
        }

        #endregion

        #region ChangeTramStateAfterLoadingAndDataBinding
        /// <summary>
        /// Method to update a specific tram to a state and merge it with activitystate and initial tramstate
        /// </summary>
        /// <param name="tram"></param>
        private void ChangeTramState(Tram tram)
		{
			bool foundOpenReparationTask = false;
			bool foundOpenCleaningTask = false;
			foreach (PeriodicActivity periodicActivity in tram.Activities.Where(a => a is PeriodicActivity))
			{
				List<Activity> lstAct = new List<Activity>();

				foreach (Activity activity in tram.Activities.Where(a => a is NotPeriodicActivity))
				{
					lstAct.Add(activity);
				}

				foreach (Activity notPeriodicActivity in lstAct)
				{
					string taskNaming = "";
					if (((NotPeriodicActivity)notPeriodicActivity).Date == null)
					{
						switch (notPeriodicActivity.ActivityType)
						{
							case Activity.Type.Reparation:
								foundOpenReparationTask = true;
								taskNaming = "reparatietaak";
								break;
							case Activity.Type.Cleaning:
								foundOpenCleaningTask = true;
								taskNaming = "schoonmaaktaak";
								break;
						}
						if (!((NotPeriodicActivity)notPeriodicActivity).MailSent)
						{
							string message = string.Format("{0}, vandaag staat er voor u een nieuwe {1} gepland voor:\nTram: {2}\nWerkzaamheden: {3}", notPeriodicActivity.PerformedBy.FirstName, taskNaming, tram.Number.ToString(), notPeriodicActivity.WorkNote);
							SendMail(notPeriodicActivity.PerformedBy, message, string.Format("Nieuwe {0}", taskNaming));
							((NotPeriodicActivity)notPeriodicActivity).MailSent = true;
						}
					}
				}
			}
			Tram.State tramStateBasedOnActivities = Tram.State.Ok;
			if (foundOpenReparationTask && foundOpenCleaningTask) tramStateBasedOnActivities = Tram.State.ReparationDirty;
			else if (foundOpenCleaningTask) tramStateBasedOnActivities = Tram.State.Dirty;
			else if (foundOpenReparationTask) tramStateBasedOnActivities = Tram.State.Reparation;
			else tramStateBasedOnActivities = Tram.State.Ok;
			tram.TramState = MergeTramState(tramStateBasedOnActivities, tram.TramState);
		}
		#endregion

		#region MergeTramState
		/// <summary>
		/// Merge tramstate with activitystate
		/// </summary>
		/// <param name="activityState"></param>
		/// <param name="tramState"></param>
		/// <returns></returns>
		private Tram.State MergeTramState(Tram.State activityState, Tram.State tramState)
		{
			int stateActivity = (int)activityState;
			int stateTram = (int)tramState;

			if (stateActivity == stateTram)
				return tramState;
			else if (stateActivity + stateTram >= 3)
				return Tram.State.ReparationDirty;
			else
				return (Tram.State)stateTram + stateActivity;
		}
		#endregion

		#region Filtered methods
		public IEnumerable<Tram> GetNotArrangedTrams()
		{
			return TramRepos.TramRepo.Collection.Where(t => t.Sector == null);
		}
		#endregion


		#region Verstuur mail functie
		/// <summary>
		/// Send mail
		/// </summary>
		public void SendMail<T>(T type, string mailMessage, string subject)
		{
			Mail mail = new Mail(mailMessage, subject);
			mail.Send(type);
		}
		#endregion

		#region Simulatiemodus
		///// <summary>
		///// Method to start simulation mode
		///// </summary>
		///// <param name="simulationOn">Boolean to start or stop the simulation mode</param>
		//public void PerformSimulation(bool simulationOn)
		//{
		//	if (simulationOn)
		//	{
		//		InSimulation = true;
		//		foreach (Tram t in Trams.FindAll(t => t.Sector != null))
		//		{
		//			t.Sector.ListedTram = null;
		//			t.Sector.Enabled = true;
		//			t.Sector = null;
		//		}
		//		RefreshAllHandler(this);
		//		tmrSimulation.Start();
		//	}
		//	else
		//	{
		//		InSimulation = false;
		//		tmrSimulation.Stop();
		//		UpdateAll();
		//		RefreshAllHandler(this);
		//	}
		//}

		//// Event handler for simulation mode
		//private void TmrSimulation_Tick(object sender, EventArgs e)
		//{
		//	Random random = new Random(Guid.NewGuid().GetHashCode());
		//	List<Track> tempTracks = new List<Track>();
		//	foreach (Track t in Tracks)
		//	{
		//		bool hasEmptySectors = false;
		//		foreach (Sector sector in t.Sectors.Where(s => s.Track.Enabled == true))
		//		{
		//			if (sector.ListedTram == null)
		//			{
		//				hasEmptySectors = true;
		//			}
		//		}
		//		if (hasEmptySectors)
		//		{
		//			tempTracks.Add(t);
		//		}
		//	}

		//	foreach (Tram t in Trams.FindAll(t => t.Sector == null))
		//	{
		//		try
		//		{
		//			Sector sector = tempTracks[random.Next(0, tempTracks.Count - 1)].Sectors.FindAll(s => s.ListedTram == null).FindAll(s => s.Enabled == true)[0];
		//			sector.ListedTram = t;
		//			t.Sector = sector;
		//			TrackHandler(this, t.Sector.Track, HandlerStatus.Update, true);
		//			break;
		//		}
		//		catch (System.ArgumentOutOfRangeException ex)
		//		{
		//			Console.WriteLine(ex.ToString());
		//		}
		//	}

		//}
		#endregion

		#region CheckMethods
            /// <summary>
            /// this function expexteds de ID of the sector that you want to block. The function will than return all the ID's of the sectors that it blocks.
            /// </summary>
            /// <param name="sectorID"></param>
            /// <returns></returns>
		public List<string> CheckBlockedConnection(int sectorID)
		{
            var blockedsector = TrackRepos.BlockedConnectionRepo.Collection.Where(s => s.SectorFrom.ID == sectorID);

            List<string> blockedsectors_id = new List<string>();

            foreach (var s in blockedsector)
            {
                foreach (var t in TrackRepos.TrackRepo.Collection)
                {
                    foreach (var st in t.Sectors)
                    {
                        if (st.ID == sectorID)
                        {
                            foreach (var sid in st.Track.Sectors)
                            {
                                blockedsectors_id.Add(sid.ID.ToString());
                            }
                        }
                    }
                }
            }

            return blockedsectors_id;
		}

		public bool CanReserveFor(Track track, DateTime date)
		{
            int CountReservationPerTrack = 0;
            foreach(Reservation reservation in track.Reservations.Where(x => x.State == Reservation.ReservationState.Pending && x.Date.Date == date.Date))
            {
               CountReservationPerTrack += 1;
            }

            if(CountReservationPerTrack < track.Sectors.Count)
            {
                return true;
            }            
            return false;
		}
        #endregion

        #region setLoggedInUser

        public void SetLoggedInUser(string username)
        {
            userLoggedIn = AdUserRepos.Users.Where(u => u.Username == username).SingleOrDefault();
			UserRepo.UserRepo.insertLogin(UserLoggedIn);
		}

        #endregion


        #region Checkactivities

        public bool Checkactivities(PeriodicActivity checkThis)
        {
            //als periode groter is dan 6 maanden dan in het groot anders klein.
            //check of het kan op deze dag.
            //per jaar is per tram
            int counter = 0;
            List<Tram> tramcounter = new List<Tram>();
            
            if(checkThis.Period < 180) //kleine
            {

                foreach (var a in TramRepos.ActivityRepo.Collection)
                {
                    if (a is NotPeriodicActivity)
                    {
                        if (((NotPeriodicActivity)a).Date != null && ((NotPeriodicActivity)a).PeriodicActivity != null)// slitsen voor tram
                        {
                            if ( ((DateTime)((NotPeriodicActivity)a).Date).ToString("dd") == DateTime.Now.ToString("dd") && a.ActivityType == checkThis.ActivityType && ((NotPeriodicActivity)a).PeriodicActivity.Period < 180 && tramcounter.Contains(a.Tram) == false )
                            {
                                tramcounter.Add(a.Tram);
                                counter++;
                                if (checkThis.ActivityType == Activity.Type.Cleaning)
                                {
                                    if (counter > smallCleaningJobsPerDay)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (counter > smallRepairJobsPerDay)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else //grote
            {
                foreach (var a in TramRepos.ActivityRepo.Collection)
                {
                    if (a is NotPeriodicActivity)
                    {
                        if (((NotPeriodicActivity)a).Date != null && ((NotPeriodicActivity)a).PeriodicActivity != null)// slitsen voor tram
                        {
                            if (((DateTime)((NotPeriodicActivity)a).Date).ToString("dd") == DateTime.Now.ToString("dd") && a.ActivityType == checkThis.ActivityType && ((NotPeriodicActivity)a).PeriodicActivity.Period >= 180 && tramcounter.Contains(a.Tram) == false)
                            {
                                tramcounter.Add(a.Tram);
                                counter++;
                                if (checkThis.ActivityType == Activity.Type.Cleaning)
                                {
                                    if (counter > largeCleaningJobsPerDay)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (counter > largeRepairJobsPerDay)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var act_temp = checkThis.Tram.Activities.ToList().FindAll(a => a is PeriodicActivity && a.Tram == checkThis.Tram);
            if (checkThis.Period > 180) //large
            {
                if (checkThis.ActivityType == Activity.Type.Reparation)
                {
                    if ((act_temp.FindAll(a => ((PeriodicActivity)a).Period >= 180)).Count() >= largeRepairJobsPerYear)
                    {
                        return false;
                    } 
                }
                else
                {
                    if ((act_temp.FindAll(a => ((PeriodicActivity)a).Period >= 180)).Count() >= largeCleaningJobsPerYear)
                    {
                        return false;
                    }
                }
                
            }
            else //small
            {
                if (checkThis.ActivityType == Activity.Type.Reparation)
                {
                    if ((act_temp.FindAll(a => ((PeriodicActivity)a).Period < 180)).Count() >= smallRepairJobsPerYear)
                    {
                        return false;
                    }
                }
                else
                {
                    if ((act_temp.FindAll(a => ((PeriodicActivity)a).Period < 180)).Count() >= smallCleaningJobsPerYear)
                    {
                        return false;
                    }
                }
            }


            return true;
        }

        #endregion
    }
}
