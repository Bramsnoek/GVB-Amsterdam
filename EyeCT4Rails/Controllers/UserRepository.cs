using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class UserRepository
	{
		public UserFunctionRepo UserRepo;
		public GenericRepository<Group> GroupRepo;

		public UserRepository(IUserContext userContext, IGenericContext<Group> groupContext)
		{
			UserRepo = new UserFunctionRepo(userContext);
			GroupRepo = new GenericRepository<Group>(groupContext);


			if (GroupRepo.Collection.Count != 0)
			{
				foreach (User u in UserRepo.Collection)
				{
					u.Group = GroupRepo.Collection.First(x => x.ID == u.Group.ID);
				}
			}
			UserRepo.EnableListener();
			GroupRepo.EnableListener();
		}
	}
}
