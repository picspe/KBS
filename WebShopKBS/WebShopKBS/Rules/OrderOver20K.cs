using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(10)]
	public class OrderOver20K: Rule
	{
		public override void Define()
		{
			Order order = null;
			When().Match<Order>(() => order, o => o.Bill > 20000);
			Then().Do(ctx => AddDiscountToBill(order));
		}

		private void AddDiscountToBill(Order order)
		{
			order.Discounts.Add(new OrderDiscount(5, true));
			System.Diagnostics.Debug.WriteLine("Order over 20k rule");
		}

	}
}