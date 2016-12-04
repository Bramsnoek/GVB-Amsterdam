using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	class UserADContext : IADUserContext
	{
		public bool Authenticate(User user)
		{
			return AD.Authenticate(user.Username, user.Password);
		}

		public List<User> Get(List<Group> groups)
		{
			return AD.GetUsers(groups);
		}
	}
}
