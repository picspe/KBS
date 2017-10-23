using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(2)]
	public class TechCategoryDiscountRule: Rule
	{
		public override void Define()
		{
			OrderItem item = null;
			When().Match(() => item, oi => oi.Count > 5,
				oi => oi.Item.Category.Name == "TV"
				      || oi.Item.Category.Name == "PC"
				      || oi.Item.Category.Name == "Laptop");
				
			Then().Do(ctx => AddDiscounts(item));
		}

		public void AddDiscounts(OrderItem orderItem)
		{
			orderItem.Discounts.Add(new ItemDiscount(5, true));

			System.Diagnostics.Debug.WriteLine("TechCategoryDiscountRule");
		}
	}
}