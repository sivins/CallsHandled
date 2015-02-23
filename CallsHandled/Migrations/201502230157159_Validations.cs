namespace CallsHandled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calls", "ResolutionList_DataGroupField", c => c.String());
            AddColumn("dbo.Calls", "ResolutionList_DataTextField", c => c.String());
            AddColumn("dbo.Calls", "ResolutionList_DataValueField", c => c.String());
            AlterColumn("dbo.Calls", "Resolution", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calls", "Resolution", c => c.String());
            DropColumn("dbo.Calls", "ResolutionList_DataValueField");
            DropColumn("dbo.Calls", "ResolutionList_DataTextField");
            DropColumn("dbo.Calls", "ResolutionList_DataGroupField");
        }
    }
}
