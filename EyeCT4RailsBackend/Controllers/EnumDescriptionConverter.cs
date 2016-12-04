using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EyeCT4RailsBackend
{
	public static class EnumDescriptionConverter
	{
		/// <summary>
		/// Methode om een enum description op het halen als string
		/// </summary>
		/// <param name="en">Enumwaarde die geconvert moet worden</param>
		/// <returns>String van de enumdescription</returns>
		public static string GetDescriptionFromEnum(Enum en)
		{
			System.Type type = en.GetType();

			MemberInfo[] memInfo = type.GetMember(en.ToString());

			if (memInfo != null && memInfo.Length > 0)
			{
				object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attrs != null && attrs.Length > 0)
				{
					return ((DescriptionAttribute)attrs[0]).Description;
				}
			}
			return en.ToString();
		}

		/// <summary>
		/// Methode om een description van een enum om te zetten naar de oorspronkelijke enum waarde
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="description">String van een enum description</param>
		/// <returns>Enum</returns>
		public static T GetEnumFromDescription<T>(string description)
		{
			MemberInfo[] fis = typeof(T).GetFields();

			foreach (var fi in fis)
			{
				DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
					return (T)Enum.Parse(typeof(T), fi.Name);
			}
			throw new Exception("Not found");
		}

		public static string[] GetDescriptionStringList(Type en)
		{
			int count = 0;
			string[] description = new string[Enum.GetValues(en).Length];

			foreach (Enum enumValue in Enum.GetValues(en))
			{
				description[count] = (GetDescriptionFromEnum(enumValue));
				count++;
			}
			return description;
		}
	}
}
