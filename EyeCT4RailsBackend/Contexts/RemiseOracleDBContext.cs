using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public class RemiseOracleDBContext : IGenericContext<Remise>
    {
        OracleDatabase database;
        public RemiseOracleDBContext()
        {
            database = new OracleDatabase();
        }
        public ExtendedObservableCollection<Remise> Get()
        {
            List<Remise> remises = new List<Remise>();
            foreach (DataRow row in database.SelectData(new OracleCommand("SELECT * FROM REMISE")).Rows)
            {
                remises.Add(new Remise(
                    Convert.ToInt32(Convert.ToString(row["ID"])),
                    Convert.ToString(row["Name"]),
                    Convert.ToInt32(Convert.ToString(row["largerepairjobsperday"])),
                    Convert.ToInt32(Convert.ToString(row["smallrepairjobsperday"])),
                    Convert.ToInt32(Convert.ToString(row["largecleaningjobsperday"])),
                    Convert.ToInt32(Convert.ToString(row["smallcleaningjobsperday"]))
                    ));
            }
            return new ExtendedObservableCollection<Remise>(remises);
        }

        public int Insert(Remise remise)
        {
            throw new NotSupportedException();
        }

        public void Remove(Remise remise)
        {
            throw new NotSupportedException();
        }

        void IGenericContext<Remise>.Update(Remise remise)
        {
            throw new NotSupportedException();
        }
    }
}
