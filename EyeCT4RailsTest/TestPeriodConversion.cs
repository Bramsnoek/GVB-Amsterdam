using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;

namespace EyeCT4RailsTest
{
	[TestClass]
	public class TestPeriodConversion
	{
		[TestMethod]
		public void TestConversion()
		{
			Assert.AreEqual(1, PeriodConversion.Convert(1, PeriodConversion.Name.Days));
			Assert.AreEqual(7, PeriodConversion.Convert(1, PeriodConversion.Name.Weeks));
			Assert.AreEqual(30, PeriodConversion.Convert(1, PeriodConversion.Name.Months));
			Assert.AreEqual(360, PeriodConversion.Convert(1, PeriodConversion.Name.Years));
		}
	}
}