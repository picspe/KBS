using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
	public class ItemCategory
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int MaxDiscount { get; set; }
		public virtual ItemCategory Category { get; set; }

		public override bool Equals(object obj)
		{
			return this.Name.Equals((obj as ItemCategory).Name);
		}
	}
}
