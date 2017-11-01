namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BPM_DealerContact", "ContactDesc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BPM_DealerContact", "ContactDesc");
        }
    }
}
