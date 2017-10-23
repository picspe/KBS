using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
	    public String CustomerId { get; set; }
	    public int Bill { get; set; }
	    public int TotalDiscount { get; set; }
	    public int BillAfterDiscount { get; set; }
	    public int BonusCreditSpent { get; set; }
	    public OrderStatus OrderStatus { get; set; }
	    public List<OrderDiscount> Discounts { get; set; }

		[ForeignKey("CustomerId")]
	    public virtual Customer Customer { get; set; }
	    public virtual List<OrderItem> Items { get; set; }

	    public Order()
	    {
			OrderStatus = OrderStatus.Ordered;
			Discounts = new List<OrderDiscount>();
		    Items = new List<OrderItem>();
			DateTime = DateTime.Now;
	    }


	    public void AwardCredits()
	    {
		    Customer.BonusCredits += Customer.Category.GetBonusCredits();
	    }

	    public void CalculateFinalPrice()
	    {
		    int finalPrice = 0;
		    foreach (var item in Items)
		    {
			    finalPrice += item.TotalPrice;
		    }
		    finalPrice = finalPrice * (100 - TotalDiscount) / 100;
		    BillAfterDiscount = finalPrice;
	    }
	}
}
