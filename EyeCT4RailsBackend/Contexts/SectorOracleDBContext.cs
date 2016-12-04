using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
	public class SectorOracleDBContext : IGenericContext<Sector>
	{
		private OracleDatabase database;

		public SectorOracleDBContext()
		{
			database = new OracleDatabase();
		}
		public ExtendedObservableCollection<Sector> Get()
		{
			List<Sector> sectors = new List<Sector>();

			foreach (DataRow row in database.SelectData(new OracleCommand(@"SELECT * FROM SECTOR")).Rows)
			{
				Sector s = null;

				if (row["tram_id"] == DBNull.Value)
					s = new Sector(int.Parse(row["ID"].ToString()), new Track(int.Parse(row["track_id"].ToString())), Convert.ToBoolean(int.Parse(row["state"].ToString())), null, (row["LAT"].ToString()).Replace(",", "."), (row["LNG"].ToString()).Replace(",", "."));
				else
					s = new Sector(int.Parse(row["ID"].ToString()), new Track(int.Parse(row["track_id"].ToString())), Convert.ToBoolean(int.Parse(row["state"].ToString())), new Tram(int.Parse(row["tram_id"].ToString())), (row["LAT"].ToString()).Replace(",", "."), (row["LNG"].ToString()).Replace(",", "."));

				sectors.Add(s);
			}

			return new ExtendedObservableCollection<Sector>(sectors);
		}

		public int Insert(Sector sector)
		{
			sector.ID = database.CallFunction(new OracleCommand("InsertSector"), OracleDbType.Int16, "ReturnV",
				new CustomOracleParameter[] { new CustomOracleParameter(OracleDbType.Varchar2, "TRACK_ID", sector.Track.ID) });
			return sector.ID;
		}

		public void Update(Sector sector)
		{		
			if(sector.ListedTram != null)
			{
				database.InsertData(new OracleCommand("UPDATE SECTOR SET TRAM_ID = :tramid, STATE = :sectorState WHERE ID = :sectorid"),
				new OracleParameter[]
				{
					new OracleParameter("tramid", sector.ListedTram.ID),
					new OracleParameter("sectorState", Convert.ToInt32(sector.Enabled)),
					new OracleParameter("sectorid", sector.ID)
				});
			}
			else
			{
				database.InsertData(new OracleCommand("UPDATE SECTOR SET TRAM_ID = :tramid, STATE = :sectorState WHERE ID = :sectorid"),
				new OracleParameter[]
				{
					new OracleParameter("tramid", DBNull.Value),
					new OracleParameter("sectorState", Convert.ToInt32(sector.Enabled)),
					new OracleParameter("sectorid", sector.ID)
				});
			}
		}


		public void Remove(Sector sector)
		{
			throw new NotSupportedException();
		}
	}
}
