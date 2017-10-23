using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using NRules.RuleModel;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	[Priority(7)]
	[Repeatability(RuleRepeatability.Repeatable)]
	public class AddAllItemDiscountsRule:Rule
	{
		
		public override void Define()
		{
			OrderItem orderItem = null;
			
			When().Match(() => orderItem);
			Then().Do(ctx => CalculateAllItemDiscounts(orderItem));
		}

		private void CalculateAllItemDiscounts(OrderItem orderItem)
		{

			var basic = orderItem.GetBestBasicDiscount();
			var totalDiscount = basic;
			foreach (var orderItemDiscount in orderItem.Discounts)
			{
				if (!orderItemDiscount.IsBasic)
				{
					totalDiscount += orderItemDiscount.Percentage;
				}
			}
			orderItem.TotalDiscount = totalDiscount;
			orderItem.PriceAfterDiscount = orderItem.Price * (100 - orderItem.TotalDiscount) / 100;
			orderItem.TotalPrice = orderItem.PriceAfterDiscount * orderItem.Count;

			System.Diagnostics.Debug.WriteLine("Add All Items Discounts Rule: " + orderItem.TotalPrice);
		}
	}
}