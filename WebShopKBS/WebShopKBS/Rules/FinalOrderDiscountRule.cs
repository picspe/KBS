using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	public class FinalOrderDiscountRule: Rule
	{
		public override void Define()
		{
			Order order = null;
			When().Match<Order>(() => order);
			Then().Do(ctx => AddAllDiscountToBill(order));
		}

		private void AddAllDiscountToBill(Order order)
		{
			int totalDiscount = 0;
			foreach (var orderDiscount in order.Discounts)
			{
				totalDiscount += orderDiscount.Percentage;
			}
			order.TotalDiscount = totalDiscount;
			System.Diagnostics.Debug.WriteLine("Add All Discounts To Bill Rule: " + totalDiscount);
		}
	}
}