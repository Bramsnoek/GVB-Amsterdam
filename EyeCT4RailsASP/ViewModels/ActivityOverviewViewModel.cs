using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EyeCT4RailsASP.ViewModels
{
	public class ActivityOverviewViewModel
	{
		[Required]
		[Display(Name = "Periode van")]
		public DateTime? PeriodStart { get; set; }

		[Required]
		[Display(Name = "Periode tot")]
		public DateTime? PeriodEnd { get; set; }

		public IEnumerable<NotPeriodicActivity> Activities { get; set; }
		public Activity.Type ActivityType { get; set; }
		public string PageTitle { get; set; }
		public string FormTitle { get; set; }
		public string Message { get; set; }

		public ActivityOverviewViewModel()
		{
		}

		public ActivityOverviewViewModel(DateTime? periodStart, DateTime? periodEnd, Activity.Type activityType, IEnumerable<NotPeriodicActivity> activities)
		{
			PeriodStart = periodStart;
			PeriodEnd = periodEnd;
			ActivityType = activityType;

			Message = activities.Count() == 0 ? "No results found" : Message;
			Message = periodStart > periodEnd ? "Start searchdate must be smaller than end searchdate" : Message;

			switch (ActivityType)
			{
				case Activity.Type.Reparation:
					PageTitle = "Reparatietaken";
					FormTitle = "Reparatietaken overzicht";
					break;
				case Activity.Type.Cleaning:
					PageTitle = "Schoonmaaktaken";
					FormTitle = "Schoonmaaktaken overzicht";
					break;
			}

			if (Message == null)
			{
				Activities = activities;
			}
		}
	}
}