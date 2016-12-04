using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public sealed class GroupMemoryContext : IGenericContext<Group>
	{
        public List<Group> Groups { get; set; }

		public GroupMemoryContext(bool useTestData = false)
		{
			Groups = new List<Group>();
			if (useTestData)
			{
				Groups = TestData.GetGroups();
			}
		}

        /// <summary>
        ///     Check the group of a certain user.
        /// </summary>
        /// 
        /// <returns>
        ///     The group for the specified user.
        /// </returns>
        public ExtendedObservableCollection<Group> Get()
        {
			return new ExtendedObservableCollection<Group>(Groups);
        }

        /// <summary>
        ///     Insert a group in the dummydata
        /// </summary>
        /// 
        /// <param name="group">
        ///     The group that will be parsed into the dummydata
        /// </param>
        /// 
        /// <returns>
        ///     bool
        /// </returns>
        public int Insert(Group group)
		{
			Groups.Add(group);

            return Groups.Count - 1;
        }

        /// <summary>
        ///     Update a group in the dummy data
        /// </summary>
        /// 
        /// <param name="group">
        ///     All attributes from this group object will be used as new information
        /// </param>
        /// 
        /// <returns>
        ///     bool ? true when the group is found : false when the group is not found
        /// </returns>
        public void Update(Group group)
        {
			List<Group> tmp = new List<Group>();

            foreach(Group g in Groups)
            {
                if(g.ID == group.ID)
                {
                    tmp.Add(group);
                }
                else
                {
                    tmp.Add(g);
                }
            }

            Groups = tmp;
        }

        public void Remove(Group group)
        {
            throw new NotSupportedException();
        }
    }
}
