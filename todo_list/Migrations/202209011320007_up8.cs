namespace todo_list.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.notes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.notes");
        }
    }
}
