using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public class OrderDiscount:Discount
    {
	    public OrderDiscount(int percentage, bool basic)
	    {
		    Percentage = percentage;
		    IsBasic = basic;
	    }

    }
}
