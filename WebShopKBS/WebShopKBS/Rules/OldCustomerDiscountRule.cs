using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(8)]
	public class OldCustomerDiscountRule:Rule
	{
		public override void Define()
		{
			Order order = null;
			When().Match<Order>(() => order, o => o.Customer.OverTwoYears());
			Then().Do(ctx => AddDiscountToBill(order));
		}

		private void AddDiscountToBill(Order order)
		{
			order.Discounts.Add(new OrderDiscount(1, false));
			System.Diagnostics.Debug.WriteLine("OldCustomerDiscountRule");
		}

	}
}