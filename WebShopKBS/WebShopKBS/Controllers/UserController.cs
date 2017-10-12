using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;
using WebShopKBS.Services;
using WebShopKBS.UoW;

namespace WebShopKBS.Controllers
{
	[RoutePrefix("user")]
	public class UserController : ApiController
	{
		private readonly UserService service;

		public UserController()
		{
			service = new UserService(new UnitOfWork());
		}

	    [Route("login")]
	    public IHttpActionResult Login([FromBody] User user)
	    {
		    var returnUser = service.Login(user);
		    if (returnUser == null)
		    {
			    return BadRequest("User not found, please check username/password and try again.");
		    } 
		    return Ok(returnUser);
	    }

		[Route("register")]
		public IHttpActionResult Register([FromBody] User user)
		{
			var returnUser = service.Register(user);
			if (returnUser == null)
			{
				return BadRequest("User already exists.");
			}
			return Ok(returnUser);
		}
	}
}
