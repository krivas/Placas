using System;
using System.Collections.Generic;

namespace ConcentraVHM.Infrastructure.Repositories
{
	public interface ISearch<T>
	{
		Task<IEnumerable<T>> GetQuery(string query);
	}
}

