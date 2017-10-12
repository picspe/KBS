using System;
using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;

namespace WebShopKBS.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private AppDbContext context = new AppDbContext();

		private GenericRepository<Customer> customersRepository;
		private GenericRepository<Employee> employeesRepository;
		private GenericRepository<Manager> managersRepository;
		private GenericRepository<Order> ordersRepository;
		private GenericRepository<Sale> salesRepository;
		private GenericRepository<Item> itemsRepository;
		private GenericRepository<ItemCategory> itemCategoriesRepository;
		private GenericRepository<CustomerCategory> customerCategoriesRepository;

		public GenericRepository<Customer> CustomersRepository
		{
			get
			{
				if (this.customersRepository == null)
				{
					this.customersRepository = new GenericRepository<Customer>(context);
				}
				return customersRepository;
			}
		}

		public GenericRepository<Employee> EmployeesRepository
		{
			get
			{
				if (this.employeesRepository == null)
				{
					this.employeesRepository = new GenericRepository<Employee>(context);
				}
				return employeesRepository;
			}
		}

		public GenericRepository<Manager> ManagersRepository
		{
			get
			{
				if (this.managersRepository == null)
				{
					this.managersRepository = new GenericRepository<Manager>(context);
				}
				return managersRepository;
			}
		}
		public GenericRepository<Order> OrdersRepository
		{
			get
			{
				if (this.ordersRepository == null)
				{
					this.ordersRepository = new GenericRepository<Order>(context);
				}
				return ordersRepository;
			}
		}
		public GenericRepository<Sale> SalesRepository
		{
			get
			{
				if (this.salesRepository == null)
				{
					this.salesRepository = new GenericRepository<Sale>(context);
				}
				return salesRepository;
			}
		}
		public GenericRepository<Item> ItemsRepository
		{
			get
			{
				if (this.itemsRepository == null)
				{
					this.itemsRepository = new GenericRepository<Item>(context);
				}
				return itemsRepository;
			}
		}

		public GenericRepository<ItemCategory> ItemCategoriesRepository
		{
			get
			{
				if (this.itemCategoriesRepository == null)
				{
					this.itemCategoriesRepository = new GenericRepository<ItemCategory>(context);
				}
				return itemCategoriesRepository;
			}
		}

		public GenericRepository<CustomerCategory> CustomerCategoriesRepository
		{
			get
			{
				if (this.customerCategoriesRepository == null)
				{
					this.customerCategoriesRepository = new GenericRepository<CustomerCategory>(context);
				}
				return customerCategoriesRepository;
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}