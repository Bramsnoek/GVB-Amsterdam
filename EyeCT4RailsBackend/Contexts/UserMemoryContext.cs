using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public sealed class UserMemoryContext : IGenericContext<User>
    {
		private List<User> users;

        public UserMemoryContext(bool useTestData = false)
        {
			users = new List<User>();
			if (useTestData)
			{
				users = TestData.GetUsers();
			}
        }

        /// <summary>
        ///     Get all users
        /// </summary>
        /// 
        /// <returns>
        ///     A list with users
        /// </returns>
        public ExtendedObservableCollection<User> Get()
        {
            return new ExtendedObservableCollection<User>(users);
        }

        /// <summary>
        ///     Get the password
        /// </summary>
        /// 
        /// <param name="username">
        ///     The name of the user
        /// </param>
        /// 
        /// <returns>
        ///     string : Encrypted password
        /// </returns>
        public string GetPassword(string username)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return user.Password;
                }
            }

            return null;
        }

        /// <summary>
        ///     Insert a single user
        /// </summary>
        /// 
        /// <param name="user">
        ///     The new user
        /// </param>
        /// 
        /// <returns>
        ///     Int if succeeded
        /// </returns>
        public int Insert(User user)
        {
			users.Add(user);
            return users.Count - 1;
        }

        public void Remove(User user)
        {
            throw new NotSupportedException();
        }

		public bool insertLogin(User user)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Sets the password for a certain user
		/// </summary>
		/// 
		/// <param name="user">
		///     The user who will have a new password
		/// </param>
		/// 
		/// <returns>
		///     True if succeeded
		/// </returns>
		public bool SetPassword(User user)
        {
            List<User> tmp = new List<User>();
            bool found = false;

            foreach (User u in users)
            {
                if (u.ID == user.ID)
                {
                    u.Password = user.Password;
                    found = true;
                }
                tmp.Add(u);
            }

            return found;   
        }

        /// <summary>
        ///     Update a user
        /// </summary>
        /// 
        /// <param name="user">
        ///     The updated user
        /// </param>
        /// 
        /// <returns>
        ///     bool : true if succeeded
        /// </returns>
        public void Update(User user)
        {
            List<User> tmp = new List<User>();

            foreach (User u in users)
            {

                if (u.ID == user.ID)
                {
                    tmp.Add(user);
                }
                else
                {
                    tmp.Add(u);
                }

            }
			users = tmp;
        }
    }
}
