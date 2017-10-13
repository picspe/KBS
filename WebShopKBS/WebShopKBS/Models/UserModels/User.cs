using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models.UserModels
{
	public enum UserType {Customer, Manager, Employee}

    public class User
    {
	    [Key]
		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public UserType Type { get; set; }
	    public DateTime RegistrationDate { get; set; }

	    protected User()
	    {
			RegistrationDate = DateTime.Now;
	    }

	    protected User(string username, string password, string firstName, string lastName, UserType type)
		{
			Username = username;
			Password = password;
			FirstName = firstName;
			LastName = lastName;
			Type = type;
			RegistrationDate = DateTime.Now;
		}
	}
}
