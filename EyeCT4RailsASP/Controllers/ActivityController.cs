using EyeCT4RailsASP.ViewModels;
using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EyeCT4RailsASP.Controllers
{
    public class ActivityController : Controller
    {
		private Remise remise;

		//public ActivityController()
		//{
		//	remise = ((Remise)Session["Remise"]);
		//}

        // GET: Activity
        public ActionResult Index(byte id, DateTime? periodStart, DateTime? periodEnd)
        {
			remise = ((Remise)Session["Remise"]);
			// Check of de user is ingelogd
			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			remise = ((Remise)Session["Remise"]);
			Activity.Type type = (Activity.Type)id;
			DateTime start = periodStart != null ? (DateTime)periodStart : DateTime.Now.AddDays(-2);
			DateTime end = periodEnd != null ? (DateTime)periodEnd : DateTime.Now;

			var viewModel = new ActivityOverviewViewModel
			{
				ActivityType = type,
				PeriodStart = start,
				PeriodEnd = end
			};

			return LoadOverview(viewModel);
        }

		[HttpPost]
		public ActionResult LoadOverview(ActivityOverviewViewModel viewModel)
		{
			remise = ((Remise)Session["Remise"]);
			if (!ModelState.IsValid)
			{
				viewModel.Message = viewModel.Activities == null || viewModel.Activities.Count() == 0 ? "No results found" : "";
				viewModel.Message = viewModel.PeriodStart > viewModel.PeriodEnd ? "Start searchdate must be smaller than end searchdate" : viewModel.Message;
				return View("ActivityOverview", viewModel);
			}
			List<NotPeriodicActivity> activities = new List<NotPeriodicActivity>();

			foreach (Activity activivity in remise.TramRepos.ActivityRepo.Collection.Where(a => a.ActivityType == viewModel.ActivityType && a is NotPeriodicActivity).ToList().Where(ac => ((NotPeriodicActivity)ac).Date.Value.Date >= viewModel.PeriodStart && ((NotPeriodicActivity)ac).Date.Value.Date <= viewModel.PeriodEnd).ToList())
			{
				if (activivity is NotPeriodicActivity)
					activities.Add((NotPeriodicActivity)activivity);
			}

			viewModel = new ActivityOverviewViewModel(viewModel.PeriodStart, viewModel.PeriodEnd, viewModel.ActivityType, activities);

			// Return het viewModel met de juiste gegevens ingevuld
			return View("ActivityOverview", viewModel);
		}
    }
}