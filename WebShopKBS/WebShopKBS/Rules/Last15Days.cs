using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(4)]
	public class Last15Days: Rule
	{
		public override void Define()
		{
			Order order = null;
			OrderItem item = null;
			When()
				.Match<OrderItem>(() => item)
				.Match<Order>(() => order, o => o.Customer.LastNDays(15, DateTime.Today, item.ItemId));
				
			Then().Do(ctx => AddDiscounts(item));
		}

		public void AddDiscounts(OrderItem orderItem)
		{

				orderItem.Discounts.Add(new ItemDiscount(2, false));

			System.Diagnostics.Debug.WriteLine("Last 15 days Rule");
		}
	}
}