using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace WebShopKBS.Models.UserModels
{
	public class Customer : User
	{
		public string Address { get; set; }
		public int BonusCredits { get; set; }
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual CustomerCategory Category { get; set; }
		public virtual ICollection<Order> History { get; set; }
		public Customer()
		{
			Type = UserType.Customer;
			History = new List<Order>();
			CategoryId = 3;
		}

		public Customer(User u) : base(u.Username, u.Password, u.FirstName, u.LastName, UserType.Customer)
		{
			Type = UserType.Customer;
			History = new List<Order>();
			CategoryId = 3;
		}

		public bool LastNDays(int days, DateTime date, int itemId)
		{ 
			foreach (var order in History)
			{
				var timeSpan = date - order.DateTime;

				var orderItems = order.Items.Where(oi => oi.Item.Id == itemId
				                        && (timeSpan.Days < days));
				if (orderItems.ToList().Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool LastNDaysCategory(int days, DateTime date, int categoryId)
		{
			foreach (var order in History)
			{
				var timeSpan = date - order.DateTime;

				var orderItems = order.Items.Where(oi => oi.Item.CategoryId == categoryId
														 && (timeSpan.Days < days));
				if (orderItems.ToList().Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool OverTwoYears()
		{
			var span = DateTime.Today - RegistrationDate;
			return span.Days > 730;
		}
	}
}
