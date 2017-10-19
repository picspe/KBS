using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopKBS.Models
{
	public enum RecordStatus { Archived, Active}

    public class Item
    {
	    [Key]
		public int Id { get; set; }
	    public string Name { get; set; }
	    public int CategoryId { get; set; }
	    public int Price { get; set; }
	    public int Count { get; set; }
	    public DateTime RecordLastUpdated { get; set; }
		public bool ShouldRefill { get; set; }
	    public RecordStatus RecordStatus { get; set; }

	    [ForeignKey("CategoryId")]
		public virtual ItemCategory Category { get; set; }

		public void NotifyForRefill() { }
    }
}
