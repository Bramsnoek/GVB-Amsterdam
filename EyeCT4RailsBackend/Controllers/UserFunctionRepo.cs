using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
    public class UserFunctionRepo : GenericRepository<User>
    {
        private IUserContext context;

        public UserFunctionRepo(IUserContext context) : base(context)
        {
            this.context = context;
        }

        public void insertLogin(User user)
        {
            context.insertLogin(user);
        }

        public void GetPassword(string username)
        {
            context.GetPassword(username);
        }
    }
}
