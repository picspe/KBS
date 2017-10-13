using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebShopKBS.Models.UserModels;

namespace WebShopKBS.Models
{
    public class AppDbContext:DbContext
    {
	    public AppDbContext()
	    {
		}

	    public virtual DbSet<Customer> Customers { get; set; }
	    public virtual DbSet<Employee> Employees{ get; set; }
	    public virtual DbSet<Manager> Managers{ get; set; }
	    public virtual DbSet<CustomerCategory> CustomerCategories  { get; set; }
	    public virtual DbSet<Order> Orders  { get; set; }
	    public virtual DbSet<Item> Items  { get; set; }
	    public virtual DbSet<ItemCategory> ItemCategories  { get; set; }
	    public virtual DbSet<Sale> Sales { get; set; }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
		    //one-to-many 
		    modelBuilder.Entity<Order>()
			    .HasRequired<Customer>(l => l.Customer)
			    .WithMany(b => b.History)
			    .HasForeignKey(l => l.Customer);
	    }
	}
}
