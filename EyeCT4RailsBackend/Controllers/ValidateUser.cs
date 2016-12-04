using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsBackend
{
	public class ValidateUser
	{
        //private UserRepository userRepository;
        private ADUserRepository userRepository;

        public ValidateUser()
        {

            //userRepository = new UserRepository(new UserOracleDBContext(), new GroupOracleDBContext());
            userRepository = new ADUserRepository(new UserADContext(), new GroupADContext());
        }

        public bool Login(User account)
        {
            //var usr = userRepository.UserRepo.Collection.Where(u => u.Username == account.Username && u.Password == account.Password).FirstOrDefault();
            //if (usr != null)
            //{
            //    return true;
            //}
            //return false;
            
            return userRepository.Authenticate(account);
        }
	}
}
