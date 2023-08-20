using System.Threading.Tasks;
using VoorraadSysteem.Data.Repository;
using VoorraadSysteem.Models;

namespace VoorraadSysteem.Data.UnitOfWork
{
	public interface IUnitOfWork
	{
		IGenericRepository<Location> LocationRepository { get; }
		IGenericRepository<Product> ProductRepository { get; }
		IGenericRepository<Stock> StockRepository { get; }
		IGenericRepository<Store> StoreRepository { get; }
		IGenericRepository<Ticket> TicketRepository { get; }
		IGenericRepository<VatPercentage> VatPercentageRepository { get; }
		Task Save();
	}
}
