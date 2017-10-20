using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models.UserModels
{
	public class CustomerCategory
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int MinCapValue { get; set; }
		public int MaxCapValue { get; set; }

		public virtual ICollection<Customer> Customers { get; set; }

		public float GetBonusTokens()
		{
			return 0;
		}
	
	}
}
