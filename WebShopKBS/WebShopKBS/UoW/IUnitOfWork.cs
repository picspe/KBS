

using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;

namespace WebShopKBS.UoW
{
	public interface IUnitOfWork
	{
		GenericRepository<Customer> CustomersRepository { get; }
		GenericRepository<Employee> EmployeesRepository { get; }
		GenericRepository<Manager> ManagersRepository { get; }
		GenericRepository<Order> OrdersRepository { get; }
		GenericRepository<Sale> SalesRepository { get; }
		GenericRepository<Item> ItemsRepository { get; }
		GenericRepository<ItemCategory> ItemCategoriesRepository { get; }
		GenericRepository<CustomerCategory> CustomerCategoriesRepository { get; }
	}
}
