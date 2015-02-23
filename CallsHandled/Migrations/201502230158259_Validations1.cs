namespace CallsHandled.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Calls", "ResolutionList_DataGroupField");
            DropColumn("dbo.Calls", "ResolutionList_DataTextField");
            DropColumn("dbo.Calls", "ResolutionList_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calls", "ResolutionList_DataValueField", c => c.String());
            AddColumn("dbo.Calls", "ResolutionList_DataTextField", c => c.String());
            AddColumn("dbo.Calls", "ResolutionList_DataGroupField", c => c.String());
        }
    }
}
