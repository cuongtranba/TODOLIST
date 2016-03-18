namespace TODOLIST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDoListItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoListItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        IsDone = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoListItems");
        }
    }
}
