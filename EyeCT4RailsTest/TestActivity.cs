using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using ExtendedObservableCollection;
using System.Linq;

namespace EyeCT4RailsTest
{
	[TestClass]
	public class TestActivity
	{
		private TramRepository activityRepo;
		private Tram tram;
		private PeriodicActivity periodicActivity;

		[TestInitialize]
		public void TestInitialize()
		{
			activityRepo = new TramRepository(new TramMemoryContext(true), new ActivityMemoryContext(true), new ReservationMemoryContext(true));
			tram = TestData.GetTrams()[0];
			periodicActivity = new PeriodicActivity(123, "Clean roof", Activity.Type.Cleaning, TestData.GetUsers()[0], PeriodConversion.Convert(1, PeriodConversion.Name.Days), tram);
		}

		[TestMethod]
		public void TestGet()
		{
            ExtendedObservableCollection<Activity> repoActivitiesIn = activityRepo.ActivityRepo.Collection;
			List<Activity> testActivities = TestData.GetActivities();

			for (int i = 0; i < repoActivitiesIn.Count; i++)
			{
				Assert.IsTrue(testActivities[i].Equals(repoActivitiesIn[i]));
			}
		}

		//[TestMethod]
		//public void TestInsert()
		//{

		//	Assert.IsTrue(activityRepo.Insert(periodicActivity) > TestData.GetPeriodicActivities().Count);
		//}
		 
		//[TestMethod]
		//public void TestUpdate()
		//{
		//	Assert.IsTrue(activityRepo.Insert(periodicActivity) > TestData.GetPeriodicActivities().Count);
		//	periodicActivity.Period = PeriodConversion.Convert(2, PeriodConversion.Name.Days);
		//	Assert.IsTrue(activityRepo.Update(periodicActivity));
		//}

		//[TestMethod]
		//public void TestRemove()
		//{
		//	Assert.IsTrue(activityRepo.Insert(periodicActivity) > TestData.GetPeriodicActivities().Count);
		//	Assert.IsTrue(activityRepo.Remove(periodicActivity));
		//}
	}
}
