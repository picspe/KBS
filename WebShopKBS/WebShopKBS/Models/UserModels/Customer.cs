using System;
using System.Collections.Generic;


namespace WebShopKBS.Models.UserModels
{
	public class Customer: User
    {
	    public string Address { get; set; }
	    public int BonusCredits { get; set; }
	    public CustomerCategory Category { get; set; }
	    public List<Order> History { get; set; }

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
