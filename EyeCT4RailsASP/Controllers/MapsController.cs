using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EyeCT4RailsBackend;

namespace EyeCT4RailsASP.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public ActionResult Index()
        {
			Remise remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");
			List<Sector> maps = ((Remise)Session["Remise"]).TrackRepos.SectorRepo.Collection.ToList().FindAll(s => s.ListedTram != null && s.LAT != null && s.LNG != null && s.LAT != "" && s.LNG != "");
            return View(maps);
        }
    }
}