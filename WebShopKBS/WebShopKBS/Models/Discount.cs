using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public abstract class Discount
    {

	    public int Id { get; set; }
	    public int Percentage { get; set; }
	    public int OrderId { get; set; }
		public bool IsBasic { get; set; }

	    public virtual Order Order { get; set; }
	}
}
