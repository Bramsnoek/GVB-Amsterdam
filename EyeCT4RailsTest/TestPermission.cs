using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using Permissions = EyeCT4RailsBackend.Permission.Permissions;

namespace EyeCT4RailsTest
{
	[TestClass]
	public class TestPermission
	{
		private User user;

		[TestInitialize]
		public void TestInitialize()
		{
			user = TestData.GetUsers()[0];
			user.Group = new Group(1, "", 5); //Permissions.CanLogin | Permissions.CanCreateUsers
		}
		
		[TestMethod]
		public void TestPermissionGranted()
		{
			Assert.IsTrue(Permission.Check(user, Permissions.CanCreateUsers));
		}

		[TestMethod]
		public void TestPermissionDenied()
		{
			Assert.IsFalse(Permission.Check(user, Permissions.CanDragTrams));
		}

		[TestMethod]
		public void TestEmptyPermission()
		{
			Assert.AreEqual((Permissions)0x0, Permissions.Nothing);
		}

		[TestMethod]
		public void TestConvertPermissionsToInt()
		{
			Assert.AreEqual(5, Permission.ConvertPermissionsToInt(Permissions.CanLogin | Permissions.CanCreateUsers));
		}

		[TestMethod]
		public void TestConvertIntToPermissions()
		{
			Assert.AreEqual(Permissions.CanLogin | Permissions.CanCreateUsers, Permission.ConvertIntToPermissions(5));
		}
	}
}
