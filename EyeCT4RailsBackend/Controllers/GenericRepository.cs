﻿using ExtendedObservableCollection;
using System.Collections.Specialized;

namespace EyeCT4RailsBackend
{
	public class GenericRepository<T>
		where T : ExtendedNotifyPropertyChanged
	{
		private IGenericContext<T> context;
		public ExtendedObservableCollection<T> Collection { get; set; } 

		public GenericRepository(IGenericContext<T> context)
		{
			this.context = context;
            Collection = new ExtendedObservableCollection<T>();
            Collection = context.Get();
		}

		public void EnableListener()
		{
			Collection.CollectionChanged += Collection_CollectionChanged;
			Collection.ExtendedPropertyChanged += Collection_ExtendedPropertyChanged;
			Collection.ExtendedPropertyListChanged += Collection_ExtendedPropertyListChanged;
		}

		private void Collection_ExtendedPropertyListChanged(object sender, ExtendedListChangedEventArgs e)
		{
			
		}

		private void Collection_ExtendedPropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
			context.Update((T)sender);
		}

		private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					context.Insert((T)e.NewItems[0]);
					break;
				case NotifyCollectionChangedAction.Remove:
					context.Remove((T)e.OldItems[0]);
					break;
				default:
					break;
			}
		}
	}
}
