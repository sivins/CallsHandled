namespace CallsHandled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Seconds = c.Int(nullable: false),
                        Resolution = c.String(),
                        Flag = c.Boolean(nullable: false),
                        Details = c.String(maxLength: 1000),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calls");
        }
    }
}
