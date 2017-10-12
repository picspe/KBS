using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
    public class Sale
    {
		[Key]
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public DateTime StartsAt { get; set; }
	    public DateTime EndsAt { get; set; }
	    public int Discount { get; set; }
	    public List<ItemCategory> Categories { get; set; }

	    public Sale()
	    {
		    Categories = new List<ItemCategory>();
	    }

    }
}
