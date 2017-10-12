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
    public class ItemController : ApiController
    {
	    private readonly ManagerService service;

	    public ItemController()
	    {
		    service = new ManagerService(new UnitOfWork());
	    }

	    // GET: api/CustomerCategory
	    public IEnumerable<Item> Get()
	    {
		    return service.GetItems();
	    }

	    // POST: api/CustomerCategory
	    public IHttpActionResult Post([FromBody]Item item)
	    {
		    var returnItem = service.AddItem(item);
		    if (returnItem == null)
		    {
			    return BadRequest("Item Already Exists.");
		    }
		    return Ok(returnItem);
	    }

	    // PUT: api/CustomerCategory/5
	    public IHttpActionResult Put([FromBody]Item item)
	    {
		    var returnItem = service.UpdateItem(item);
		    if (returnItem == null)
		    {
			    return BadRequest("Item not found.");
		    }
		    return Ok(returnItem);
	    }

	    // DELETE: api/CustomerCategory/5
	    public IHttpActionResult Delete(int id)
	    {
		    var returnItem = service.RemoveItem(id);
		    if (returnItem == null)
		    {
			    return BadRequest("Item not found.");
		    }
		    return Ok(returnItem);
	    }
	}
}
