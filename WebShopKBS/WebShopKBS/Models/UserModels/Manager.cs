using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models.UserModels
{
    public class Manager:User
    {
	    public Manager()
	    {
		    Type = UserType.Manager;
	    }
	    public Manager(User u) : base(u.Username, u.Password, u.FirstName, u.LastName, UserType.Manager)
		{
	    }
    }
}
