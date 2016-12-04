using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class RemiseRepository
	{
		public GenericRepository<Remise> RemiseRepo;
		public GenericRepository<Configuration> ConfigRepo;

		public RemiseRepository(IGenericContext<Remise> remiseContext, IGenericContext<Configuration> configContext)
		{
			RemiseRepo = new GenericRepository<Remise>(remiseContext);
			ConfigRepo = new GenericRepository<Configuration>(configContext);

			RemiseRepo.EnableListener();
			ConfigRepo.EnableListener();
		}
	}
}
