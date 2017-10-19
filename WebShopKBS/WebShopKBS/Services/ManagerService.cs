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
		public Sale GetSale(int id)
		{
			return sales.Get().Single(s => s.Id == id);
		}

		public IEnumerable<Sale> GetSales()
		{
			return sales.Get().ToList();
		}

		public Sale CreateSale(Sale sale)
		{
			if(!GetSales().Any(s => s.Name.Equals(sale.Name)))
				return sales.Insert(sale);
			return null;
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
		public Item GetItem(int id)
		{
			return items.Get().Single(s => s.Id == id);
		}

		public IEnumerable<Item> GetItems()
		{
			return items.Get().ToList();
		}

		public Item AddItem(Item item)
		{
			if(!GetItems().Any(i => i.Name.Equals(item.Name)))
				return items.Insert(item);
			return null;
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
			if (!GetiItemCategories().Any(i => i.Name.Equals(category.Name)))
				return itemCategories.Insert(category);
			return null;
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
			if (!GetiItemCategories().Any(i => i.Name.Equals(category.Name)))
				return customerCategories.Insert(category);
			return null;
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