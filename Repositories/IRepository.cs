using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
	public interface IRepository<T>
	{
		void Add(T obj);

		T GetById(int id);

		List<T> GetAll();

		void Delete(T obj);

		void Update(T obj);



	}
}
