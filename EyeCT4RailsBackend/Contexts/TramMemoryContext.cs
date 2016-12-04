using System;
using System.Collections.Generic;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public class TramMemoryContext : IGenericContext<Tram>
	{
        //fields
        public List<Tram> Trams { get; set; }
		//constructor
		public TramMemoryContext(bool useTestData = false)
		{
            if (useTestData)
            {
                Trams = TestData.GetTrams();
            }
            else
            {
                Trams = new List<Tram>();
            } 
		}

        public int Insert(Tram tram)
        {
            foreach (Tram testtram in Trams)
            {
                if (testtram.Number == tram.Number)
                {
                    return 0;
                }
            }
            tram.ID = Trams.Count + 1;
            Trams.Add(tram);
            return tram.ID;
        }

        public ExtendedObservableCollection<Tram> Get()
        {
            return new ExtendedObservableCollection<Tram>(Trams);
        }

        public void Remove(Tram tram)
        {
            throw new NotSupportedException();
        }

        void IGenericContext<Tram>.Update(Tram tram)
        {
            foreach (Tram testtram in Trams)
            {
                if (testtram.Number == tram.Number)
                {
                    Trams.Insert(1, tram);
                }
            }
        }
    }
}
