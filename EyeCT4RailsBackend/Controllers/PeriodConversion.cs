using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EyeCT4RailsBackend
{
	public static class PeriodConversion
	{
		//Enums
		public enum Name
		{
			[Description("Jaren")]
			Years,
			[Description("Maanden")]
			Months,
			[Description("Weken")]
			Weeks,
			[Description("Dagen")]
			Days
		}

		/// <summary>
		/// Convert value en enumtype Name to aantal dagen
		/// </summary>
		/// <param name="value">Aantal dagen, weken, maanden of jaren</param>
		/// <param name="name">Enum Name</param>
		/// <returns></returns>
		public static int Convert(int value, Name name)
		{
			int convertedValue = 0;
			switch (name)
			{
				case Name.Days:
					convertedValue = value;
					break;
				case Name.Weeks:
					convertedValue = value * 7;
					break;
				case Name.Months:
					convertedValue = value * 30;
					break;
				case Name.Years:
					convertedValue = value * 360;
					break;
			}
			return convertedValue;
		}

		public static KeyValuePair<int,Name> ConvertBack(int amountDays)
		{
			int[] nameValues = new int[4] { 360,30,7,1 };

			for (int i = 0; i < 4; i++)
			{
				if (amountDays / nameValues[i] > 0 && amountDays % nameValues[i] == 0)
				{
					return new KeyValuePair<int, Name>(amountDays / nameValues[i], (Name)Enum.ToObject(typeof(Name), i));
				}
			}
			return new KeyValuePair<int, Name>();
		}
	}
}
