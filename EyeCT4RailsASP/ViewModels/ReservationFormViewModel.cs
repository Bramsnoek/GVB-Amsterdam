using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EyeCT4RailsASP.ViewModels
{
	public class ReservationFormViewModel
	{
		[Required]
		[Display(Name = "Tramnummer")]
		public int? TramNumber { get; set; }

		[Required]
		[Display(Name = "Spoornummer")]
		public int? TrackNumber { get; set; }

		[Required]
		[Display(Name = "Datum")]
		public DateTime? ReservationFor { get; set; }

		public ReservationFormViewModel(int? tramNumber, int? trackNumber)
		{
			TramNumber = tramNumber;
			TrackNumber = trackNumber;
		}

		public ReservationFormViewModel()
		{
		}
	}
}