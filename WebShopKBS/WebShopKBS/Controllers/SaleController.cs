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
    public class SaleController : ApiController
    {
	    private readonly ManagerService service;

	    public SaleController()
	    {
		    service = new ManagerService(new UnitOfWork());
	    }

	    public Sale Get(int id)
	    {
		    return service.GetSale(id);
	    }

	    // GET: api/CustomerCategory
	    public IEnumerable<Sale> Get()
	    {
		    return service.GetSales();
	    }

	    // POST: api/CustomerCategory
	    public IHttpActionResult Post([FromBody]Sale sale)
	    {
		    var returnSale = service.CreateSale(sale);
		    if (returnSale == null)
		    {
			    return BadRequest("Sale Already Exists.");
		    }
		    return Ok(returnSale);
	    }

	    // PUT: api/CustomerCategory/5
	    public IHttpActionResult Put([FromBody]Sale sale)
	    {
		    var returnSale = service.UpdateSale(sale);
		    if (returnSale == null)
		    {
			    return BadRequest("Sale not found.");
		    }
		    return Ok(returnSale);
	    }

	    // DELETE: api/CustomerCategory/5
	    public IHttpActionResult Delete(int id)
	    {
		    var returnSale = service.EndSale(id);
		    if (returnSale == null)
		    {
			    return BadRequest("Sale not found.");
		    }
		    return Ok(returnSale);
	    }
	}
}
