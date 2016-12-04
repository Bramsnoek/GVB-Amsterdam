using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
	public class GroupADContext : IGenericContext<Group>
	{
		public ExtendedObservableCollection<Group> Get()
		{
			return AD.GetGroups();
		}

		public int Insert(Group group)
		{
			throw new NotSupportedException();
		}

		public void Remove(Group group)
		{
			throw new NotSupportedException();
		}

		public void Update(Group group)
		{
			AD.SetGroupPermission(group);
		}
	}
}
