using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using ExtendedObservableCollection;
using System.Linq;

namespace EyeCT4RailsTest
{
    [TestClass]
    public class TestTram
    {
        private Tram tram;
        private TramRepository tramrepository;

        [TestMethod]
        public void TestUpdateState()
        {
            tram = new Tram(7225, Tram.Type.ElevenG, Tram.State.Dirty, 153, "62", "434a", false, "nog vies");

            tram.TramState = Tram.State.Ok;

            Assert.AreEqual(Tram.State.Ok, tram.TramState);
        }

        [TestMethod]
        public void TestUpdateLine()
        {
            tram = new Tram(7225, Tram.Type.ElevenG, Tram.State.Dirty, 153, "62", "434a", false, "nog vies");

            tram.Line = "9000";

            Assert.AreEqual("9000", tram.Line);
        }

        [TestMethod]
        public void TestGet()
        {
            tramrepository = new TramRepository(new TramMemoryContext(true), new ActivityMemoryContext(true), new ReservationMemoryContext(true));

            ExtendedObservableCollection<Tram> Trams1 = tramrepository.TramRepo.Collection;
            List<Tram> Trams2 = TestData.GetTrams();
            foreach (Tram tram in Trams1)
            {
                foreach (Tram Tram in Trams2)
                {
                    if (Trams1.IndexOf(tram) == Trams2.IndexOf(Tram))
                    {
                        Assert.AreEqual(tram.ID, Tram.ID);
                        break;
                    }
                }
            }
        }

        //[TestMethod]
        //public void TestInsert()
        //{
        //    tramrepository = new TramRepository(new TramMemoryContext(true), new ActivityMemoryContext(true), new ReservationMemoryContext(true));
        //    tramrepository.TramRepo.Collection.Add(new Tram(100, Tram.Type.ElevenG, Tram.State.Dirty, 167, "62", "43qa", false, "nog vies"));
        //    Assert.AreEqual(new Tram(100, Tram.Type.ElevenG, Tram.State.Dirty, 167, "62", "43qa", false, "nog vies").TramState, tramrepository.TramRepo.Collection.Single(t => t.ID == 7).TramState);
        //}

        //[TestMethod]
        //public void TestUpdate()
        //{
        //    tramrepository = new TramRepository(new TramMemoryContext(true), new ActivityMemoryContext(true), new ReservationMemoryContext(true));
        //    Assert.AreEqual(tramrepository.TramRepo.Collection[1].TramType, tramrepository.TramRepo.Collection[1].TramType = Tram.Type.OpleidingsTram);
            
        //}
    }
}
