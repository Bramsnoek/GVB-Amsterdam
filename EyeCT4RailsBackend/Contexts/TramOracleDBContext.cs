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
    public class TramOracleDBContext : IGenericContext<Tram>
	{
        private OracleDatabase database;
        /// <summary>
        /// Constructor for the database class
        /// </summary>
        public TramOracleDBContext()
        {
            database = new OracleDatabase();
        }

        public ExtendedObservableCollection<Tram> Get()
        {
            List<Tram> trams = new List<Tram>();
            foreach (DataRow row in database.SelectData(new OracleCommand("SELECT T.* FROM TRAM T")).Rows)
            {
                Tram t = null;

                if (row["note"] == null)
                {

                    t = new Tram(Convert.ToInt32(Convert.ToString((row["ID"]))),
								(Tram.Type)Convert.ToInt32(Convert.ToString(row["tramtype_ID"]))-1, 
                                (Tram.State)Convert.ToInt32(Convert.ToString(row["state"])),
                                Convert.ToInt32(Convert.ToString((row["tramnumber"]))), 
                                Convert.ToString(row["line_number"]), 
                                Convert.ToString(row["barcode"]), 
                                Convert.ToBoolean(Convert.ToInt32(Convert.ToString(row["conductor"]))));
                }
                else
                {
                    t = new Tram(Convert.ToInt32(Convert.ToString((row["ID"]))),
								(Tram.Type)Convert.ToInt32(Convert.ToString(row["tramtype_ID"]))-1, 
                                (Tram.State)Convert.ToInt32(Convert.ToString(row["state"])),
                                Convert.ToInt32(Convert.ToString((row["tramnumber"]))), 
                                Convert.ToString(row["line_number"]), 
                                Convert.ToString(row["barcode"]), 
                                Convert.ToBoolean(Convert.ToInt32(Convert.ToString(row["conductor"]))),
                                Convert.ToString(row["note"]));
                }
                trams.Add(t);
            }

            return new ExtendedObservableCollection<Tram>(trams);
        }

        public int Insert(Tram tram)
        {
            return database.CallFunction(new OracleCommand("INSERTTRAM"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
                    {
						new CustomOracleParameter(OracleDbType.Int32, "ID", tram.ID),
						new CustomOracleParameter(OracleDbType.Int32, "tramtype_ID", Convert.ToInt32(tram.TramType)+1),
						new CustomOracleParameter(OracleDbType.Varchar2, "barcode", tram.RfidCode),
						new CustomOracleParameter(OracleDbType.Int32, "tramnumber", tram.Number),
						new CustomOracleParameter(OracleDbType.Int32, "state", Convert.ToInt32(tram.TramState)),
						new CustomOracleParameter(OracleDbType.Varchar2, "line_number", Convert.ToInt32(tram.Line)),
						new CustomOracleParameter(OracleDbType.Int32,"conductor", Convert.ToBoolean(tram.HasConductor)),
						new CustomOracleParameter(OracleDbType.Varchar2, "note", tram.Note)
                    });
        }

        public void Remove(Tram tram)
        {
            throw new NotSupportedException();
        }

        void IGenericContext<Tram>.Update(Tram tram)
        {
            database.InsertData(
                new OracleCommand(
                    @"UPDATE TRAM SET state = :state, line_number = :line_number WHERE tramnumber = :tramnumber"),
                new OracleParameter[]
                {
                    new OracleParameter("state", Convert.ToInt32(tram.TramState)),
                    new OracleParameter("line_number", tram.Line),
                    new OracleParameter("tramnumber", tram.Number)
                });
        }
    }
}
