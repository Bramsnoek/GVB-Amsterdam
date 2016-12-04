using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsBackend
{
    public class ReservationOracleDBContext : IGenericContext<Reservation>
    {

        private OracleDatabase database;
        public ReservationOracleDBContext()
        {
            database = new OracleDatabase();
        }

        public ExtendedObservableCollection<Reservation> Get()
        {
            List<Reservation> Reservations = new List<Reservation>();

            Reservation r = null;
            Reservation.ReservationState State = 0;

            foreach (DataRow row in database.SelectData(new OracleCommand(@"SELECT * FROM Reservation")).Rows)
            {
                State = (Reservation.ReservationState)Convert.ToInt32((row["state"]).ToString());
                r = new Reservation(int.Parse(row["ID"].ToString()), new Track(int.Parse(row["track_id"].ToString())), new Tram(int.Parse(row["tram_id"].ToString())), DateTime.Parse((row["RESERVATIONDATE"].ToString())), State);

                Reservations.Add(r);
            }
            return new ExtendedObservableCollection<Reservation>(Reservations);
        }

        public int Insert(Reservation reservation)
        {
            reservation.ID = database.CallFunction(new OracleCommand("INSERTRESERVATION"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
                            {
                            new CustomOracleParameter(OracleDbType.Int32, "TRACK_ID", reservation.Track.ID),
                            new CustomOracleParameter(OracleDbType.Int32, "TRAM_ID", reservation.Tram.ID),
                            new CustomOracleParameter(OracleDbType.Date, "RESERVATIONDATE", reservation.Date),
                            new CustomOracleParameter(OracleDbType.Int32, "STATE", Convert.ToInt32(reservation.State))
                            });
			reservation.Tram.Reservations.Add(reservation);
			reservation.Track.Reservations.Add(reservation);
			return reservation.ID;
        }

        public void Update(Reservation reservation)
        {
            database.InsertData(
                new OracleCommand("UPDATE RESERVATION SET STATE = :vState WHERE ID = " + reservation.ID),
                    new OracleParameter[]
                        {
                            new OracleParameter("vState", Convert.ToInt32(reservation.State))
                        });
        }

        public void Remove(Reservation reservation)
        {
            throw new NotSupportedException();
        }
    }
}
