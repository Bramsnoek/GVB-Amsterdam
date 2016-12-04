using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public class ReservationMemoryContext : IGenericContext<Reservation>
    {
        public List<Reservation> Reservations { get; set; }
        public ReservationMemoryContext(bool useTestData = false)
        {
            Reservations = new List<Reservation>();
            if (useTestData)
            {
                //Reservations = null;
            }
        }
        public ExtendedObservableCollection<Reservation> Get()
        {
            return new ExtendedObservableCollection<Reservation>(Reservations);
        }

        public int Insert(Reservation reservation)
        {
            foreach (Reservation Reservation in Reservations)
            {
                if (Reservation.Track == reservation.Track)
                {
                    return 0;
                }
            }
            reservation.ID = Reservations.Count + 1;
            Reservations.Add(reservation);
            return reservation.ID;
        }

        public void Update(Reservation reservation)
        {
            foreach (Reservation Reservation in Reservations)
            {
                if (Reservation.ID == reservation.ID)
                {
                    Reservations.RemoveAt(Reservation.ID - 1);
                    Reservations.Insert(Reservation.ID - 1, reservation);
                }
            }
        }

        public void Remove(Reservation source)
        {
            throw new NotSupportedException();
        }
    }
}
