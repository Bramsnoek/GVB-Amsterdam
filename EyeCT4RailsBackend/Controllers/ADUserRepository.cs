using ExtendedObservableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class ADUserRepository
	{
		public List<User> Users { get; private set; }
		public GenericRepository<Group> GroupRepo { get; set; }

		private IADUserContext userContext;

		public ADUserRepository(IADUserContext userContext, IGenericContext<Group> groupContext)
		{
			this.userContext = userContext;
			GroupRepo = new GenericRepository<Group>(groupContext);

			Users = userContext.Get(GroupRepo.Collection.ToList());

			foreach (User user in Users)
			{
				user.Group = GroupRepo.Collection.First((g) => g.ID == user.Group.ID);
			}

			GroupRepo.EnableListener();
		}

		public bool Authenticate(User user)
		{
			return userContext.Authenticate(user);
		}
	}
}
