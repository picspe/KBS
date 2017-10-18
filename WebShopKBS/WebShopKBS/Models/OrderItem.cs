using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public class OrderItem
    {
	    public Order Order { get; set; }
	    public int Index { get; set; }
	    public virtual Item Item { get; set; }
	    public int Price { get; set; }
	    public int Count { get; set; }
	    public int TotalPrice { get; set; }
	    public int TotalDiscount { get; set; }
	    public int PriceAfterDiscount { get; set; }
	    public virtual List<ItemDiscount> Discounts { get; set; }

	    public OrderItem()
	    {
		    Discounts = new List<ItemDiscount>();
	    }
	}
}
