using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;
using WebShopKBS.UoW;

namespace WebShopKBS.Services
{
	public class CustomerService
	{
		private readonly UnitOfWork unitOfWork;
		private readonly GenericRepository<Customer> customers;
		private readonly GenericRepository<Order> orders;
		private readonly GenericRepository<Item> items;
		private readonly GenericRepository<Sale> sales;

		public CustomerService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			customers = unitOfWork.CustomersRepository;
			orders = unitOfWork.OrdersRepository;
			sales = unitOfWork.SalesRepository;
			items = unitOfWork.ItemsRepository;
		}

		//Users need to have access to their profile, update it, place orders, get bills and confirm payment

		public Customer Get(String username)
		{
			return customers.GetByUsername(username);
		}

		public Order PlaceOrder(Order order)
		{
			order.Customer.History.Add(order);
			order.Customer = null;
			return orders.Insert(order);
		}

		public Order GetBill(Order order, int bonusCredits)
		{
			var salesList = sales.Get().ToList();
			foreach (OrderItem item in order.Items)
			{
				item.Item = items.GetById(item.ItemId);
			}
			order.Customer = customers.GetByUsername(order.CustomerId);
			Rules.Rules.RunDiscountRules(order, salesList);
			Rules.Rules.RunDiscountRulesForItems(order.Items);
			order.CalculateFinalPrice();
			order.BillAfterDiscount = order.BillAfterDiscount - bonusCredits;
			order.Customer.BonusCredits -= bonusCredits;

			return order;
		}
	}
}