using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtendedObservableCollection;
using System.Threading.Tasks;

namespace EyeCT4Rails
{
	public class GenericRepository<T>
		where T : ExtendedNotifyPropertyChanged
	{
		public IGenericContext<T> Context;
		public ExtendedObservableCollection<T> collection = new ExtendedObservableCollection<T>();

		public GenericRepository(IGenericContext<T> context)
		{
			this.Context = context;

			collection = context.Get();
		}

		public void EnableListener()
		{
			collection.CollectionChanged += Collection_CollectionChanged;
			collection.ExtendedPropertyChanged += Collection_ExtendedPropertyChanged;
			collection.ExtendedPropertyListChanged += Collection_ExtendedPropertyListChanged;
		}

		private void Collection_ExtendedPropertyListChanged(object sender, ExtendedListChangedEventArgs e)
		{
			
		}

		private void Collection_ExtendedPropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
			Context.Update((T)sender);
		}

		private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
					Context.Insert((T)sender);
					break;
				case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
					Context.Remove((T)sender);
					break;
				default:
					break;
			}
		}
	}
}
