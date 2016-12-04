using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{

    public class Tram : ExtendedNotifyPropertyChanged, IModel, IComparable<Tram>
    {
        //enums 
        public enum Type
        {
            Combino,
            ElevenG,
            DubbelKopCombino,
            TwelveG,
            OpleidingsTram
        }
        public enum State
        {
            Ok,
            Dirty,
            Reparation,
            ReparationDirty
        }

        //propertys
        public Type TramType
        {
            get { return tramType; }
            set { SetField(this, ref tramType, value); }
        }
        public State TramState
        {
            get { return tramState; }
            set { SetField(this, ref tramState, value); }
        }
        public int ID
        {
            get { return id; }
            set { SetField(this, ref id, value); }
        }
        public int Number
        {
            get { return number; }
            set { SetField(this, ref number, value); }
        }
        public string Line
        {
            get { return line; }
            set { SetField(this, ref line, value); }
        }
        public string RfidCode
        {
            get { return rfidCode; }
            set { SetField(this, ref rfidCode, value); }
        }
        public string Note
        {
            get { return note; }
            set { SetField(this, ref note, value); }
        }
        public bool HasConductor
        {
            get { return hasConducon; }
            set { SetField(this, ref hasConducon, value); }
        }
        public ExtendedBindingList<Reservation> Reservations
        {
            get { return reservations; }
            set { SetField(this, ref reservations, value); }
        }
        public ExtendedBindingList<Activity> Activities
        {
            get { return activities; }
            set { SetField(this, ref activities, value); }
        }
        public Sector Sector
        {
            get { return sector; }
            set { SetField(this, ref sector, value); }
        }
        //fields
        private Type tramType;
        private State tramState;
        private int id;
        private int number;
        private string line;
        private string rfidCode;
        private string note;
        private bool hasConducon;
        private ExtendedBindingList<Reservation> reservations;
        private ExtendedBindingList<Activity> activities;
        private Sector sector;

        //constructor
        public Tram(int id, Type tramType, State tramState, int number, string line, string rfidCode, bool hasConductor, string note)
        {
            constructor(id, tramType, tramState, number, line, rfidCode, hasConductor);
            Note = note;
			reservations = new ExtendedBindingList<Reservation>();
        }

        public Tram(int id, Type tramType, State tramState, int number, string line, string rfidCode, bool hasConductor)
        {
            constructor(id, tramType, tramState, number, line, rfidCode, hasConductor);
			reservations = new ExtendedBindingList<Reservation>();
		}

		public Tram(int id)
		{
			ID = id;
			reservations = new ExtendedBindingList<Reservation>();
		}

		//methods
        private void constructor(int id, Type tramType, State tramState, int number, string line, string rfidCode, bool hasConductor)
        {
            ID = id;
            TramType = tramType;
            TramState = tramState;
            Number = number;
            Line = line;
            RfidCode = rfidCode;
            HasConductor = hasConductor;
            Activities = new ExtendedBindingList<Activity>();
        }

        public override string ToString()
        {
            return Convert.ToString(Number);
        }

		public int CompareTo(Tram other)
		{
			return this.Number.CompareTo(other.Number);
		}
	}
}
