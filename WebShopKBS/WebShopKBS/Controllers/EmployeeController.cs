using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopKBS.Models;
using WebShopKBS.Services;
using WebShopKBS.UoW;

namespace WebShopKBS.Controllers
{
	[RoutePrefix("employee")]
    public class EmployeeController : ApiController
    {
	    private readonly EmployeeService service;

	    public EmployeeController()
	    {
		    service = new EmployeeService(new UnitOfWork());
	    }

	    [Route("updateOrder")]
	    [HttpPost]
	    public IHttpActionResult UpdateOrder([FromBody] Order order)
	    {
		    var returnOrder = service.UpdateOrder(order);
		    if (returnOrder != null)
			    return Ok();
		    return BadRequest("Order not Found");
	    }

	    [Route("restock")]
	    [HttpPost]
	    public IHttpActionResult Restock([FromBody] List<Item> restockList)
	    {
		    try
		    {
			    service.RequestRestock(restockList);
			    return Ok();
		    }
		    catch (Exception)
		    {
			    return BadRequest();
		    }
	    }

	    [Route("orders")]
	    [HttpGet]
	    public IEnumerable<Order> GetOrders()
	    {
		    return service.GetOrders();
	    }

	    [Route("items")]
	    [HttpGet]
	    public IEnumerable<Item> GetItems()
	    {
		    return service.GetItems();
	    }
	}
}
