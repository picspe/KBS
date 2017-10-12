using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public class ItemCategory
    {
	    [Key]
		public int Id { get; set; }
	    public string Name { get; set; }
	    public ItemCategory Category { get; set; }
	    public int MaxDiscount { get; set; }

    }
}
