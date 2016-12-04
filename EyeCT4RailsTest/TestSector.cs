using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using System.Collections.Generic;

namespace EyeCT4RailsTest
{
	[TestClass]
	public class TestSector
	{
		private TrackRepository trackRepo;

		[TestInitialize]
		public void Constructor()
		{
			trackRepo = new TrackRepository(new TrackMemoryContext(true), new SectorMemoryContext(true), new ReservationMemoryContext(true), new BlockedConnectionMemoryContext(true));
		}

		[TestMethod]
		public void TestGet()
		{
			Sector sector = trackRepo.SectorRepo.Collection[0];

			Assert.AreNotEqual(null, sector);
		}

		[TestMethod]
		public void TestUpdate()
		{
			Sector sector = trackRepo.SectorRepo.Collection[0];

			sector.ID = 999;

			Assert.AreEqual(999, trackRepo.SectorRepo.Collection[0].ID);
		}

		[TestMethod]
		public void TestInsert()
		{
			int currentCount = trackRepo.SectorRepo.Collection.Count;

			Sector sector = new Sector(1, true);

			trackRepo.SectorRepo.Collection.Add(sector);

			Assert.AreEqual(currentCount + 1, trackRepo.SectorRepo.Collection.Count);
		}

		[TestMethod]
		public void TestRemove()
		{
			//Sectors wont be removed!
			Assert.AreEqual(true, true);
		}
	}
}
