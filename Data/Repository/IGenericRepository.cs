using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.Data.Repository
{
	public interface IGenericRepository<TEntity> where TEntity: class
	{
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);

		void Delete(TEntity entity);
		Task<TEntity> Find(int id);
		IEnumerable<TEntity> All();
		IQueryable<TEntity> Search();
	}
}