namespace WebShopKBS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
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
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Type = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.CustomerCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Bill = c.Int(nullable: false),
                        TotalDiscount = c.Int(nullable: false),
                        BillAfterDiscount = c.Int(nullable: false),
                        BonusCreditSpent = c.Int(nullable: false),
                        Customer_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Username)
                .Index(t => t.Customer_Username);
            
            CreateTable(
                "dbo.OrderDiscounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Percentage = c.Int(nullable: false),
                        IsBasic = c.Boolean(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        RecordLastUpdated = c.DateTime(nullable: false),
                        ShouldRefill = c.Boolean(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                        Category_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.Category_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxDiscount = c.Int(nullable: false),
                        Category_Id = c.Int(),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.Category_Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.Category_Id)
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
            DropForeignKey("dbo.Items", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Items", "Category_Id", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemCategories", "Category_Id", "dbo.ItemCategories");
            DropForeignKey("dbo.OrderDiscounts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Username", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Category_Id", "dbo.CustomerCategories");
            DropIndex("dbo.ItemCategories", new[] { "Sale_Id" });
            DropIndex("dbo.ItemCategories", new[] { "Category_Id" });
            DropIndex("dbo.Items", new[] { "Order_Id" });
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropIndex("dbo.OrderDiscounts", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Username" });
            DropIndex("dbo.Customers", new[] { "Category_Id" });
            DropTable("dbo.Sales");
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Items");
            DropTable("dbo.OrderDiscounts");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerCategories");
        }
    }
}
