using System;
using System.Collections.Generic;
using System.Linq;
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

		public CustomerService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			customers = unitOfWork.CustomersRepository;
			orders = unitOfWork.OrdersRepository;
		}

		//Users need to have access to their profile, update it, place orders, get bills and confirm payment

		public Customer Get(String username)
		{
			return customers.GetByUsername(username);
		}

		public Order PlaceOrder(Order order)
		{
			return orders.Insert(order);
		}

		public Order GetBill(Order order)
		{
			//insert logic for getting bills here
			//fire all the rules for ordering
			return null;
		}
	}
}