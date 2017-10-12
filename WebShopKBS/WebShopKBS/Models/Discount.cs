using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public abstract class Discount
    {

	    public int Id { get; set; }
	    public int Percentage { get; set; }
	    public Order Order { get; set; }
		public bool IsBasic { get; set; }
    }
}
