using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopKBS.Models;
using WebShopKBS.Models.UserModels;
using WebShopKBS.Services;
using WebShopKBS.UoW;

namespace WebShopKBS.Controllers
{
	[RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
	    private readonly CustomerService service;

	    public CustomerController()
	    {
		    service = new CustomerService(new UnitOfWork());
	    }

	    [HttpGet]
	    public IHttpActionResult Get(string username)
	    {
			var customer = service.Get(username);
		    if (customer == null)
			    return NotFound();
		    return Ok(customer);
	    }

	    [Route("order")]
	    [HttpPost]
	    public IHttpActionResult GetBill(Order order)
	    {
		    var bill = service.GetBill(order);
		    if (bill == null)
			    return BadRequest("Something went wrong with forming your bill, please try again later");
		    return Ok(bill);
	    }

	    [Route("confirm")]
	    [HttpPost]
	    public IHttpActionResult PlaceOrder(Order order)
	    {
		    var completedOrder = service.PlaceOrder(order);
		    if (completedOrder == null)
			    return BadRequest("Something went wrong with placing your order, please try again later");
		    return Ok(completedOrder);
	    }

	}
}
