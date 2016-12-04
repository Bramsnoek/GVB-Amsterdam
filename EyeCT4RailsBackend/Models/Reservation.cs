using System;
using System.Collections.Generic;
using ExtendedObservableCollection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class Reservation : ExtendedNotifyPropertyChanged, IModel
	{
		public enum ReservationState
		{
			Pending,
			Done,
			Canceled
		}


		public int ID { get { return id; } set { SetField(this, ref id, value); } }
		public Track Track { get { return track; } set { SetField(this, ref track, value); } }
		public Tram Tram { get { return tram; } set { SetField(this, ref tram, value); } }
		public DateTime Date { get { return date; } set { SetField(this, ref date, value); } }
		public ReservationState State { get { return state; } set { SetField(this, ref state, value); } }

		private int id;
		private Track track;
		private Tram tram;
		private DateTime date;
		private ReservationState state;

		public Reservation(int ID, Track Track, Tram Tram, DateTime Date, ReservationState State)
		{
			this.ID = ID;
			this.Track = Track;
			this.Tram = Tram;
			this.Date = Date;
			this.State = State;
		}

		public Reservation(Track track, Tram tram)
		{
			this.Track = track;
			this.Tram = tram;
		}

		public Reservation()
		{
		}
	}
}
