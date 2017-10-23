using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(6)]
	public class OnSaleRule:Rule
	{
		
		public override void Define()
		{
			List<Sale> sales = null;
			Order order = null;

			When().Match<Order>(() => order)
				.Query(() => sales,
					s => s.Match<Sale>(ss => ss.StartsAt > order.DateTime && ss.EndsAt < order.DateTime)
						.Collect());
			Then().Do(ctx => AddDiscounts(sales.ToList(), order));
		}

		public void AddDiscounts(List<Sale> sales, Order order)
		{
			foreach (var orderItem in order.Items)
			{
				foreach (var sale in sales)
				{
					if (sale.Categories.Contains(orderItem.Item.Category))
					{
						orderItem.Discounts.Add(new ItemDiscount(sale.Discount,false));
					}
				}
			}
			System.Diagnostics.Debug.WriteLine("OnSaleRule");
		}
	}
}