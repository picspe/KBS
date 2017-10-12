using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShopKBS.Models.UserModels;

namespace WebShopKBS.Models
{
	public enum OrderStatus { Ordered, Canceled, Completed }
    public class Order
    {
	    [Key]
		public int Id { get; set; }
	    public DateTime DateTime { get; set; }
	    public Customer Customer { get; set; }
	    public int Bill { get; set; }
	    public int TotalDiscount { get; set; }
	    public int BillAfterDiscount { get; set; }
	    public int BonusCreditSpent { get; set; }
	    public List<OrderDiscount> Discounts { get; set; }
	    public List<Item> Items { get; set; }

	    public Order()
	    {
			Discounts = new List<OrderDiscount>();
		    Items = new List<Item>();
	    }

    }
}
