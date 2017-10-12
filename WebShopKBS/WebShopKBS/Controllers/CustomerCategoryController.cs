using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopKBS.Models.UserModels;
using WebShopKBS.Services;
using WebShopKBS.UoW;

namespace WebShopKBS.Controllers
{
	public class CustomerCategoryController : ApiController
	{
		private readonly ManagerService service;

		public CustomerCategoryController()
		{
			service = new ManagerService(new UnitOfWork());
		}

		// GET: api/CustomerCategory
		public IEnumerable<CustomerCategory> Get()
		{
			return service.GetCustomerCategories();
		}

		// POST: api/CustomerCategory
		public IHttpActionResult Post([FromBody]CustomerCategory category)
		{
			var returnCategory = service.CreateCustomerCategory(category);
			if (returnCategory == null)
			{
				return BadRequest("Category Already Exists.");
			}
			return Ok(returnCategory);
		}

		// PUT: api/CustomerCategory/5
		public IHttpActionResult Put([FromBody]CustomerCategory category)
		{
			var returnCategory = service.UpdatecCustomerCategory(category);
			if (returnCategory == null)
			{
				return BadRequest("Category not found.");
			}
			return Ok(returnCategory);
		}

		// DELETE: api/CustomerCategory/5
		public IHttpActionResult Delete(int id)
		{
			var returnCategory = service.RemoveCustomerCategory(id);
			if (returnCategory == null)
			{
				return BadRequest("Category not found.");
			}
			return Ok(returnCategory);
		}
	}
}
