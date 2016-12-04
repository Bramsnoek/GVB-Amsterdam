using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using ExtendedObservableCollection;

namespace EyeCT4RailsTest
{
	[TestClass]
	public class TestTrack
	{
		[TestMethod]
		public void TestGet()
		{
			TrackRepository TrackRep = new TrackRepository(new TrackMemoryContext(true), new SectorMemoryContext(true), new ReservationMemoryContext(true), new BlockedConnectionMemoryContext(true));

			ExtendedObservableCollection<Track> Tracks1 = TrackRep.TrackRepo.Collection;
			List<Track> Tracks2 = TestData.GetTracks();
			foreach (Track track in Tracks1)
			{
				foreach (Track Track in Tracks2)
				{
					if (Tracks1.IndexOf(track) == Tracks2.IndexOf(Track))
					{
						Assert.AreEqual(track.ID, Track.ID);
						break;
					}
				}
			}
		}

		[TestMethod]
		public void TestInsert()
		{
			TrackRepository TrackRep = new TrackRepository(new TrackMemoryContext(true), new SectorMemoryContext(true), new ReservationMemoryContext(true), new BlockedConnectionMemoryContext(true));
			int CountTrackBefore = TrackRep.TrackRepo.Collection.Count;
			TrackRep.TrackRepo.Collection.Add(new Track(0, 31, null, true));
			Assert.AreEqual(CountTrackBefore + 1, TrackRep.TrackRepo.Collection.Count);
		}

		[TestMethod]
		public void TestUpdate()
		{
			TrackRepository TrackRep = new TrackRepository(new TrackMemoryContext(true), new SectorMemoryContext(true), new ReservationMemoryContext(true), new BlockedConnectionMemoryContext(true));

			string TestNote = "";
			foreach (Track track in TrackRep.TrackRepo.Collection)
			{
				if (track.TrackNumber == 11)
				{
					track.Note = "TestNote";
					break;
				}
			}
			foreach (Track track in TrackRep.TrackRepo.Collection)
			{
				if (track.TrackNumber == 11)
				{
					TestNote = track.Note;
					break;
				}
			}
			Assert.AreEqual("TestNote", TestNote);


			TestNote = "";
			foreach (Track track in TrackRep.TrackRepo.Collection)
			{
				if (track.TrackNumber == 31)
				{
					track.Note = "TestNote";
					break;
				}
			}
			foreach (Track track in TrackRep.TrackRepo.Collection)
			{
				if (track.TrackNumber == 31)
				{
					TestNote = track.Note;
					break;
				}
			}
			Assert.AreEqual("", TestNote);

			Assert.AreEqual(10, TrackRep.TrackRepo.Collection.Count);
		}


		[TestMethod]
		public void TestRemove()
		{
			TrackRepository TrackRep = new TrackRepository(new TrackMemoryContext(true), new SectorMemoryContext(true), new ReservationMemoryContext(true), new BlockedConnectionMemoryContext(true));

			int CountTracksBefore = TrackRep.TrackRepo.Collection.Count;
			TrackRep.TrackRepo.Collection.Remove(TrackRep.TrackRepo.Collection[0]);
			bool found = false;
			foreach(Track track in TrackRep.TrackRepo.Collection)
			{
				if(track.ID == 1)
				{
					found = true;
				}
			}
			Assert.IsFalse(found);
			Assert.AreEqual(CountTracksBefore - 1, TrackRep.TrackRepo.Collection.Count);
		}
	}
}
