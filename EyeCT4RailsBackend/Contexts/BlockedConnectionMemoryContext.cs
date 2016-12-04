using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public class BlockedConnectionMemoryContext : IGenericContext<BlockedConnection>
    {
        public List<BlockedConnection> BlockedConnections { get; set; }
        public BlockedConnectionMemoryContext(bool useTestData = false)
        {
            BlockedConnections = new List<BlockedConnection>();
            if (useTestData)
            {
                BlockedConnections = new List<BlockedConnection>();
            }
        }
        public ExtendedObservableCollection<BlockedConnection> Get()
        {
            return new ExtendedObservableCollection<BlockedConnection>(BlockedConnections);
        }

        public int Insert(BlockedConnection blockedConnection)
        {
            throw new NotSupportedException();
        }

        public void Update(BlockedConnection blockedConnection)
        {
            throw new NotSupportedException();
        }

        public void Remove(BlockedConnection source)
        {
            throw new NotSupportedException();
        }
    }
}
