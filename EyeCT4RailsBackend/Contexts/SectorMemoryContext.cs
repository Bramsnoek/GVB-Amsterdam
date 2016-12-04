using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
	public class SectorMemoryContext : IGenericContext<Sector>
	{
		public List<Sector> Sectors { get; set; }

		public SectorMemoryContext(bool useTestData = false)
		{
			if (useTestData)
				Sectors = TestData.GetSectors();
			else
				Sectors = new List<Sector>();
		}
		public ExtendedObservableCollection<Sector> Get()
		{
			return new ExtendedObservableCollection<Sector>(Sectors);
		}

		public int Insert(Sector sector)
		{
			Sectors.Add(sector);
			return 1;
		}

		public void Update(Sector sector)
		{
			Sectors[Sectors.FindIndex(x => sector.ID == sector.ID)] = sector;
		}

		public void Remove(Sector sector)
		{
			throw new NotSupportedException();
		}
	}
}
