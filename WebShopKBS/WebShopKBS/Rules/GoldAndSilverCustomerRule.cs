using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(9)]
	public class GoldAndSilverCustomerRule: Rule
	{
		public override void Define()
		{
			Order order = null;
			When().Match<Order>(() => order, o => o.Customer.Category.Name == "gold" || o.Customer.Category.Name == "silver");
			Then().Do(ctx => AddDiscountToBill(order));
		}

		private void AddDiscountToBill(Order order)
		{
			order.Discounts.Add(new OrderDiscount(1, false));
			System.Diagnostics.Debug.WriteLine("Gold And Silver Rule Ran");
		}
	}
}