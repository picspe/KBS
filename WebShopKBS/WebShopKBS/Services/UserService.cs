using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Web;
using WebShopKBS.Models.UserModels;
using WebShopKBS.UoW;

namespace WebShopKBS.Services
{
	public class UserService
	{
		private readonly UnitOfWork unitOfWork;
		private readonly GenericRepository<Customer> customers;
		private readonly GenericRepository<Employee> employees;
		private readonly GenericRepository<Manager> managers;

		public UserService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			customers = this.unitOfWork.CustomersRepository;
			employees = this.unitOfWork.EmployeesRepository;
			managers = this.unitOfWork.ManagersRepository;
		}

		//ATACH USER TYPE WHEN SENDING REGISTER MODEL FROM FRONTEND
		public User Register(User user)
		{
			switch (user.Type)
			{
				case UserType.Customer:
					if (customers.GetByUsername(user.Username) == null)
					{
						var customer = new Customer(user);
						return customers.Insert(customer);
					}
					return null;
				case UserType.Employee:
					if (employees.GetByUsername(user.Username) == null)
					{
						var employee = new Employee(user);
						return employees.Insert(employee);
					}
					return null;
				case UserType.Manager:
					if (managers.GetByUsername(user.Username) == null)
					{
						var manager = new Manager(user);
						return managers.Insert(manager);
					}
					return null;
			}
			return null;
		}

		public User Login(User user)
		{
			try
			{
				switch (user.Type)
				{
					case UserType.Customer:
						return customers.Get().Single(u => u.Username == user.Username && u.Password == user.Password);
					case UserType.Employee:
						return employees.Get().Single(u => u.Username == user.Username && u.Password == user.Password);
					//Kada se zaposleni uloguje treba da se upale sva pravila za porucivanje, i nakon svake porudzbine se provere opet
					case UserType.Manager:
						return managers.Get().Single(u => u.Username == user.Username && u.Password == user.Password);
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}