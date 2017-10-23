using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(3)]
	public class MassConsumptionAnd5k:Rule
	{
		public override void Define()
		{
			OrderItem item = null;

			When().Match<OrderItem>(() => item, oi => oi.TotalPrice > 5000 && oi.Item.Category.Name == "MassConsumption");

			Then().Do(ctx => AddDiscounts(item));
		}

		public void AddDiscounts(OrderItem orderItem)
		{
			orderItem.Discounts.Add(new ItemDiscount(7, true));
			
			System.Diagnostics.Debug.WriteLine("Mass Consumption and 5k rule");
		}
	}
}