using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EyeCT4RailsBackend;
using EyeCT4RailsASP.ViewModels;
using ExtendedObservableCollection;

namespace EyeCT4RailsASP.Controllers
{
	public class TrackController : Controller
	{
		Remise remise;

		[HttpGet]
		public string Edit(Track track)
		{
			remise = (Remise)Session["Remise"];


			Track editedTrack = remise.TrackRepos.TrackRepo.Collection.ToList().Find(x => x.TrackNumber == track.TrackNumber);
			editedTrack.Enabled = track.Enabled;

			foreach (Sector sector in editedTrack.Sectors)
			{
				sector.Enabled = track.Enabled;
			}

			editedTrack.Note = track.Note;

			return "2";
		}

		public ActionResult New()
		{
			remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			return View("AddTrack");
		}


		public ActionResult Save(TrackFormViewModel trackViewModel)
		{
			remise = (Remise)Session["Remise"];

			// Check modelstate valid
			if (!ModelState.IsValid)
				return View("AddTrack", trackViewModel);

			Track track = null;

			// Check existing in database
			track = remise.TrackRepos.TrackRepo.Collection.SingleOrDefault(t => t.TrackNumber == trackViewModel.TrackNumber);
			if (track != null)
				return View("AddTrack", trackViewModel);

			// Check valid Tracknumber
			if (trackViewModel.TrackNumber < 1 || trackViewModel.TrackNumber > 999)
				return View("AddTrack", trackViewModel);

			// Create sectors for the new track
			List<Sector> Sectors = new List<Sector>();
			for (int i = 0; i < trackViewModel.SectorCount; i++)
			{
				Sectors.Add(new Sector(0));
			}

			// Create new track
			Track newTrack = new Track(0, Convert.ToInt16(trackViewModel.TrackNumber), trackViewModel.Note, new ExtendedBindingList<Sector>(Sectors), Convert.ToBoolean(trackViewModel.State), Convert.ToBoolean(trackViewModel.ConnectionTrack));
			remise.TrackRepos.TrackRepo.Collection.Add(newTrack);

			// Insert sectors in the DB
			foreach (Sector sector in newTrack.Sectors)
			{
				sector.Track = newTrack;
				remise.TrackRepos.SectorRepo.Collection.Add(sector);
			}

			// Ready, redirect to homepage
			return RedirectToAction("Index", "Home");
		}
	}
}