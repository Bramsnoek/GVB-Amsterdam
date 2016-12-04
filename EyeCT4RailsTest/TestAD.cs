using System;
using System.Text;
using System.Collections.Generic;
using EyeCT4RailsBackend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ExtendedObservableCollection;

namespace EyeCT4RailsTest
{
	/// <summary>
	/// Summary description for TestAD
	/// </summary>
	[TestClass]
	public class TestAD
	{
		[TestMethod]
		public void TestAuthenticate()
		{
			Assert.IsTrue(AD.Authenticate("sjhe", "P@ssw0rd"));
		}

		[TestMethod]
		public void TestGetGroups()
		{
			Assert.IsTrue(AD.GetGroups().Count >= 8);
		}

		[TestMethod]
		public void TestGetUsers()
		{
			Assert.IsTrue(AD.GetUsers(AD.GetGroups().ToList()).Count > 0);
		}

		[TestMethod]
		public void TestSetGroupPermission()
		{
			Assert.IsTrue(AD.SetGroupPermission(AD.GetGroups()[0]));
		}
	}
}
