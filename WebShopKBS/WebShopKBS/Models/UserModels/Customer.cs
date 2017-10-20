using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebShopKBS.Models.UserModels
{
	public class Customer: User
    {
	    public string Address { get; set; }
	    public int BonusCredits { get; set; }
	    public int? CategoryId { get; set; }
	    public List<Order> History { get; set; }

	    public virtual CustomerCategory Category { get; set; }

		public Customer()
	    {
		    Type = UserType.Customer;
			History = new List<Order>();
	    }

	    public Customer(User u):base(u.Username, u.Password, u.FirstName, u.LastName, UserType.Customer)
	    {
		    Type = UserType.Customer;
		    History = new List<Order>();
		}
	}
}
