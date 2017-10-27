namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV20 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BPMConfig_AssocDealerDealerAssociation", "BPMConfig_DealerId");
            CreateIndex("dbo.BPMConfig_AssocDealerDealerAssociation", "BPMConfig_DealerAssociationId");
            AddForeignKey("dbo.BPMConfig_AssocDealerDealerAssociation", "BPMConfig_DealerId", "dbo.BPMConfig_Dealer", "Id", cascadeDelete: false);
            AddForeignKey("dbo.BPMConfig_AssocDealerDealerAssociation", "BPMConfig_DealerAssociationId", "dbo.BPMConfig_DealerAssociation", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BPMConfig_AssocDealerDealerAssociation", "BPMConfig_DealerAssociationId", "dbo.BPMConfig_DealerAssociation");
            DropForeignKey("dbo.BPMConfig_AssocDealerDealerAssociation", "BPMConfig_DealerId", "dbo.BPMConfig_Dealer");
            DropIndex("dbo.BPMConfig_AssocDealerDealerAssociation", new[] { "BPMConfig_DealerAssociationId" });
            DropIndex("dbo.BPMConfig_AssocDealerDealerAssociation", new[] { "BPMConfig_DealerId" });
        }
    }
}
