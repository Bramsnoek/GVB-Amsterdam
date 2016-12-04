using System;

namespace EyeCT4RailsBackend
{
	public static class Permission
	{
		[Flags]
		public enum Permissions
		{
			Nothing								= 0x0,
			CanLogin							= 0x1,
			CanViewUsermanagement				= 0x2,
			CanCreateUsers						= 0x4,
			CanEditUser							= 0x8,
			CanEditGroups						= 0x10,
			CanRunSimulation					= 0x20,
			CanEditFilters						= 0x40,
			CanViewReparationView				= 0x80,
			CanViewCleaningView					= 0x100,
			CanDragTrams						= 0x200,
			CanAddTracks						= 0x400,
			CanEditTrack						= 0x800,
			CanEditSector						= 0x1000,
			CanEditTramNote						= 0x2000,
			CanViewTabTramReparation			= 0x4000,
			CanViewTabTramClean					= 0x8000,
			CanViewUsersInReparationTaskDialog	= 0x10000,
			CanSetTramReparationState			= 0x20000,
			CanCreateRecursiveReparationTask   	= 0x40000,
			CanViewUsersInCleanTaskDialog		= 0x80000,
			CanSetTramCleanState				= 0x100000,
			CanCreateRecursiveCleanTask			= 0x200000
		}

		public static bool Check(User user, Permissions permissions)
		{
			return (ConvertIntToPermissions(user.Group.Permission) & permissions) == permissions;
		}

		public static int ConvertPermissionsToInt(Permissions permissions)
		{
			return Convert.ToInt32(permissions);
		}

		public static Permissions ConvertIntToPermissions(int permissions)
		{
			return (Permissions)permissions;
		}
	}
}
