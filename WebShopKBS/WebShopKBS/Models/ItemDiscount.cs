using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
	public class ItemDiscount : Discount
	{
		public int ItemId { get; set; }

		[ForeignKey("ItemId")]
		public virtual OrderItem Item { get; set; }
    }
}
