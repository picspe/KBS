﻿using System;
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
	    public virtual DbSet<OrderItem> OrderItems { get; set; }
		public virtual DbSet<Item> Items  { get; set; }
	    public virtual DbSet<ItemCategory> ItemCategories  { get; set; }
	    public virtual DbSet<Sale> Sales { get; set; }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<ItemCategory>()
			    .HasMany(c => c.ChildCategories)
			    .WithOptional(c => c.ParentCategory)
			    .HasForeignKey(c => c.ParentCategoryId);

		    modelBuilder.Entity<Order>()
			    .HasMany(s => s.Items)
			    .WithRequired(d => d.Order)
			    .HasForeignKey(d => d.OrderId);

		    modelBuilder.Entity<Customer>()
			    .HasMany(s => s.History)
			    .WithRequired(o => o.Customer)
			    .HasForeignKey(o => o.CustomerId);

			modelBuilder.Entity<OrderItem>()
			    .HasMany(s => s.Discounts)
			    .WithRequired(d => d.Item)
			    .HasForeignKey(d => d.ItemId).WillCascadeOnDelete(false);

		    modelBuilder.Entity<CustomerCategory>()
			    .HasMany(c => c.Customers)
				.WithRequired(c => c.Category)
				.HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(false);
		}
	}
}
