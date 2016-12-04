using EyeCT4RailsASP.ViewModels;
using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EyeCT4RailsASP.Controllers
{
    public class ReservationController : Controller
    {

		[HttpGet]
		public string Save(ReservationFormViewModel viewModel)
		{
			Remise remise = (Remise)Session["Remise"];

			if (!ModelState.IsValid)
				return "0";

			//hier saven
			var track = remise.TrackRepos.TrackRepo.Collection.SingleOrDefault(t => t.TrackNumber == viewModel.TrackNumber);

			if (track == null)
				return "1";

			var tram = remise.TramRepos.TramRepo.Collection.SingleOrDefault(t => t.Number == viewModel.TramNumber);

			if (tram == null)
				return "2";

			if (!remise.CanReserveFor(track, viewModel.ReservationFor.Value))
				return "4";

			remise.TrackRepos.ReservationRepo.Collection.Add(new Reservation(0, track, tram, (DateTime)viewModel.ReservationFor, Reservation.ReservationState.Pending));
			return "3";
		}
    }
}