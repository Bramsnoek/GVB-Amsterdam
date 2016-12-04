using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyeCT4RailsASP.Dtos
{
	public class TramDto
	{
		public int ID { get; set; }
		public Tram.State TramState { get; set; }
		public int Number { get; set; }
		public string Line { get; set; }
		public string RfidCode { get; set; }
		public string Note { get; set; }
		public bool HasConducon { get; set; }
		public Tram.Type TramType { get; set; }
	}
}