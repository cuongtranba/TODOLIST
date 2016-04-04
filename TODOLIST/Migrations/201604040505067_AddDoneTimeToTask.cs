namespace TODOLIST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoneTimeToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoListItems", "DoneTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoListItems", "DoneTime");
        }
    }
}
