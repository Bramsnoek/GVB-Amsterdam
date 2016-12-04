using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EyeCT4RailsASP.ViewModels
{
	public class TrackFormViewModel
	{
		[Required]
		[Display(Name = "Spoornummer")]
		public int? TrackNumber { get; set; }
		
		[Display(Name = "Vrij")]
		public bool State { get; set; }

		[Required]
		[Display(Name = "Aantal Sectoren")]
		public int? SectorCount { get; set; }
		
		[Display(Name = "In/Uitrij Spoor")]
		public bool ConnectionTrack { get; set; }
		
		[Display(Name = "Notitie")]
		public string Note { get; set; }

		public TrackFormViewModel()
		{
				
		}

	}
}