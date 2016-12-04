using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
    public interface IUserContext : IGenericContext<User>
    {
        string GetPassword(string username);
        bool SetPassword(User user);
		bool insertLogin(User user);
    }
}
