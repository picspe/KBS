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
	[RoutePrefix("customer")]
    public class CustomerController : ApiController,IRequiresSessionState
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
	    public IHttpActionResult GetBill([FromBody] Order order)
	    {
		    var bonusCreditsSpent = 0;
		    var bill = service.GetBill(order, bonusCreditsSpent);
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

	    [Route("cart")]
	    public IHttpActionResult AddToCart(Item item)
	    {
		    if (HttpContext.Current.Session["cart"] == null)
			    HttpContext.Current.Session["cart"] = new BillDTO();

			(HttpContext.Current.Session["cart"] as BillDTO).Items.Add(item);

			return Ok(HttpContext.Current.Session["cart"]);
	    }

	    [Route("cart")]
		[HttpGet]
	    public IHttpActionResult GetCart()
	    {
		    return Ok(HttpContext.Current.Session["cart"]);
	    }

	    [Route("removeFromCart")]
	    [HttpPost]
	    public IHttpActionResult RemoveFromCart(Item item)
	    {
		    var cart = (HttpContext.Current.Session["cart"] as BillDTO);
		    Item itemToRemove = null;
		    foreach (var cartItem in cart.Items)
		    {
			    if (item.Name.Equals(cartItem.Name))
				    itemToRemove = cartItem;
		    }
		    cart.Items.Remove(itemToRemove);
		    HttpContext.Current.Session["cart"] = cart;
			return Ok(HttpContext.Current.Session["cart"]);

	    }
 	}
}
