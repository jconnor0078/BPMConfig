namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV30 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BPM_DealerContact", name: "CreatUserId", newName: "CreatorUserId");
            RenameColumn(table: "dbo.BPM_DealerContact", name: "LastModifUserId", newName: "LastModifierUserId");
            RenameColumn(table: "dbo.BPM_DealerContactType", name: "CreatUserId", newName: "CreatorUserId");
            RenameColumn(table: "dbo.BPM_DealerContactType", name: "LastModifUserId", newName: "LastModifierUserId");
            RenameColumn(table: "dbo.BPMConfig_Dealer", name: "CreatUserId", newName: "CreatorUserId");
            RenameColumn(table: "dbo.BPMConfig_Dealer", name: "LastModifUserId", newName: "LastModifierUserId");
            RenameColumn(table: "dbo.BPMConfig_DealerAssociation", name: "CreatUserId", newName: "CreatorUserId");
            RenameColumn(table: "dbo.BPMConfig_DealerAssociation", name: "LastModifUserId", newName: "LastModifierUserId");
            RenameColumn(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "CreatUserId", newName: "CreatorUserId");
            RenameColumn(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "LastModifUserId", newName: "LastModifierUserId");
            RenameIndex(table: "dbo.BPM_DealerContact", name: "IX_CreatUserId", newName: "IX_CreatorUserId");
            RenameIndex(table: "dbo.BPM_DealerContact", name: "IX_LastModifUserId", newName: "IX_LastModifierUserId");
            RenameIndex(table: "dbo.BPM_DealerContactType", name: "IX_CreatUserId", newName: "IX_CreatorUserId");
            RenameIndex(table: "dbo.BPM_DealerContactType", name: "IX_LastModifUserId", newName: "IX_LastModifierUserId");
            RenameIndex(table: "dbo.BPMConfig_Dealer", name: "IX_CreatUserId", newName: "IX_CreatorUserId");
            RenameIndex(table: "dbo.BPMConfig_Dealer", name: "IX_LastModifUserId", newName: "IX_LastModifierUserId");
            RenameIndex(table: "dbo.BPMConfig_DealerAssociation", name: "IX_CreatUserId", newName: "IX_CreatorUserId");
            RenameIndex(table: "dbo.BPMConfig_DealerAssociation", name: "IX_LastModifUserId", newName: "IX_LastModifierUserId");
            RenameIndex(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "IX_CreatUserId", newName: "IX_CreatorUserId");
            RenameIndex(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "IX_LastModifUserId", newName: "IX_LastModifierUserId");
            AddColumn("dbo.BPM_DealerContact", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BPM_DealerContact", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.BPM_DealerContactType", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BPM_DealerContactType", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.BPMConfig_Dealer", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BPMConfig_Dealer", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.BPMConfig_DealerAssociation", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BPMConfig_DealerAssociation", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.BPMConfig_AssocDealerDealerAssociation", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BPMConfig_AssocDealerDealerAssociation", "LastModificationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BPMConfig_AssocDealerDealerAssociation", "LastModificationTime");
            DropColumn("dbo.BPMConfig_AssocDealerDealerAssociation", "CreationTime");
            DropColumn("dbo.BPMConfig_DealerAssociation", "LastModificationTime");
            DropColumn("dbo.BPMConfig_DealerAssociation", "CreationTime");
            DropColumn("dbo.BPMConfig_Dealer", "LastModificationTime");
            DropColumn("dbo.BPMConfig_Dealer", "CreationTime");
            DropColumn("dbo.BPM_DealerContactType", "LastModificationTime");
            DropColumn("dbo.BPM_DealerContactType", "CreationTime");
            DropColumn("dbo.BPM_DealerContact", "LastModificationTime");
            DropColumn("dbo.BPM_DealerContact", "CreationTime");
            RenameIndex(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "IX_LastModifierUserId", newName: "IX_LastModifUserId");
            RenameIndex(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "IX_CreatorUserId", newName: "IX_CreatUserId");
            RenameIndex(table: "dbo.BPMConfig_DealerAssociation", name: "IX_LastModifierUserId", newName: "IX_LastModifUserId");
            RenameIndex(table: "dbo.BPMConfig_DealerAssociation", name: "IX_CreatorUserId", newName: "IX_CreatUserId");
            RenameIndex(table: "dbo.BPMConfig_Dealer", name: "IX_LastModifierUserId", newName: "IX_LastModifUserId");
            RenameIndex(table: "dbo.BPMConfig_Dealer", name: "IX_CreatorUserId", newName: "IX_CreatUserId");
            RenameIndex(table: "dbo.BPM_DealerContactType", name: "IX_LastModifierUserId", newName: "IX_LastModifUserId");
            RenameIndex(table: "dbo.BPM_DealerContactType", name: "IX_CreatorUserId", newName: "IX_CreatUserId");
            RenameIndex(table: "dbo.BPM_DealerContact", name: "IX_LastModifierUserId", newName: "IX_LastModifUserId");
            RenameIndex(table: "dbo.BPM_DealerContact", name: "IX_CreatorUserId", newName: "IX_CreatUserId");
            RenameColumn(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "LastModifierUserId", newName: "LastModifUserId");
            RenameColumn(table: "dbo.BPMConfig_AssocDealerDealerAssociation", name: "CreatorUserId", newName: "CreatUserId");
            RenameColumn(table: "dbo.BPMConfig_DealerAssociation", name: "LastModifierUserId", newName: "LastModifUserId");
            RenameColumn(table: "dbo.BPMConfig_DealerAssociation", name: "CreatorUserId", newName: "CreatUserId");
            RenameColumn(table: "dbo.BPMConfig_Dealer", name: "LastModifierUserId", newName: "LastModifUserId");
            RenameColumn(table: "dbo.BPMConfig_Dealer", name: "CreatorUserId", newName: "CreatUserId");
            RenameColumn(table: "dbo.BPM_DealerContactType", name: "LastModifierUserId", newName: "LastModifUserId");
            RenameColumn(table: "dbo.BPM_DealerContactType", name: "CreatorUserId", newName: "CreatUserId");
            RenameColumn(table: "dbo.BPM_DealerContact", name: "LastModifierUserId", newName: "LastModifUserId");
            RenameColumn(table: "dbo.BPM_DealerContact", name: "CreatorUserId", newName: "CreatUserId");
        }
    }
}
