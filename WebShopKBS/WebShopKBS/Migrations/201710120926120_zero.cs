namespace WebShopKBS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zero : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Customers");
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
            
            AlterColumn("dbo.Customers", "BonusCredits", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Customers", "BonusCredits", c => c.Int());
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            RenameTable(name: "dbo.Customers", newName: "Users");
        }
    }
}
