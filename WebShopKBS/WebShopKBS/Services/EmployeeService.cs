using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopKBS.Models;
using WebShopKBS.UoW;

namespace WebShopKBS.Services
{
	public class EmployeeService
	{
		private readonly UnitOfWork unitOfWork;
		private readonly GenericRepository<Order> orders;
		private readonly GenericRepository<Item> items;

		public EmployeeService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			orders = unitOfWork.OrdersRepository;
			items = unitOfWork.ItemsRepository;
		}

		//Kada se zaposleni uloguje treba da se upale sva pravila za porucivanje, i nakon svake porudzbine se provere opet

		//ZAPOSLENOM TREBA SPISAK SVIH PORUDZBINA I MOGUCNOST PORUCIVANJA ZALIHA I OBRADA PORUDZBINA
		public IEnumerable<Order> GetOrders()
		{
			return orders.Get();
		}

		public IEnumerable<Item> GetItems()
		{
			return items.Get();
		}

		//PORUCIVANJE ZALIHA - prosledjuje se lista itema i za svaku stavku se prosledjena kolicina dodaje u prodavnicu
		public void RequestRestock(List<Item> itemList)
		{
			foreach (var item in itemList)
			{
				//update record
				//fire rules to update items
			}
		}


		//OBRADA PORUDZBINA - obradjuje se jedna po jedna (uvek se na serverside salje samo 1) i updejtuje se kupac o statusu porudzbine
		public Order UpdateOrder(Order orderForUpdate)
		{
			return orders.Update(orderForUpdate);
			//proveri da li treba i kod customer.order da se updejtuje
			//ovde opali pravila za restock
			//maybe update customer category ???
			//fire rules for awarding bonus credits
		}


	}
}