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
    public class ConfigOracleDBContext : IGenericContext<Configuration>
    {
        private OracleDatabase database;
        public ConfigOracleDBContext()
        {
            database = new OracleDatabase();
        }
        public ExtendedObservableCollection<Configuration> Get()
        {
            List<Configuration> configurations = new List<Configuration>();
            foreach (DataRow row in database.SelectData(new OracleCommand("SELECT * FROM MAX_MAINTENANCE")).Rows)
            {
                configurations.Add(new Configuration(
                    Convert.ToInt32(Convert.ToString(row["largerepairjobsperyear"])),
                    Convert.ToInt32(Convert.ToString(row["smallrepairjobsperyear"])),
                    Convert.ToInt32(Convert.ToString(row["largecleaningjobsperyear"])),
                    Convert.ToInt32(Convert.ToString(row["smallcleaningjobsperyear"]))
                    ));
            }

            return new ExtendedObservableCollection<Configuration>(configurations);
        }

        public int Insert(Configuration configuration)
        {
            throw new NotSupportedException();
        }

        public void Remove(Configuration configuration)
        {
            throw new NotSupportedException();
        }

        void IGenericContext<Configuration>.Update(Configuration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
