using System;
using System.Collections.Generic;
using ExtendedObservableCollection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
    public class BlockedConnection : ExtendedNotifyPropertyChanged, IModel
    {
        public int ID { get { return id; } set { SetField(this, ref id, value); } }
        public Sector SectorFrom { get { return sectorFrom; } set { SetField(this, ref sectorFrom, value); } }
        public Sector SectorTo { get { return sectorTo; } set { SetField(this, ref sectorTo, value); } }

        private int id;
        private Sector sectorFrom;
        private Sector sectorTo;

        public BlockedConnection(int id, Sector sectorFrom, Sector sectorTo)
        {
            this.ID = id;
            this.SectorFrom = sectorFrom;
            this.SectorTo = sectorTo;
        }
    }
}
