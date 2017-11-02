namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV50 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BPMConfig_Dealer", "RNC", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BPMConfig_Dealer", "RNC");
        }
    }
}
