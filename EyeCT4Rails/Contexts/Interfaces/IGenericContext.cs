using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4Rails
{
	public interface IGenericContext<T>
		where T : ExtendedNotifyPropertyChanged
	{
		void Insert(T source);
		ExtendedObservableCollection<T> Get();
		void Remove(T source);
		void Update(T source);
	}
}
