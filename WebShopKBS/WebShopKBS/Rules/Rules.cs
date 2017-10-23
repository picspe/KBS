using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using NRules;
using NRules.Fluent;
using WebShopKBS.Models;

namespace WebShopKBS.Rules
{
	public class Rules
	{
		public static void RunRestockRules(Item item)
		{

			RuleRepository repository = new RuleRepository();
			repository.Load(x => x.From(typeof(RestockRule).Assembly));

			RuleCompiler compiler = new RuleCompiler();
			var sessionFactory = compiler.Compile(repository.GetRuleSets());

			//Create a working session
			var session = sessionFactory.CreateSession();

			session.Insert(item);
			session.Fire();
		}

		public static void RunDiscountRules(Order order, List<Sale> sales)
		{

			RuleRepository repository = new RuleRepository();
			repository.Load(x => x.From(typeof(AddAllItemDiscountsRule).Assembly));

			RuleCompiler compiler = new RuleCompiler();
			var sessionFactory = compiler.Compile(repository.GetRuleSets());

			//Create a working session
			var session = sessionFactory.CreateSession();

			session.Insert(order);
			session.InsertAll(order.Items);
			session.Insert(sales);

			session.Fire();

		}

		public static void RunDiscountRulesForItems(List<OrderItem> items)
		{

			RuleRepository repository = new RuleRepository();
			repository.Load(x => x.From(typeof(AddAllItemDiscountsRule).Assembly));

			RuleCompiler compiler = new RuleCompiler();
			var sessionFactory = compiler.Compile(repository.GetRuleSets());

			//Create a working session
			var session = sessionFactory.CreateSession();

			session.InsertAll(items);


			session.Fire();

		}

		public static void RunCreditsRules(Order order)
		{
			RuleRepository repository = new RuleRepository();
			repository.Load(x => x.From(Assembly.GetExecutingAssembly()));

			RuleCompiler compiler = new RuleCompiler();
			var sessionFactory = compiler.Compile(repository.GetRuleSets());

			//Create a working session
			var session = sessionFactory.CreateSession();
			System.Diagnostics.Debug.WriteLine("After: " + order.Customer.BonusCredits);

			session.Insert(order);
			session.Fire();

			System.Diagnostics.Debug.WriteLine("After: " + order.Customer.BonusCredits);
		}
	}
}