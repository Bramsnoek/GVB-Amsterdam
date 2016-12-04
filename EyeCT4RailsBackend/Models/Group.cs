using ExtendedObservableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class Group : ExtendedNotifyPropertyChanged, IModel
	{
		public int ID
		{
			get { return id; }
			set { SetField(this, ref id, value); }
		}
		public string Name
		{
			get { return name; }
			set { SetField(this, ref name, value); }
		}
		public int Permission
		{
			get { return permission; }
			set { SetField(this, ref permission, value); }
		}

		private int id;
		private string name;
		private int permission;

		public Group(int id)
		{
			ID = id;
		}

		public Group(int id, string name, int permission)
			: this(id)
		{
			Name = name;
			Permission = permission;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
