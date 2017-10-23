using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopKBS.Models
{
	public class BillDTO
	{
		public List<Item> Items { get; set; }

		public BillDTO()
		{
			Items = new	List<Item>();
		}
	}
}