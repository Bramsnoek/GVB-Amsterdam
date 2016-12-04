using ExtendedObservableCollection;
using System;
using System.Collections.Generic;

namespace EyeCT4RailsBackend
{
	public static class TestData
	{
		public static List<User> GetUsers()
		{
			List<User> Users = new List<User>();
			Users.Add(new User(1, "Stan","Stan","Hurks", "stanhurks@gmail.com", new Group(1), new ExtendedBindingList<DateTime> { new DateTime(2016, 04, 06, 14, 35, 22), new DateTime(2016, 04, 06, 14, 36, 22), new DateTime(2016, 04, 06, 14, 37, 22), new DateTime(2016, 04, 06, 14, 38, 22) }, "mBoCLUT2bQJfOolhpmd5NsZmU77 / TMfO5xttSdNxKUQ6zQpkBqAFGJI / 77eAZ0RJ / 7LnXCHGG / IEqAvFM6Vlb7B5AG6sUCoJJ9QAtIoBRgroU7RMyCP2lbua56Ex7mXC"));
			Users.Add(new User(2, "Martijn","Martijn","Broekman", "b@aol.com", new Group(2), new ExtendedBindingList<DateTime> { new DateTime(2016, 03, 20, 14, 35, 22), new DateTime(2016, 03, 21, 14, 36, 22), new DateTime(2016, 03, 22, 14, 37, 22), new DateTime(2016, 03, 23, 14, 38, 22) }, "du3l7fo3AkmcnQlbE2XnOQ5c68Nty2vBRnrobijqsFERII3lpegaLrcEy2bP36usw3UMp89mVVzryYgW344hRdfpE1drzscKDXwNri28qam/Kd7iyS2h2jQoSLxbXMz+"));
			Users.Add(new User(3, "Ruud","Ruud","Janssen", "c@aol.com", new Group(3), new ExtendedBindingList<DateTime> { new DateTime(2016, 03, 20, 14, 35, 22) }, "fWrWTQXhslN0UpU8RGYhkWF8E7h2rQqS67S5HQv/575AtmnqlFWaHweoo5CGkIsn75XVZJHgPDGAbmGYIQD7cPokzuQ2ehoH6Yl+M9+E5+8waGZuEByUxRbJkMjweRSZ"));
			Users.Add(new User(4, "Sjoerd","Sjoerd","Heijligers", "s.heijligers@student.fontys.nl", new Group(4), new ExtendedBindingList<DateTime> { new DateTime(2016, 03, 20, 14, 35, 22) }, "8Jb/xTZCJhufRJkgJJN/D8fyd+5peklwQD2H6go/pSLt4hf1Xn+ODJ72iTIolJupOLdsAQBhzU5cuUVy9o91OO5nrgJVCGOGM0UWiEMA/2/vvuVKmQh674DyCrGM7q1G"));
			Users.Add(new User(5, "Bram","Bram","Snoek", "bramsnoeklith@hotmail.com", new Group(5), new ExtendedBindingList<DateTime> { new DateTime(2016, 03, 20, 14, 35, 22) }, "WwJcuajf6TeBmXVIUwkGGER8pAnzqgSdu2qEgQyuWS9mD0X7t3fnwhvN5S5kVw5T3qm3KBGKLM4acsrEBtNC7BLf9ovpmv0SudL4NX32hmyZKSHAaQb+LeV9u8pyztR0"));
			Users.Add(new User(6, "Ferry","Ferry","Jongmans", "ferryjongmans@live.nl", new Group(6), new ExtendedBindingList<DateTime> { new DateTime(2016, 03, 20, 14, 35, 22) }, "37uHA9IUaBkt/FovjVpJIjA9icePj+/c8yiZUCYy+U5rhT5UXpe9miALR9vONMA7tGuoHiOvEzSnhA5liz9wK9432QG6t17IRMCGjRZQJNlNUg+pqrfKD7j6hjRxunEk"));
			Users.Add(new User(7, "Basje", "Basje", "van de Lindeloof", "g@aol.com", new Group(7), new ExtendedBindingList<DateTime> { new DateTime(2016, 03, 20, 14, 35, 22) }, "h9uZC/gSzAUG8OCqAaLtHIAtDxVZxrH7bRKEhSzHNIKkgPljMox2eNClyJ4RzjeOruv7V3z1XV5+wI5zn8QhYBuooBpZWy50+41htw/l6W5I9AxTbjY4b5t8as6PUS4B"));
			return Users;
		}

		public static List<Group> GetGroups()
		{
			List<Group> Groups = new List<Group>();
			
			Groups.Add(new Group(1, "Beheerder", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanViewUsermanagement | Permission.Permissions.CanCreateUsers | Permission.Permissions.CanEditUser |
											   Permission.Permissions.CanEditGroups | Permission.Permissions.CanRunSimulation | Permission.Permissions.CanEditFilters | Permission.Permissions.CanViewReparationView |
											   Permission.Permissions.CanViewCleaningView | Permission.Permissions.CanDragTrams | Permission.Permissions.CanAddTracks | Permission.Permissions.CanEditTrack | Permission.Permissions.CanEditSector|
											   Permission.Permissions.CanEditTramNote | Permission.Permissions.CanViewTabTramReparation | Permission.Permissions.CanViewTabTramClean | Permission.Permissions.CanViewUsersInReparationTaskDialog |
											   Permission.Permissions.CanSetTramReparationState | Permission.Permissions.CanCreateRecursiveReparationTask |
											   Permission.Permissions.CanViewUsersInCleanTaskDialog | Permission.Permissions.CanSetTramCleanState |
											   Permission.Permissions.CanCreateRecursiveCleanTask)));
			Groups.Add(new Group(2, "Wagenparkbeheerder", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanEditFilters | Permission.Permissions.CanViewReparationView | Permission.Permissions.CanViewCleaningView |
			                                   Permission.Permissions.CanDragTrams | Permission.Permissions.CanEditTrack | Permission.Permissions.CanEditSector | Permission.Permissions.CanEditTramNote |
			                                   Permission.Permissions.CanViewTabTramReparation | Permission.Permissions.CanViewTabTramClean | Permission.Permissions.CanSetTramReparationState |
			                                   Permission.Permissions.CanSetTramCleanState)));
			Groups.Add(new Group(3, "Bestuurder", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanEditFilters | Permission.Permissions.CanViewReparationView | Permission.Permissions.CanViewCleaningView |
											   Permission.Permissions.CanDragTrams | Permission.Permissions.CanEditTramNote | Permission.Permissions.CanViewTabTramReparation |
											   Permission.Permissions.CanViewTabTramClean | Permission.Permissions.CanSetTramReparationState | Permission.Permissions.CanSetTramCleanState)));
			Groups.Add(new Group(4, "HoofdTechnicus", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanViewReparationView | Permission.Permissions.CanEditTramNote |
											   Permission.Permissions.CanViewTabTramReparation | Permission.Permissions.CanViewUsersInReparationTaskDialog |
											   Permission.Permissions.CanSetTramReparationState | Permission.Permissions.CanCreateRecursiveReparationTask)));
			Groups.Add(new Group(5, "Technicus", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanViewReparationView | Permission.Permissions.CanEditTramNote |
											   Permission.Permissions.CanViewTabTramReparation | Permission.Permissions.CanSetTramReparationState)));
			Groups.Add(new Group(6, "Hoofdschoonmaker", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanViewCleaningView | Permission.Permissions.CanEditTramNote | Permission.Permissions.CanViewTabTramClean |
												   Permission.Permissions.CanViewUsersInCleanTaskDialog | Permission.Permissions.CanSetTramCleanState |
												   Permission.Permissions.CanCreateRecursiveCleanTask)));
			Groups.Add(new Group(7, "Schoonmaker", Permission.ConvertPermissionsToInt(Permission.Permissions.CanLogin | Permission.Permissions.CanViewCleaningView | Permission.Permissions.CanEditTramNote | Permission.Permissions.CanViewTabTramClean |
												   Permission.Permissions.CanSetTramCleanState)));

			return Groups;
		}

		public static List<Tram> GetTrams()
		{
			List<Tram> Trams = new List<Tram>();
			Trams.Add(new Tram(1, Tram.Type.ElevenG, Tram.State.ReparationDirty, 800, "62", "ab100", true, "nog vies")); 
			Trams.Add(new Tram(2, Tram.Type.DubbelKopCombino, Tram.State.Ok, 45, "23", "525", false, "helemaalschoon"));
			Trams.Add(new Tram(3, Tram.Type.ElevenG, Tram.State.Ok, 127, "62", "ss5", false, "nog vies"));
			Trams.Add(new Tram(4, Tram.Type.ElevenG, Tram.State.Dirty, 173, "62", "435g", false, "nog vies"));
			Trams.Add(new Tram(5, Tram.Type.ElevenG, Tram.State.Dirty, 103, "62", "43t", false, "nog vies"));
			Trams.Add(new Tram(6, Tram.Type.ElevenG, Tram.State.Reparation, 153, "62", "434a", false, "nog vies"));
			Trams.Add(new Tram(7, Tram.Type.ElevenG, Tram.State.Ok, 167, "62", "43qa", false, "nog vies"));
			Trams.Add(new Tram(8, Tram.Type.ElevenG, Tram.State.Reparation, 123, "62", "a100", true, "nog vies"));
			Trams.Add(new Tram(9, Tram.Type.DubbelKopCombino, Tram.State.Ok, 3, "23", "525", false, "helemaalschoon"));
			Trams.Add(new Tram(10, Tram.Type.ElevenG, Tram.State.Ok, 500, "62", "ss5", false, "nog vies"));
			Trams.Add(new Tram(11, Tram.Type.ElevenG, Tram.State.Reparation, 456, "62", "435g", false, "nog vies"));
			Trams.Add(new Tram(12, Tram.Type.ElevenG, Tram.State.Ok, 124, "62", "43t", false, "nog vies"));
			Trams.Add(new Tram(13, Tram.Type.ElevenG, Tram.State.Dirty, 78, "62", "434a", false, "nog vies"));
			Trams.Add(new Tram(14, Tram.Type.ElevenG, Tram.State.ReparationDirty, 735, "62", "43qa", false, "nog vies"));
			Trams.Add(new Tram(15, Tram.Type.ElevenG, Tram.State.Ok, 491, "62", "a100", true, "nog vies"));
			Trams.Add(new Tram(16, Tram.Type.DubbelKopCombino, Tram.State.Ok, 684, "23", "525", false, "helemaalschoon"));
			Trams.Add(new Tram(17, Tram.Type.ElevenG, Tram.State.Ok, 536, "62", "ss5", false, "nog vies"));
			Trams.Add(new Tram(18, Tram.Type.ElevenG, Tram.State.Reparation, 134, "62", "435g", false, "nog vies"));
			Trams.Add(new Tram(19, Tram.Type.ElevenG, Tram.State.Dirty, 75, "62", "43t", false, "nog vies"));
			Trams.Add(new Tram(20, Tram.Type.ElevenG, Tram.State.Ok, 135, "62", "434a", false, "nog vies"));
			Trams.Add(new Tram(21, Tram.Type.ElevenG, Tram.State.Dirty, 426, "62", "43qa", false, "nog vies"));
			Trams.Add(new Tram(22, Tram.Type.ElevenG, Tram.State.Reparation, 231, "62", "435g", false, "nog vies"));
			//foreach (Tram tram in Trams)
			//{
			//    tram.
			//}
			return Trams;
		}

		public static List<Track> GetTracks()
		{
			List<Track> Tracks = new List<Track>();
			Tracks.Add(new Track(1, 11, "", new ExtendedBindingList<Sector> { new Sector(1), new Sector(2), new Sector(3), new Sector(4) }));
			Tracks.Add(new Track(2, 12, "Dit spoor is bijna aan reparatie toe.", new ExtendedBindingList<Sector> { new Sector(5), new Sector(6), new Sector(7), new Sector(8) }));
			Tracks.Add(new Track(3, 13, "", new ExtendedBindingList<Sector> { new Sector(9), new Sector(10), new Sector(11), new Sector(12) }));
			Tracks.Add(new Track(4, 14, "", new ExtendedBindingList<Sector> { new Sector(13), new Sector(14), new Sector(15), new Sector(16) }));
			Tracks.Add(new Track(5, 15, "", new ExtendedBindingList<Sector> { new Sector(17), new Sector(18), new Sector(19), new Sector(20), new Sector(21), new Sector(22) }));
			Tracks.Add(new Track(6, 54, "", new ExtendedBindingList<Sector> { new Sector(23), new Sector(24), new Sector(25), new Sector(26), new Sector(27), new Sector(28) }));
			Tracks.Add(new Track(7, 62, "", new ExtendedBindingList<Sector> { new Sector(29), new Sector(30), new Sector(31), new Sector(32), new Sector(33), new Sector(34) }));
			Tracks.Add(new Track(8, 71, "", new ExtendedBindingList<Sector> { new Sector(31), new Sector(35), new Sector(36), new Sector(37), new Sector(38), new Sector(39) }));
			Tracks.Add(new Track(9, 78, "", new ExtendedBindingList<Sector> { new Sector(40), new Sector(41), new Sector(42), new Sector(43), new Sector(44), new Sector(45), new Sector(51), new Sector(52) }));
			Tracks.Add(new Track(10, 19, "", new ExtendedBindingList<Sector> { new Sector(46), new Sector(47), new Sector(48), new Sector(49), new Sector(50) }));
			return Tracks;
		}

		public static List<Sector> GetSectors()
		{
			List<Sector> Sectors = new List<Sector>();
			//Sectoren Track met ID 1:
			Sectors.Add(new Sector(1, new Track(1), true, new Tram(1)));
			Sectors.Add(new Sector(2, new Track(1), true, new Tram(4)));
			Sectors.Add(new Sector(3, new Track(1), true, new Tram(5)));
			Sectors.Add(new Sector(4, new Track(1), true, new Tram(2)));
			//Sectoren Track met ID 2:
			Sectors.Add(new Sector(5, new Track(2), true, new Tram(6)));
			Sectors.Add(new Sector(6, new Track(2), true, new Tram(3)));
			Sectors.Add(new Sector(7, new Track(2), true, new Tram(7)));
			Sectors.Add(new Sector(8, new Track(2)));
			//Sectoren Track met ID 3
			Sectors.Add(new Sector(9, new Track(3), true, new Tram(8)));
			Sectors.Add(new Sector(10, new Track(3)));
			Sectors.Add(new Sector(11, new Track(3)));
			Sectors.Add(new Sector(12, new Track(3), true, new Tram(9)));
			//Sectoren Track met ID 4:
			Sectors.Add(new Sector(13, new Track(4)));
			Sectors.Add(new Sector(14, new Track(4)));
			Sectors.Add(new Sector(15, new Track(4)));
			Sectors.Add(new Sector(16, new Track(4), true, new Tram(10)));
			//Sectoren Track met ID 5:
			Sectors.Add(new Sector(17, new Track(5), true, new Tram(11)));
			Sectors.Add(new Sector(18, new Track(5)));
			Sectors.Add(new Sector(19, new Track(5), true, new Tram(12)));
			Sectors.Add(new Sector(20, new Track(5), true, new Tram(13)));
			Sectors.Add(new Sector(21, new Track(5)));
			Sectors.Add(new Sector(22, new Track(5)));
			//Sectoren Track met ID 6:
			Sectors.Add(new Sector(23, new Track(6), true, new Tram(14)));
			Sectors.Add(new Sector(24, new Track(6)));
			Sectors.Add(new Sector(25, new Track(6)));
			Sectors.Add(new Sector(26, new Track(6), true, new Tram(15)));
			Sectors.Add(new Sector(27, new Track(6)));
			Sectors.Add(new Sector(28, new Track(6)));
			//Sectoren Track met ID 7:
			Sectors.Add(new Sector(29, new Track(7), true, new Tram(17)));
			Sectors.Add(new Sector(30, new Track(7)));
			Sectors.Add(new Sector(31, new Track(7)));
			Sectors.Add(new Sector(32, new Track(7), true, new Tram(16)));
			Sectors.Add(new Sector(33, new Track(7)));
			Sectors.Add(new Sector(34, new Track(7)));
			//Sectoren Track met ID 8:
			Sectors.Add(new Sector(35, new Track(8)));
			Sectors.Add(new Sector(36, new Track(8)));
			Sectors.Add(new Sector(37, new Track(8), true, new Tram(18)));
			Sectors.Add(new Sector(38, new Track(8)));
			Sectors.Add(new Sector(39, new Track(8), true, new Tram(19)));
			//Sectoren Track met ID 9:
			Sectors.Add(new Sector(40, new Track(9)));
			Sectors.Add(new Sector(41, new Track(9)));
			Sectors.Add(new Sector(42, new Track(9)));
			Sectors.Add(new Sector(43, new Track(9)));
			Sectors.Add(new Sector(44, new Track(9), true, new Tram(21)));
			Sectors.Add(new Sector(45, new Track(9)));
			Sectors.Add(new Sector(51, new Track(9)));
			Sectors.Add(new Sector(52, new Track(9)));
			//Sectoren Track met ID 10:
			Sectors.Add(new Sector(46, new Track(10)));
			Sectors.Add(new Sector(47, new Track(10), true, new Tram(22)));
			Sectors.Add(new Sector(48, new Track(10)));
			Sectors.Add(new Sector(49, new Track(10)));
			Sectors.Add(new Sector(50, new Track(10)));
			return Sectors;
		}

		public static List<PeriodicActivity> GetPeriodicActivities()
		{
			List<PeriodicActivity> PeriodicActivities = new List<PeriodicActivity>();

			PeriodicActivities.Add(new PeriodicActivity(1, "Dak controleren", Activity.Type.Reparation, new User(1), PeriodConversion.Convert(1, PeriodConversion.Name.Days), new Tram(1)));
			PeriodicActivities.Add(new PeriodicActivity(2, "Schoonmaak WC", Activity.Type.Cleaning, new User(2), PeriodConversion.Convert(2, PeriodConversion.Name.Weeks), new Tram(1)));
			PeriodicActivities.Add(new PeriodicActivity(3, "Stoelen controleren", Activity.Type.Reparation, new User(3), PeriodConversion.Convert(1, PeriodConversion.Name.Months), new Tram(3)));

			return PeriodicActivities;
		}

		public static List<NotPeriodicActivity> GetNotPeriodicActivities()
		{
			List<NotPeriodicActivity> notPeriodicActivities = new List<NotPeriodicActivity>();

			notPeriodicActivities.Add(new NotPeriodicActivity(1, DateTime.Today, "Reperatie dak", Activity.Type.Reparation, new User(1), "Dak is gerepareerd", GetTrams()[0], false));
			notPeriodicActivities.Add(new NotPeriodicActivity(2, new DateTime(2016,01,01,12,00,00), "Schoonmaak WC", Activity.Type.Cleaning, new User(2), "Wc schoongemaakt", GetPeriodicActivities()[1], GetTrams()[0], false));
			notPeriodicActivities.Add(new NotPeriodicActivity(3, DateTime.Today, "WiFi repaireren", Activity.Type.Reparation, new User(3), "WiFi is gerepareerd", GetTrams()[2], false));

			return notPeriodicActivities;
		}

		public static List<Activity> GetActivities()
		{
			List<Activity> activities = new List<Activity>();

			foreach (Activity acitivty in GetPeriodicActivities())
			{
				activities.Add(acitivty);
			}

			foreach (Activity acitivty in GetNotPeriodicActivities())
			{
				activities.Add(acitivty);
			}

			return activities;
		}
	}
}
