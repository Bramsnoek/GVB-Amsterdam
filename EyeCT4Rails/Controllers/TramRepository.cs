using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class TramRepository
	{
		public GenericRepository<Tram> TramRepo;
		public GenericRepository<Activity> ActivityRepo;

		public TramRepository(IGenericContext<Tram> tramContext, IGenericContext<Activity> activityContext, IGenericContext<Reservation> reservationContext)
		{
			TramRepo = new GenericRepository<Tram>(tramContext);
			ActivityRepo = new GenericRepository<Activity>(activityContext);

			foreach (Tram tram in TramRepo.Collection)
			{
				foreach (Activity activity in ActivityRepo.Collection.Where(x => x.Tram.ID == tram.ID))
				{
					tram.Activities.Add(activity);
					activity.Tram = tram;
				}
			}

			foreach (Activity activity in ActivityRepo.Collection)
			{
				if (activity is NotPeriodicActivity && ((NotPeriodicActivity)activity).PeriodicActivity != null)
				{
					int id = ((NotPeriodicActivity)activity).PeriodicActivity.ID;
					((NotPeriodicActivity)activity).PeriodicActivity = (PeriodicActivity)ActivityRepo.Collection.First(x => x.ID == id);
				}
			}

			TramRepo.EnableListener();
			ActivityRepo.EnableListener();
		}
	}
}
