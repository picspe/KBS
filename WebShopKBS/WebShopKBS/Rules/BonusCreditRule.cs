using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	public class BonusCreditRule: Rule
	{
		public override void Define()
		{
			Order order = null;

			When()
				.Match<Order>(() => order);
			Then().Do(ctx => order.AwardCredits());

		}
	}
}