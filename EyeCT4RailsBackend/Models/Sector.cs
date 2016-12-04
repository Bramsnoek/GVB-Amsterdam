using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
	public sealed class Sector : ExtendedNotifyPropertyChanged, IModel
	{
		private int id;
		private Track track;
		private bool enabled;
		private Tram listedTram;
        private string lat;
        private string lng;

        public Tram ListedTram
		{
			get { return listedTram; }
			set { SetField<Tram>(this, ref listedTram, value); }
		}

		public bool Enabled
		{
			get { return enabled; }
			set { SetField<bool>(this, ref enabled, value); }
		}

		public int ID
		{
			get { return id; }
			set { SetField<int>(this, ref id, value); }
		}

		public Track Track
		{
			get { return track; }
			set { SetField(this, ref track, value); }
		}

        public string LAT
        {
            get { return lat; }
            set { SetField(this, ref lat, value); }
        }

        public string LNG
        {
            get { return lng; }
            set { SetField(this, ref lng, value); }
        }

        public Sector(int id, bool enabled = true)
		{
			ID = id;
			Enabled = enabled;
		}

		public Sector(int id, Tram listedTram, bool enabled = true)
		{
			ID = id;
			Enabled = enabled;
			ListedTram = listedTram;
		}

        public Sector(int id, Track track, bool enabled = true, Tram listedTram = null, string lat = null, string lng = null)
        {
            ID = id;
            Enabled = enabled;
            ListedTram = listedTram;
            Track = track;
            LAT = lat;
            LNG = lng;
        }
    }
}