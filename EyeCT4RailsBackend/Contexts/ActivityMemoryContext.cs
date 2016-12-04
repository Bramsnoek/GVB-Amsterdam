using System;
using System.Collections.Generic;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
	public class ActivityMemoryContext : IGenericContext<Activity>
	{
		private List<PeriodicActivity> PeriodicActivity;
		private List<NotPeriodicActivity> NotPeriodicActivities;

		public ActivityMemoryContext(bool useTestData = false)
		{
			if (useTestData)
			{
				PeriodicActivity = TestData.GetPeriodicActivities();
				NotPeriodicActivities = TestData.GetNotPeriodicActivities();
			}
			else
			{
				PeriodicActivity = new List<PeriodicActivity>();
				NotPeriodicActivities = new List<NotPeriodicActivity>();
			}
		}

		public ExtendedObservableCollection<Activity> Get()
		{
			ExtendedObservableCollection<Activity> activities = new ExtendedObservableCollection<Activity>();

			foreach (Activity activity in PeriodicActivity)
			{
				activities.Add(activity);
			}

			foreach (Activity activity in NotPeriodicActivities)
			{
				activities.Add(activity);
			}

			return activities;
		}

		public int Insert(Activity activity)
		{
			switch (activity.GetType().Name)
			{
				case "PeriodicActivity":
					PeriodicActivity periodicActivity = (PeriodicActivity)activity;
					PeriodicActivity.Add(periodicActivity);
					return PeriodicActivity.Count + 1;

				case "NotPeriodicActivity":
					NotPeriodicActivity notPeriodicActivity = (NotPeriodicActivity)activity;
					NotPeriodicActivities.Add(notPeriodicActivity);
					return NotPeriodicActivities.Count + 1;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Update(Activity activity)
		{
			switch (activity.GetType().Name)
			{
				case "PeriodicActivity":
					PeriodicActivity periodicActivity = (PeriodicActivity)activity;
					PeriodicActivity[PeriodicActivity.FindIndex(periodicActivityDB => periodicActivity.ID == periodicActivityDB.ID)] = periodicActivity;
					return;

				case "NotPeriodicActivity":
					NotPeriodicActivity notPeriodicActivity = (NotPeriodicActivity)activity;
					NotPeriodicActivities[NotPeriodicActivities.FindIndex(notPeriodicActivityDB => notPeriodicActivity.ID == notPeriodicActivityDB.ID)] = notPeriodicActivity;
					return;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Remove(Activity activity)
		{
			switch (activity.GetType().Name)
			{
				case "PeriodicActivity":
					PeriodicActivity periodicActivity = (PeriodicActivity)activity;
					PeriodicActivity.Remove(periodicActivity);
					return;

				case "NotPeriodicActivity":
					NotPeriodicActivity notPeriodicActivity = (NotPeriodicActivity)activity;
					NotPeriodicActivities.Remove(notPeriodicActivity);
					return;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}