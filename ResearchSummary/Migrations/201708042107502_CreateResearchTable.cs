namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateResearchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeasureConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.ResearchMeasureConditions",
                c => new
                    {
                        Research_Id = c.Int(nullable: false),
                        MeasureCondition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Research_Id, t.MeasureCondition_Id })
                .ForeignKey("dbo.Researches", t => t.Research_Id, cascadeDelete: true)
                .ForeignKey("dbo.MeasureConditions", t => t.MeasureCondition_Id, cascadeDelete: true)
                .Index(t => t.Research_Id)
                .Index(t => t.MeasureCondition_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearchMeasureConditions", "MeasureCondition_Id", "dbo.MeasureConditions");
            DropForeignKey("dbo.ResearchMeasureConditions", "Research_Id", "dbo.Researches");
            DropForeignKey("dbo.Researches", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ResearchMeasureConditions", new[] { "MeasureCondition_Id" });
            DropIndex("dbo.ResearchMeasureConditions", new[] { "Research_Id" });
            DropIndex("dbo.Researches", new[] { "Creator_Id" });
            DropTable("dbo.ResearchMeasureConditions");
            DropTable("dbo.Researches");
            DropTable("dbo.MeasureConditions");
        }
    }
}
