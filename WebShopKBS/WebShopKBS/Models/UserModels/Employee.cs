using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models.UserModels
{
    public class Employee:User
    {
	    public Employee(User u) : base(u.Username, u.Password, u.FirstName, u.LastName, UserType.Employee)
		{
	    }
    }
}
