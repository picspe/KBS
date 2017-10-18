using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;
using WebShopKBS.Services;
using WebShopKBS.UoW;

namespace WebShopKBS.Controllers
{
	[RoutePrefix("user")]
	public class UserController : ApiController, IRequiresSessionState
	{
		private readonly UserService service;

		public UserController()
		{
			service = new UserService(new UnitOfWork());
		}

		[Route("isUserLoggedIn")]
		[HttpGet]
		public IHttpActionResult LoggedIn()
		{
			var activeUser = (User) HttpContext.Current.Session["user"];
			if(activeUser != null)
				return Ok(activeUser);
			return NotFound();
		}

		[Route("login")]
		[HttpPost]
		public IHttpActionResult Login([FromBody] User user)
	    {
		    var returnUser = service.Login(user);
		    if (returnUser == null)
		    {
			    return BadRequest("User not found, please check username/password and try again.");
		    }
		    HttpContext.Current.Session["user"] = returnUser;
		    return Ok(returnUser);
	    }

		[Route("logout")]
		[HttpPost]
		public IHttpActionResult Logout([FromBody] User user)
		{
			HttpContext.Current.Session["user"] = null;
			return Ok();
		}

		[Route("register")]
		[HttpPost]
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
