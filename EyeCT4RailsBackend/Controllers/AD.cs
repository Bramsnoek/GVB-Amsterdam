using ExtendedObservableCollection;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public static class AD
	{
		private static DirectoryEntry directoryEntry;

		public static bool Authenticate(string username, string password)
		{
			try
			{
				directoryEntry = new DirectoryEntry("LDAP://GVB.local", username, password);
				directoryEntry.Options.PasswordEncoding = PasswordEncodingMethod.PasswordEncodingSsl;
				object nativeObject = directoryEntry.NativeObject;
				directoryEntry.Path = "LDAP://GVB.local/OU=GVB Havenstraat,DC=GVB,DC=local";
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static ExtendedObservableCollection<Group> GetGroups()
		{
			DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
			searcher.CacheResults = false;
			searcher.Filter = "(&objectCategory=group)";

			ExtendedObservableCollection<Group> Groups = new ExtendedObservableCollection<Group>();

			foreach (SearchResult result in searcher.FindAll())
			{
				DirectoryEntry searchResult = result.GetDirectoryEntry();

                if (!searchResult.Properties["cn"].Value.ToString().Contains("GC_")) continue;

                int sid = BitConverter.ToInt32((byte[])searchResult.Properties["objectGUID"].Value, 0) * -1;
				Groups.Add(new Group(sid, searchResult.Properties["cn"].Value.ToString().Replace("GC_", ""), Convert.ToInt32(searchResult.Properties["info"].Value)));
			}

			return Groups;
		}

		public static List<User> GetUsers(List<Group> groups)
		{
			DirectorySearcher userSearcher = new DirectorySearcher(directoryEntry);
			userSearcher.CacheResults = false;
			userSearcher.Filter = "(&(objectClass=user)(!objectClass=computer))";

			List<User> users = new List<User>();

			foreach (SearchResult userResult in userSearcher.FindAll())
			{
				Group userGroup = null;
				DirectoryEntry searchUserResult = userResult.GetDirectoryEntry();
				int sid = BitConverter.ToInt32((byte[])searchUserResult.Properties["objectGUID"].Value, 0) * -1;

                if (searchUserResult.Properties["memberof"].Count != 1) continue;
                if (!searchUserResult.Properties["memberof"].Value.ToString().Contains("GC_")) continue;

                foreach (Group group in groups)
				{
					if (searchUserResult.Properties["memberof"].Value.ToString()
						.Remove(searchUserResult.Properties["memberof"].Value.ToString().IndexOf(","))
						.Replace("GC_", "").Replace("CN=", "") == group.Name)
					{
						userGroup = group;
						break;
					}
				}

				if (userGroup == null) throw new ActiveDirectoryObjectNotFoundException("Usergroup couldn't be found");

				users.Add(new User(sid, searchUserResult.Properties["sAMAccountName"].Value.ToString(), searchUserResult.Properties["givenName"].Value.ToString(), searchUserResult.Properties["sn"].Value.ToString(), searchUserResult.Properties["mail"].Value.ToString(), userGroup));
			}

			return users;
		}

		public static bool SetGroupPermission(Group group)
		{
			DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
			searcher.CacheResults = false;
			searcher.Filter = "(&(objectCategory=group)(name=GC_" + group.Name + "))";

			SearchResult result = searcher.FindOne();
			DirectoryEntry searchResult = result.GetDirectoryEntry();
			searchResult.Properties["note"].Value = group.Permission;

			return true;
		}
	}
}
