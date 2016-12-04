using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
    public interface IADUserContext
    {
		List<User> Get(List<Group> groups);
		bool Authenticate(User user);
	}
}
