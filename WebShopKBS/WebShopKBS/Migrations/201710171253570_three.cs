namespace WebShopKBS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ItemCategories", name: "ParentCategoryId", newName: "Category_Id");
            RenameIndex(table: "dbo.ItemCategories", name: "IX_ParentCategoryId", newName: "IX_Category_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ItemCategories", name: "IX_Category_Id", newName: "IX_ParentCategoryId");
            RenameColumn(table: "dbo.ItemCategories", name: "Category_Id", newName: "ParentCategoryId");
        }
    }
}
