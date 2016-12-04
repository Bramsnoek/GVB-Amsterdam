using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyeCT4RailsASP.Dtos
{
	public class TrackDto
	{
		public int ID { get; set; }
		public int TrackNumber { get; set; }
		public bool Enabled { get; set; }
		public string Note { get; set; }
		public bool IsInOutTrack { get; set; }
	}
}