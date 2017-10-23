namespace WebShopKBS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinCapValue = c.Int(nullable: false),
                        MaxCapValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        BonusCredits = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Type = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.CustomerCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Bill = c.Int(nullable: false),
                        TotalDiscount = c.Int(nullable: false),
                        BillAfterDiscount = c.Int(nullable: false),
                        BonusCreditSpent = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderDiscounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Percentage = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        IsBasic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        TotalDiscount = c.Int(nullable: false),
                        PriceAfterDiscount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemDiscounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Percentage = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        IsBasic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.OrderItems", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        MinCount = c.Int(nullable: false),
                        RecordLastUpdated = c.DateTime(nullable: false),
                        ShouldRefill = c.Boolean(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(),
                        MaxDiscount = c.Int(nullable: false),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ParentCategoryId)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.ParentCategoryId)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Type = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Type = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartsAt = c.DateTime(nullable: false),
                        EndsAt = c.DateTime(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemCategories", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Customers", "CategoryId", "dbo.CustomerCategories");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemCategories", "ParentCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemDiscounts", "ItemId", "dbo.OrderItems");
            DropForeignKey("dbo.ItemDiscounts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDiscounts", "OrderId", "dbo.Orders");
            DropIndex("dbo.ItemCategories", new[] { "Sale_Id" });
            DropIndex("dbo.ItemCategories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.ItemDiscounts", new[] { "OrderId" });
            DropIndex("dbo.ItemDiscounts", new[] { "ItemId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderDiscounts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "CategoryId" });
            DropTable("dbo.Sales");
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Items");
            DropTable("dbo.ItemDiscounts");
            DropTable("dbo.OrderItems");
            DropTable("dbo.OrderDiscounts");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerCategories");
        }
    }
}
