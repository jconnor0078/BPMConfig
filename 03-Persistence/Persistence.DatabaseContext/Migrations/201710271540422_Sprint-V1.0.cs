namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BPM_DealerContact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false),
                        BPMConfig_DealerId = c.Int(nullable: false),
                        BPM_DealerContactTypeId = c.Int(nullable: false),
                        CreatUserId = c.String(nullable: false, maxLength: 128),
                        LastModifUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BPM_DealerContactType", t => t.BPM_DealerContactTypeId, cascadeDelete: false)
                .ForeignKey("dbo.BPMConfig_Dealer", t => t.BPMConfig_DealerId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifUserId)
                .Index(t => t.BPMConfig_DealerId)
                .Index(t => t.BPM_DealerContactTypeId)
                .Index(t => t.CreatUserId)
                .Index(t => t.LastModifUserId);
            
            CreateTable(
                "dbo.BPM_DealerContactType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        EnumName = c.String(nullable: false),
                        CreatUserId = c.String(nullable: false, maxLength: 128),
                        LastModifUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifUserId)
                .Index(t => t.CreatUserId)
                .Index(t => t.LastModifUserId);
            
            CreateTable(
                "dbo.BPMConfig_Dealer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerCode = c.String(nullable: false),
                        DealerName = c.String(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        DealerPresident = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatUserId = c.String(nullable: false, maxLength: 128),
                        LastModifUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifUserId)
                .Index(t => t.CreatUserId)
                .Index(t => t.LastModifUserId);
            
            CreateTable(
                "dbo.BPMConfig_DealerAssociation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Icon = c.String(),
                        CreatUserId = c.String(nullable: false, maxLength: 128),
                        LastModifUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifUserId)
                .Index(t => t.CreatUserId)
                .Index(t => t.LastModifUserId);
            
            CreateTable(
                "dbo.BPMConfig_AssocDealerDealerAssociation",
                c => new
                    {
                        BPMConfig_DealerId = c.Int(nullable: false),
                        BPMConfig_DealerAssociationId = c.Int(nullable: false),
                        CreatUserId = c.String(nullable: false, maxLength: 128),
                        LastModifUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BPMConfig_DealerId, t.BPMConfig_DealerAssociationId })
                .ForeignKey("dbo.AspNetUsers", t => t.CreatUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifUserId)
                .Index(t => t.CreatUserId)
                .Index(t => t.LastModifUserId);
            
            CreateTable(
                "dbo.BPMConfig_DealerAssociationBPMConfig_Dealer",
                c => new
                    {
                        BPMConfig_DealerAssociation_Id = c.Int(nullable: false),
                        BPMConfig_Dealer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BPMConfig_DealerAssociation_Id, t.BPMConfig_Dealer_Id })
                .ForeignKey("dbo.BPMConfig_DealerAssociation", t => t.BPMConfig_DealerAssociation_Id, cascadeDelete: false)
                .ForeignKey("dbo.BPMConfig_Dealer", t => t.BPMConfig_Dealer_Id, cascadeDelete: false)
                .Index(t => t.BPMConfig_DealerAssociation_Id)
                .Index(t => t.BPMConfig_Dealer_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BPMConfig_AssocDealerDealerAssociation", "LastModifUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPMConfig_AssocDealerDealerAssociation", "CreatUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPM_DealerContact", "LastModifUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPM_DealerContact", "CreatUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPMConfig_Dealer", "LastModifUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPM_DealerContact", "BPMConfig_DealerId", "dbo.BPMConfig_Dealer");
            DropForeignKey("dbo.BPMConfig_DealerAssociation", "LastModifUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPMConfig_DealerAssociationBPMConfig_Dealer", "BPMConfig_Dealer_Id", "dbo.BPMConfig_Dealer");
            DropForeignKey("dbo.BPMConfig_DealerAssociationBPMConfig_Dealer", "BPMConfig_DealerAssociation_Id", "dbo.BPMConfig_DealerAssociation");
            DropForeignKey("dbo.BPMConfig_DealerAssociation", "CreatUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPMConfig_Dealer", "CreatUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPM_DealerContact", "BPM_DealerContactTypeId", "dbo.BPM_DealerContactType");
            DropForeignKey("dbo.BPM_DealerContactType", "LastModifUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BPM_DealerContactType", "CreatUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BPMConfig_DealerAssociationBPMConfig_Dealer", new[] { "BPMConfig_Dealer_Id" });
            DropIndex("dbo.BPMConfig_DealerAssociationBPMConfig_Dealer", new[] { "BPMConfig_DealerAssociation_Id" });
            DropIndex("dbo.BPMConfig_AssocDealerDealerAssociation", new[] { "LastModifUserId" });
            DropIndex("dbo.BPMConfig_AssocDealerDealerAssociation", new[] { "CreatUserId" });
            DropIndex("dbo.BPMConfig_DealerAssociation", new[] { "LastModifUserId" });
            DropIndex("dbo.BPMConfig_DealerAssociation", new[] { "CreatUserId" });
            DropIndex("dbo.BPMConfig_Dealer", new[] { "LastModifUserId" });
            DropIndex("dbo.BPMConfig_Dealer", new[] { "CreatUserId" });
            DropIndex("dbo.BPM_DealerContactType", new[] { "LastModifUserId" });
            DropIndex("dbo.BPM_DealerContactType", new[] { "CreatUserId" });
            DropIndex("dbo.BPM_DealerContact", new[] { "LastModifUserId" });
            DropIndex("dbo.BPM_DealerContact", new[] { "CreatUserId" });
            DropIndex("dbo.BPM_DealerContact", new[] { "BPM_DealerContactTypeId" });
            DropIndex("dbo.BPM_DealerContact", new[] { "BPMConfig_DealerId" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.BPMConfig_DealerAssociationBPMConfig_Dealer");
            DropTable("dbo.BPMConfig_AssocDealerDealerAssociation");
            DropTable("dbo.BPMConfig_DealerAssociation");
            DropTable("dbo.BPMConfig_Dealer");
            DropTable("dbo.BPM_DealerContactType");
            DropTable("dbo.BPM_DealerContact");
        }
    }
}
