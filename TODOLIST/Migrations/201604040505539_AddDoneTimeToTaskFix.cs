namespace TODOLIST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoneTimeToTaskFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoListItems", "DoneTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoListItems", "DoneTime", c => c.DateTime(nullable: false));
        }
    }
}
