using System;
using System.Collections.Generic;
using ExtendedObservableCollection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
    public class TrackMemoryContext : IGenericContext<Track>
	{
        public List<Track> Tracks { get; set; }

		public TrackMemoryContext(bool useTestData = false)
		{
			Tracks = new List<Track>();
			if (useTestData)
			{
				Tracks = TestData.GetTracks();
			}
		}

        public ExtendedObservableCollection<Track> Get()
        {
            return new ExtendedObservableCollection<Track>(Tracks);
        }

        public int Insert(Track track)
        {
            foreach (Track Track in Tracks)
            {
                if (Track.TrackNumber == track.TrackNumber)
                {
                    return 0;
                }
            }
            track.ID = Tracks.Count + 1;
            Tracks.Add(track);
            return track.ID;
        }

        public void Update(Track track)
        {
            foreach (Track Track in Tracks)
            {
                if (Track.ID == track.ID)
                {
                    Tracks.RemoveAt(Track.ID - 1);
                    Tracks.Insert(Track.ID-1, track);
					break;
                }
            }
        }

        public void Remove(Track track)
        {
            foreach (Track Track in Tracks)
            {
                if (Track.ID == track.ID)
                {
                    Tracks.RemoveAt(Track.ID - 1);
					break;
                }
            }
        }
    }
}
