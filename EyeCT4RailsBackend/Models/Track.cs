using System;
using System.Collections.Generic;
using ExtendedObservableCollection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class Track : ExtendedNotifyPropertyChanged, IModel, ICloneable
	{
		public int ID
        {
            get { return id; }
            set { SetField(this, ref id, value); }
        }

		public int TrackNumber
        {
            get { return trackNumber; }
            set { SetField(this, ref trackNumber, value); }
        }

		public bool Enabled
        {
            get { return enabled; }
            set { SetField(this, ref enabled, value); }
        }

		public string Note
        {
            get { return note; }
            set { SetField(this, ref note, value); }
        }

		public ExtendedBindingList<Reservation> Reservations
        {
            get { return reservations; }
            set { SetField(this, ref reservations, value); }
        }

		public ExtendedBindingList<Sector> Sectors
        {
            get { return sectors; }
            set { SetField(this, ref sectors, value); }
        }

        public bool IsInOutTrack
        {
            get { return isinouttrack; }
            set { SetField(this, ref isinouttrack, value); }
        }

        private int id;
		private int trackNumber;
		private bool enabled;
		private string note;
		private ExtendedBindingList<Reservation> reservations;
		private ExtendedBindingList<Sector> sectors;
        private bool isinouttrack;

		public Track(int id, int trackNumber, string note, ExtendedBindingList<Sector> sectors, bool enabled = true, bool isinouttrack = false)
		{
			ID = id;
			TrackNumber = trackNumber;
			Enabled = enabled;
			Note = note;
			Enabled = enabled;
			Sectors = sectors;
            IsInOutTrack = isinouttrack;
			reservations = new ExtendedBindingList<Reservation>();
		}

		public Track(int id, int trackNumber, string note, bool enabled = true, bool isinouttrack = false)
		{
			ID = id;
			TrackNumber = trackNumber;
			Enabled = enabled;
			Note = note;
			Sectors = new ExtendedBindingList<Sector>();
            IsInOutTrack = isinouttrack;
			reservations = new ExtendedBindingList<Reservation>();
		}

		public Track(int id, ExtendedBindingList<Sector> sectors)
		{
			ID = id;
			Sectors = sectors;
			reservations = new ExtendedBindingList<Reservation>();
		}

		public Track(int id)
		{
			ID = id;
			Sectors = new ExtendedBindingList<Sector>();
			reservations = new ExtendedBindingList<Reservation>();
		}

		public Track()
		{

		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
