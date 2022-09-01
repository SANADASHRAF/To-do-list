namespace todo_list.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.achaivements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        targeet = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.achaivements");
        }
    }
}
