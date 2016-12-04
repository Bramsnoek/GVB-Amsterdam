using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExtendedObservableCollection;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsBackend
{
    public class BlockedConnectionOracleDBContext : IGenericContext<BlockedConnection>
    {

        private OracleDatabase database;
        public BlockedConnectionOracleDBContext()
        {
            database = new OracleDatabase();
        }

        public ExtendedObservableCollection<BlockedConnection> Get()
        {
            List<BlockedConnection> BlockedConnections = new List<BlockedConnection>();

            BlockedConnection b;

			foreach (DataRow row in database.SelectData(new OracleCommand(@"SELECT * FROM Blocked_Connection")).Rows)
			{
				b = new BlockedConnection(int.Parse(row["ID"].ToString()), new Sector(int.Parse(row["sector_id_from"].ToString())), new Sector(int.Parse(row["sector_id_to"].ToString())));

				BlockedConnections.Add(b);
			}
			return  new ExtendedObservableCollection<BlockedConnection>(BlockedConnections);
        }

        public int Insert(BlockedConnection blockedConnection)
        {
            throw new NotSupportedException();
        }

        public void Update(BlockedConnection blockedConnection)
        {
            throw new NotSupportedException();
        }

        public void Remove(BlockedConnection blockedConnection)
        {
            throw new NotSupportedException();
        }
    }
}
