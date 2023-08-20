using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoorraadSysteem.Models;
using VoorraadSysteem.Data;

namespace VoorraadSysteem.Data.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationDbContext _context;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public TEntity Add(TEntity entity)
		{
			return _context.Set<TEntity>().Add(entity).Entity;
		}

		public IEnumerable<TEntity> All()
		{
			return _context.Set<TEntity>().AsEnumerable();
		}

		public void Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public async Task<TEntity> Find(int id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public IQueryable<TEntity> Search()
		{
			return _context.Set<TEntity>().AsQueryable();
		}

		public TEntity Update(TEntity entity)
		{
			return _context.Set<TEntity>().Update(entity).Entity;
		}
	}
}
