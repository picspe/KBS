using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NRules.Fluent.Dsl;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	public class RestockRule:Rule
	{
		public override void Define()
		{
			Item item = null;

			When().Match<Item>(() => item, i => i.Count < i.MinCount);
			Then().Do(ctx => item.RequestRefill());
		}
	}
}