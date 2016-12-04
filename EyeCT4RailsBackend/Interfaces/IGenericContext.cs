using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
	public interface IGenericContext<T>
		where T : ExtendedNotifyPropertyChanged
	{
		int Insert(T source);
		ExtendedObservableCollection<T> Get();
		void Remove(T source);
		void Update(T source);
	}
}
