using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public class ItemDiscount:Discount
    {
	    public Item Item { get; set; }
    }
}
