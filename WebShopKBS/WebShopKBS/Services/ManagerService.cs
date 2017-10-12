using System.Collections.Generic;
using System.Linq;
using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;
using WebShopKBS.UoW;

namespace WebShopKBS.Services
{
	public class ManagerService
	{
		private readonly GenericRepository<CustomerCategory> customerCategories;
		private readonly GenericRepository<ItemCategory> itemCategories;
		private readonly GenericRepository<Item> items;

		private readonly GenericRepository<Sale> sales;
		private readonly UnitOfWork unitOfWork;

		public ManagerService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			sales = unitOfWork.SalesRepository;
			items = unitOfWork.ItemsRepository;
			itemCategories = unitOfWork.ItemCategoriesRepository;
			customerCategories = unitOfWork.CustomerCategoriesRepository;
		}

		#region MANAGER UTILITIES

		#endregion

		#region MANAGER CRUD ACTIONS

		//Sales
		public IEnumerable<Sale> GetSales()
		{
			return sales.Get().ToList();
		}

		public Sale CreateSale(Sale sale)
		{
			return sales.Insert(sale);
		}

		public Sale UpdateSale(Sale sale)
		{
			return sales.Update(sale);
		}

		public Sale EndSale(int id)
		{
			return sales.Delete(id);
		}

		//Items
		public IEnumerable<Item> GetItems()
		{
			return items.Get().ToList();
		}

		public Item AddItem(Item item)
		{
			return items.Insert(item);
		}

		public Item UpdateItem(Item item)
		{
			return items.Update(item);
		}

		public Item RemoveItem(int id)
		{
			return items.Delete(id);
		}

		//Item Categories
		public IEnumerable<ItemCategory> GetiItemCategories()
		{
			return itemCategories.Get().ToList();
		}

		public ItemCategory CreateItemCategory(ItemCategory category)
		{
			return itemCategories.Insert(category);
		}

		public ItemCategory UpdateItemCategory(ItemCategory itemCategory)
		{
			return itemCategories.Update(itemCategory);
		}

		public ItemCategory RemoveItemCategory(int id)
		{
			return itemCategories.Delete(id);
		}


		//Customer Categories
		public IEnumerable<CustomerCategory> GetCustomerCategories()
		{
			return customerCategories.Get().ToList();
		}

		public CustomerCategory CreateCustomerCategory(CustomerCategory category)
		{
			return customerCategories.Insert(category);
		}

		public CustomerCategory UpdatecCustomerCategory(CustomerCategory category)
		{
			return customerCategories.Update(category);
		}

		public CustomerCategory RemoveCustomerCategory(int id)
		{
			return customerCategories.Delete(id);
		}

		#endregion
	}
}