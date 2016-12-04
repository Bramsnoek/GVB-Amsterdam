using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public class TrackOracleDBContext : IGenericContext<Track>
	{
        private OracleDatabase database;
        public TrackOracleDBContext()
        {
            database = new OracleDatabase();
        }

        public ExtendedObservableCollection<Track> Get()
        {
            List<Track> Tracks = new List<Track>();

            Track t = null;

            foreach (DataRow row in database.SelectData(new OracleCommand(@"SELECT * FROM TRACK")).Rows)
            {
                t = new Track(int.Parse(row["ID"].ToString()), int.Parse(row["TRACKNUMBER"].ToString()), row["NOTE"].ToString(), Convert.ToBoolean(int.Parse(row["ENABLED"].ToString())));

                Tracks.Add(t);
            }
            return new ExtendedObservableCollection<Track>(Tracks);
        }

        public int Insert(Track track)
        {
			track.ID = database.CallFunction(new OracleCommand("INSERTTRACK"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
							{
							new CustomOracleParameter(OracleDbType.Int32, "TRACKNUMBER", track.TrackNumber),
                            new CustomOracleParameter(OracleDbType.Int32, "ENABLED", Convert.ToInt32(track.Enabled)),
                            new CustomOracleParameter(OracleDbType.Varchar2, "NOTE", track.Note),
							new CustomOracleParameter(OracleDbType.Int32, "INOUTTRACK", Convert.ToInt32(track.IsInOutTrack))
							});
			return track.ID;
        }

        public void Update(Track track)
        {
            database.InsertData(
                new OracleCommand("UPDATE TRACK SET TRACKNUMBER = :TrckNum, ENABLED = :Enbld, NOTE = :Note WHERE TRACKNUMBER = " + track.TrackNumber),
                    new OracleParameter[]
                        {
                            new OracleParameter("TrckNum", track.TrackNumber),
                            new OracleParameter("Enbld", Convert.ToInt32(track.Enabled)),
                            new OracleParameter("Note", track.Note)
                        });
        }

		public bool CheckExistingTrackNumber(int number)
        {
            foreach (DataRow row in database.SelectData(new OracleCommand(@"SELECT TRACKNUMBER FROM TRACK")).Rows)
            {
                if(number == int.Parse(row["TRACKNUMBER"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(Track track)
        {
            throw new NotSupportedException();
        }
    }
}
