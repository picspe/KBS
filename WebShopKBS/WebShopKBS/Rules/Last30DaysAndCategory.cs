using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(5)]
	public class Last30DaysAndCategory:Rule
	{
		public override void Define()
		{
			Order order = null;
			OrderItem item = null;

			When()
				.Match<OrderItem>(() => item)
				.Match<Order>(() => order, o => o.Customer.LastNDaysCategory(30, DateTime.Today, item.Item.CategoryId));
			Then().Do(ctx => AddDiscounts(item));
		}

		public void AddDiscounts(OrderItem orderItem)
		{
			orderItem.Discounts.Add(new ItemDiscount(2, false));
			
			System.Diagnostics.Debug.WriteLine("Last 30 Days Rule");
		}
	}
}