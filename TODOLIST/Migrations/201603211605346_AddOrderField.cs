namespace TODOLIST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoListItems", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoListItems", "Order");
        }
    }
}
