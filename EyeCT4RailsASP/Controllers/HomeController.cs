using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EyeCT4RailsBackend;
using ExtendedObservableCollection;
using EyeCT4RailsASP.ViewModels;
using System.Web.Script.Services;
using System.Web.Services;

namespace EyeCT4RailsASP.Controllers
{
	public class HomeController : Controller
	{
		private List<Sector> manuallyBlocked;
		private bool loaded = false;

		public ActionResult Index()
		{
			manuallyBlocked = new List<Sector>();
			Session["Manual"] = manuallyBlocked;
			Remise remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			if (Session["Loaded"] != null)
				loaded = (bool)Session["Loaded"];


			if (!loaded)
			{
				loaded = true;
				Session["Loaded"] = loaded;
				if (!(Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanDragTrams)))
				{
					if (Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewCleaningView))
					{
						return RedirectToAction("Index", "Activity", new { id = 1 });
					}
					else if (Permission.Check(remise.UserLoggedIn, Permission.Permissions.CanViewReparationView))
					{
						return RedirectToAction("Index", "Activity", new { id = 0 });
					}
				}
			}

			return View();
		}

		public ActionResult TramView(int id)
		{
			Remise remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			return PartialView(remise.TramRepos.TramRepo.Collection.First((t) => t.Number == id));
		}

		public ActionResult Track(int id)
		{
			Remise remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			return PartialView(remise.TrackRepos.TrackRepo.Collection.First((t) => t.TrackNumber == id));
		}

		public ActionResult Reservation(int? track_id, int? tram_id)
		{
			Remise remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			ReservationFormViewModel reservationViewModel = null;
			if (track_id != null)
			{
				reservationViewModel = new ReservationFormViewModel(null, remise.TrackRepos.TrackRepo.Collection.ToList().Find((t) => t.ID == track_id).TrackNumber);
			}
			else if (tram_id != null)
			{
				reservationViewModel = new ReservationFormViewModel(remise.TramRepos.TramRepo.Collection.ToList().Find((t) => t.ID == tram_id).Number, null);
			}
			return PartialView(reservationViewModel);
		}

		public ActionResult TrackView(Track track)
		{
			Remise remise = (Remise)Session["Remise"];

			if (remise.UserLoggedIn == null)
				return RedirectToAction("Login", "Login");

			return PartialView(track);
		}

		[HttpPost]
		public bool UpdatePActivity(int activityID, int tramID, string username, bool isReparation, string worknote, string period)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find((t) => t.ID == tramID);
			User user = remise.AdUserRepos.Users.Find((u) => u.ToString() == username);
			Activity.Type activityType = Activity.Type.Reparation;
			PeriodicActivity pActivity;

			if (!isReparation)
			{
				activityType = Activity.Type.Cleaning;
			}

			if (activityID == -1)
			{
				pActivity = new PeriodicActivity(-1, worknote, activityType, user, Convert.ToInt32(period.Replace("dagen", "")), tram);

				if (remise.Checkactivities(pActivity))
				{
					tram.Activities.Add(pActivity);
					remise.TramRepos.ActivityRepo.Collection.Add(pActivity);
					return true;
				}
			}
			else
			{
				pActivity = (PeriodicActivity)remise.TramRepos.ActivityRepo.Collection.First((a) => a.ID == activityID);
				pActivity.Tram = tram;
				pActivity.PerformedBy = user;
				pActivity.WorkNote = worknote;
				pActivity.Period = Convert.ToInt32(period.Replace("dagen", ""));
				return true;
			}

			return false;
		}

		[HttpPost]
		public bool UpdateNPActivity(int activityID, int tramID, string username, bool isReparation, string worknote, string remark)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find((t) => t.ID == tramID);
			User user = remise.AdUserRepos.Users.Find((u) => u.ToString() == username);
			Activity.Type activityType = Activity.Type.Reparation;
			NotPeriodicActivity npActivity;

			if (!isReparation)
			{
				activityType = Activity.Type.Cleaning;
			}

			if (activityID == -1)
			{
				npActivity = new NotPeriodicActivity(-1, DateTime.Now, worknote, activityType, user, remark, tram, false);
				tram.Activities.Add(npActivity);
				remise.TramRepos.ActivityRepo.Collection.Add(npActivity);
				return true;
			}
			else
			{
				npActivity = (NotPeriodicActivity)remise.TramRepos.ActivityRepo.Collection.First((a) => a.ID == activityID);
				npActivity.Tram = tram;
				npActivity.PerformedBy = user;
				npActivity.WorkNote = worknote;
				npActivity.Remark = remark;
				return true;
			}
		}

		[HttpPost]
		public bool UpdateGeneralTram(int tramID, bool isDirty, bool isBroken, string note)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find((t) => t.ID == tramID);

			tram.Note = note;

			if (isDirty)
			{
				if (isBroken)
				{
					tram.TramState = Tram.State.ReparationDirty;
				}
				else
				{
					tram.TramState = Tram.State.Dirty;
				}
			}
			else if (isBroken)
			{
				tram.TramState = Tram.State.Reparation;
			}
			else
			{
				tram.TramState = Tram.State.Ok;
			}

			
			return true;
		}

		[HttpGet]
		public JsonResult GetUsers(int filter)
		{
			Remise remise = (Remise)Session["Remise"];
			List<string> usernames = new List<string>();

			switch (filter)
			{
				case 0:
					foreach (User user in remise.AdUserRepos.Users.Where(g => g.Group.ToString().Contains("Technici")))
					{
						usernames.Add(user.ToString());
					}
					break;
				case 1:
					foreach (User user in remise.AdUserRepos.Users.Where(g => g.Group.ToString().Contains("Schoonmaker")))
					{
						usernames.Add(user.ToString());
					}
					break;
			}

			return Json(usernames, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public string GetStateColor(int tramNumber)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find(x => x.Number == tramNumber);

			switch (tram.TramState)
			{
				case Tram.State.Ok:
					return "#5cb85c";
				case Tram.State.Dirty:
					return "#337ab7";
				case Tram.State.Reparation:
					return "#D2B48C";
				case Tram.State.ReparationDirty:
					return "#f0ad4e";
			}
			return "slategrey";
		}

		[HttpGet]
		public string ToggleSectorBlocked(int sectorID)
		{
			List<Sector> manuallyBlocked = (List<Sector>)Session["Manual"];
			Remise remise = (Remise)Session["Remise"];
			Sector sector = remise.TrackRepos.SectorRepo.Collection.ToList().Find(x => x.ID == sectorID);

			if (sector.Enabled)
			{
				sector.Enabled = false;
				manuallyBlocked.Add(sector);
				Session["Manual"] = manuallyBlocked;
				return "0";
			}
			sector.Enabled = true;
			manuallyBlocked.Remove(sector);
			Session["Manual"] = manuallyBlocked;
			return "1";
		}

		[HttpGet]
		public string IsSectorBlocked(int sectorID)
		{
			Remise remise = (Remise)Session["Remise"];
			Sector sector = remise.TrackRepos.SectorRepo.Collection.ToList().Find(x => x.ID == sectorID);

			return (Convert.ToInt32(sector.Enabled)).ToString();
		}

		[HttpGet]
		public string TramExists(int tramNumber)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find(x => x.Number == tramNumber);

			return ((tram == null) ? 0 : 1).ToString();
		}

		[HttpGet]
		public string GetTramState(int tramNumber)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find(x => x.Number == tramNumber);

			return (Convert.ToInt32(tram.TramState)).ToString();
		}

		[HttpPost]
		public void ChangeSector(int sectorId, int newSectorId, int tramNumber)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.First(x => x.Number == tramNumber);
			Sector sector = remise.TrackRepos.SectorRepo.Collection.First(x => x.ID == sectorId);
			Sector newSector = remise.TrackRepos.SectorRepo.Collection.First(x => x.ID == newSectorId);

			if (tram.Sector != null)
			{
				tram.Sector.ListedTram = null;
				tram.Sector = null;
			}
			tram.Sector = newSector;
			tram.Sector.ListedTram = tram;
		}

		[HttpPost]
		public void RemoveTramFromSector(int sectorId, int tramNumber)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.First(x => x.Number == tramNumber);
			Sector sector = remise.TrackRepos.SectorRepo.Collection.First(x => x.ID == sectorId);

			tram.Sector.ListedTram = null;
			tram.Sector = null;
		}

		[HttpPost]
		public void StartSimulate()
		{
			Remise remise = (Remise)Session["Remise"];

			List<Track> tempTracks = new List<Track>();
			List<Tram> tempTrams = new List<Tram>();

			foreach (Track track in remise.TrackRepos.TrackRepo.Collection.ToList())
			{
				ExtendedBindingList<Sector> sectors = new ExtendedBindingList<Sector>();
				foreach (Sector sector in track.Sectors)
				{
					sectors.Add(new Sector(
						sector.ID));
				}
				tempTracks.Add(new Track(
					track.ID,
					track.TrackNumber,
					track.Note,
					sectors,
					track.Enabled,
					track.IsInOutTrack));
			}

			foreach (Tram tram in remise.TramRepos.TramRepo.Collection.ToList())
			{
				tempTrams.Add(new Tram(
					tram.ID,
					tram.TramType,
					tram.TramState,
					tram.Number,
					tram.Line,
					tram.RfidCode,
					tram.HasConductor));
			}

			Session["tempTracks"] = tempTracks;
			Session["tempTrams"] = tempTrams;
		}

		[HttpGet]
		public JsonResult GetSimulate()
		{
			Remise remise = (Remise)Session["Remise"];

			List<string> tramSectorCombo = new List<string>();

			List<Track> tempTracks = (List<Track>)Session["tempTracks"];
			List<Tram> tempTrams = (List<Tram>)Session["tempTrams"];

			Track tempTrack = tempTracks[new Random(Guid.NewGuid().GetHashCode()).Next(0, tempTracks.Count)];
			Sector tempSector = tempTrack.Sectors[new Random(Guid.NewGuid().GetHashCode()).Next(0, tempTrack.Sectors.Count)];
			Tram tempTram = tempTrams[new Random(Guid.NewGuid().GetHashCode()).Next(0, tempTrams.Count)];

			tramSectorCombo.Add(tempSector.ID.ToString());
			tramSectorCombo.Add(tempTram.Number.ToString());

			tempTrack.Sectors.Remove(tempSector);
			tempTrams.Remove(tempTram);

			if (tempTrack.Sectors.Count == 0)
				tempTracks.Remove(tempTrack);

			return Json(tramSectorCombo, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public bool CanStateChange(int tramID, string isCleaning)
		{
			Remise remise = (Remise)Session["Remise"];
			Tram tram = remise.TramRepos.TramRepo.Collection.ToList().Find((t) => t.ID == tramID);
			Activity.Type type;

			if (isCleaning == "true")
			{
				type = Activity.Type.Cleaning;
			}
			else
			{
				type = Activity.Type.Reparation;
			}

			List<Activity> activities = tram.Activities.ToList().FindAll(a => a is NotPeriodicActivity && a.ActivityType == type);
			foreach (Activity notPeriodicActivity in activities)
			{
				if (((NotPeriodicActivity)notPeriodicActivity).Date == null)
				{
					return false;
				}
			}

			return true;
		}

		[HttpGet]
		public JsonResult GetBLockedSectorIds(int sectorId)
		{
			Remise remise = (Remise)Session["Remise"];
			List<string> returnList = new List<string>();

			remise.CheckBlockedConnection(sectorId);

			returnList.AddRange(RunBlockAlgorithm(sectorId, false));
			returnList.AddRange(RunBlockAlgorithm(sectorId, true));

			return Json(returnList, JsonRequestBehavior.AllowGet);
		}

		private List<string> RunBlockAlgorithm(int sectorId, bool reversed)
		{
			List<Sector> manuallyBlocked = (List<Sector>)Session["Manual"];
			Remise remise = (Remise)Session["Remise"];
			Sector sector = remise.TrackRepos.SectorRepo.Collection.First(x => x.ID == sectorId);
			Track t = sector.Track;

			List<string> blockedSectorIds = new List<string>();
			List<Sector> trackSectors = new List<Sector>(t.Sectors);
			int? startIndex = null;
			int? endIndex = null;

			List<Sector> tempSectors = new List<Sector>(t.Sectors);

			if (reversed)
				trackSectors.Reverse();

			foreach (Sector currentSector in trackSectors)
			{
				if ((currentSector.ListedTram != null || (!currentSector.Enabled && manuallyBlocked.Contains(currentSector))) && startIndex == null && endIndex == null)
					if (!reversed)
					{
						startIndex = (trackSectors.IndexOf(currentSector) + 1);
					}
					else
					{
						endIndex = (tempSectors.IndexOf(currentSector) - 1);
					}
				else if ((currentSector.ListedTram != null || (!currentSector.Enabled && manuallyBlocked.Contains(currentSector))) && startIndex == null && endIndex != null && reversed)
				{
					startIndex = (tempSectors.IndexOf(currentSector) + 1);
				}
				else if ((currentSector.ListedTram != null || (!currentSector.Enabled && manuallyBlocked.Contains(currentSector))) && startIndex != null && endIndex == null && !reversed)
				{
					endIndex = (trackSectors.IndexOf(currentSector) - 1);
				}

				else if (startIndex != null && endIndex != null)
				{
					for (int s = (int)startIndex; s <= endIndex; s++)
					{
						if (trackSectors[s].ListedTram == null && !reversed)
						{
							blockedSectorIds.Add((trackSectors[s].ID).ToString());
							trackSectors[s].Enabled = false;
						}
					}

					if (!reversed)
					{
						startIndex = endIndex + 1;
						endIndex = null;
					}
					else
					{
						endIndex = startIndex - 1;
						startIndex = null;
					}
				}
			}
			if (endIndex != null & startIndex != null)
			{
				for (int s = (int)startIndex; s <= endIndex; s++)
				{
					if (trackSectors[s].ListedTram == null && !reversed)
					{
						blockedSectorIds.Add((trackSectors[s].ID).ToString());
						trackSectors[s].Enabled = false;
					}
				}
			}
			if (startIndex == null || endIndex == null)
			{
				if (startIndex == null && endIndex == null)
				{
					for (int b = 0; b < trackSectors.Count; b++)
					{
						if (trackSectors[b].ListedTram != null && manuallyBlocked.Contains(trackSectors[b]) && !reversed)
						{
							blockedSectorIds.Add("B" + (trackSectors[b].ID).ToString());
							trackSectors[b].Enabled = true;
						}
					}
				}
				else if (startIndex != null && !reversed)
				{
					for (int b = (int)startIndex; b < trackSectors.Count; b++)
					{
						if (!reversed)
						{
							blockedSectorIds.Add("B" + (trackSectors[b].ID).ToString());
							trackSectors[b].Enabled = true;
						}
					}
				}
				else if (endIndex != null)
				{
					for (int b = (int)endIndex; b >= 0; b--)
					{
						blockedSectorIds.Add("B" + (trackSectors[b].ID).ToString());
						trackSectors[b].Enabled = true;
					}
				}
			}

			if (reversed)
				trackSectors.Reverse();

			return blockedSectorIds;
		}
	}
}