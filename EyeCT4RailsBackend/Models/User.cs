using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;
using System.ComponentModel.DataAnnotations;

namespace EyeCT4RailsBackend
{
	public class User : ExtendedNotifyPropertyChanged, IModel
	{
		public int ID
		{
			get { return id; }
			set { SetField(this, ref id, value); }
		}
		[Required(ErrorMessage = "Username is Required")]
		public string Username
		{
			get { return username; }
			set { SetField(this, ref username, value); }
		}
		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		public string Password
		{
			get { return password; }
			set { SetField(this, ref password, value); }
		}
		public string FirstName
		{
			get { return firstname; }
			set { SetField(this, ref firstname, value); }
		}
		public string LastName
		{
			get { return lastname; }
			set { SetField(this, ref lastname, value); }
		}
		public string Email
		{
			get { return email; }
			set { SetField(this, ref email, value); }
		}
		public bool PasswordChanged
		{
			get { return passwordChanged; }
			set { SetField(this, ref passwordChanged, value); }
		}
		public bool Enabled
		{
			get { return enabled; }
			set { SetField(this, ref enabled, value); }
		}
		public Group Group
		{
			get { return group; }
			set { SetField(this, ref group, value); }
		}
		public ExtendedBindingList<DateTime> Logins { get; set; }

		private int id;
		private string username;
		private string firstname;
		private string lastname;
		private string email;
		private string password;
		private bool passwordChanged;
		private bool enabled;
		private Group group;

		public User()
		{

		}

		public User(int id)
		{
			ID = id;
		}

		public User(int id, string username, string email, Group group)
			: this(id)
		{
			Username = username;
			Email = email;
			Group = group;
			Logins = new ExtendedBindingList<DateTime>();
			PasswordChanged = false;
		}

		public User(int id, string username, string firstName, string lastName, string email, Group group)
			: this(id, username, email, group)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public User(int id, string username, string firstName, string lastName, string password, string email, Group group)
			: this(id, username, firstName, lastName, email, group)
		{
			Password = password;
		}

		public User(int id, string username, string firstName, string lastName, string password, string email, Group group, ExtendedBindingList<DateTime> userLogins)
			: this(id, username, firstName, lastName, password, email, group)
		{
			Logins = userLogins;
		}

		public User(int id, string username, string firstName, string lastName, string email, Group group, ExtendedBindingList<DateTime> userLogins, string password)
			: this(id, username, firstName, lastName, password, email, group, userLogins)
		{
			
		}

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}
