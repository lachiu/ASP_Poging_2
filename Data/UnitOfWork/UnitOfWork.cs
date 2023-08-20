using System.Threading.Tasks;
using VoorraadSysteem.Data.Repository;
using VoorraadSysteem.Models;
using VoorraadSysteem.Data;

namespace VoorraadSysteem.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		private IGenericRepository<Location> locationRepository;
		private IGenericRepository<Product> productRepository;
		private IGenericRepository<Stock> stockRepository;
		private IGenericRepository<Store> storeRepository;
		private IGenericRepository<Ticket> ticketRepository;
		private IGenericRepository<VatPercentage> vatPercentageRepository;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public IGenericRepository<Location> LocationRepository
		{
			get
			{
				if (this.locationRepository == null)
				{
					this.locationRepository = new GenericRepository<Location>(_context);
				}
				return locationRepository;
			}
		}

		public IGenericRepository<Product> ProductRepository
		{
			get
			{
				if (this.productRepository == null)
				{
					this.productRepository = new GenericRepository<Product>(_context);
				}
				return productRepository;
			}
		}

		public IGenericRepository<Stock> StockRepository
		{
			get
			{
				if (this.stockRepository == null)
				{
					this.stockRepository = new GenericRepository<Stock>(_context);
				}
				return stockRepository;
			}
		}

		public IGenericRepository<Store> StoreRepository
		{
			get
			{
				if (this.storeRepository == null)
				{
					this.storeRepository = new GenericRepository<Store>(_context);
				}
				return storeRepository;
			}
		}

		public IGenericRepository<Ticket> TicketRepository
		{
			get
			{
				if (this.ticketRepository == null)
				{
					this.ticketRepository = new GenericRepository<Ticket>(_context);
				}
				return ticketRepository;
			}
		}

		public IGenericRepository<VatPercentage> VatPercentageRepository
		{
			get
			{
				if (this.vatPercentageRepository == null)
				{
					this.vatPercentageRepository = new GenericRepository<VatPercentage>(_context);
				}
				return vatPercentageRepository;
			}
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}