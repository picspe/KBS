using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(1)]
	public class WideConsumptionRule: Rule
	{
		public override void Define()
		{

			OrderItem item = null;
			When().Match<OrderItem>(() => item, oi => oi.Count > 20 && oi.Item.Category.Name != "MassConsumption");

			Then().Do(ctx => AddDiscounts(item));
		}

		public void AddDiscounts(OrderItem orderItem)
		{
			orderItem.Discounts.Add(new ItemDiscount(10 , true));
			System.Diagnostics.Debug.WriteLine("WideConsumptionRule: " + orderItem.ItemId);
		}
	}
}