using ExtendedObservableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class TrackRepository
	{
		public GenericRepository<Track> TrackRepo;
		public GenericRepository<Sector> SectorRepo;
		public GenericRepository<Reservation> ReservationRepo;
		public GenericRepository<BlockedConnection> BlockedConnectionRepo;

		public TrackRepository(IGenericContext<Track> trackContext, IGenericContext<Sector> sectorContext, IGenericContext<Reservation> reservationContext, IGenericContext<BlockedConnection> blockedConnectionContext)
		{
			TrackRepo = new GenericRepository<Track>(trackContext);
			SectorRepo = new GenericRepository<Sector>(sectorContext);
			ReservationRepo = new GenericRepository<Reservation>(reservationContext);
			BlockedConnectionRepo = new GenericRepository<BlockedConnection>(blockedConnectionContext);

			foreach (Track track in TrackRepo.Collection)
			{
				foreach (Sector sector in SectorRepo.Collection.Where(x => x.Track.ID == track.ID))
				{
					track.Sectors.Add(sector);
					sector.Track = track;
				}

				track.Reservations = new ExtendedBindingList<Reservation>(ReservationRepo.Collection.Where(x => x.Track.ID == track.ID).ToList());
			}

			foreach (Reservation reservation in ReservationRepo.Collection)
			{
				reservation.Track = TrackRepo.Collection.SingleOrDefault(x => x.ID == reservation.Track.ID);
			}

			TrackRepo.EnableListener();
			SectorRepo.EnableListener();
			ReservationRepo.EnableListener();
			BlockedConnectionRepo.EnableListener();
		}
	}
}
