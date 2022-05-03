using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
	public interface IRepository<T>
	{
		Task Add(T obj);

		Task<T> GetById(Guid id);

		Task<IEnumerable<T>> GetAll();

		Task Delete(T obj);

		Task Update(T obj);

		IEnumerable<T> GetIncludes(params Expression<Func<T, Object>>[] includes);

	}
}
