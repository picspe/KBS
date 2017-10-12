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
    public class ItemCategoryController : ApiController
    {
	    private readonly ManagerService service;

	    public ItemCategoryController()
	    {
		    service = new ManagerService(new UnitOfWork());
	    }

	    // GET: api/CustomerCategory
	    public IEnumerable<ItemCategory> Get()
	    {
		    return service.GetiItemCategories();
	    }

	    // POST: api/CustomerCategory
	    public IHttpActionResult Post([FromBody]ItemCategory category)
	    {
		    var returnCategory = service.CreateItemCategory(category);
		    if (returnCategory == null)
		    {
			    return BadRequest("Category Already Exists.");
		    }
		    return Ok(returnCategory);
	    }

	    // PUT: api/CustomerCategory/5
	    public IHttpActionResult Put([FromBody]ItemCategory category)
	    {
		    var returnCategory = service.UpdateItemCategory(category);
		    if (returnCategory == null)
		    {
			    return BadRequest("Category not found.");
		    }
		    return Ok(returnCategory);
	    }

	    // DELETE: api/CustomerCategory/5
	    public IHttpActionResult Delete(int id)
	    {
		    var returnCategory = service.RemoveItemCategory(id);
		    if (returnCategory == null)
		    {
			    return BadRequest("Category not found.");
		    }
		    return Ok(returnCategory);
	    }
	}
}
