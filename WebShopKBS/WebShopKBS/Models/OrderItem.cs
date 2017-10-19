using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public class OrderItem
    {
		[Key]
		public int OrderItemId { get; set; }
	    public int OrderId { get; set; }
	    public int Index { get; set; }
	    public int ItemId { get; set; }
	    public int Price { get; set; }
	    public int Count { get; set; }
	    public int TotalPrice { get; set; }
	    public int TotalDiscount { get; set; }
	    public int PriceAfterDiscount { get; set; }

	    [ForeignKey("OrderId")]
		public Order Order { get; set; }
		[ForeignKey("ItemId")]
	    public virtual Item Item { get; set; }
		public virtual List<ItemDiscount> Discounts { get; set; }

	    public OrderItem()
	    {
		    Discounts = new List<ItemDiscount>();
	    }
	}
}
