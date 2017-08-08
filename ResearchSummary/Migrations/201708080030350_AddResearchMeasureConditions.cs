namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearchMeasureConditions : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ResearchMeasureConditions", newName: "ResearchMeasureCondition1");
            CreateTable(
                "dbo.ResearchMeasureConditions",
                c => new
                    {
                        ResearchId = c.Int(nullable: false),
                        MeasureConditionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResearchId, t.MeasureConditionId })
                .ForeignKey("dbo.MeasureConditions", t => t.MeasureConditionId, cascadeDelete: true)
                .ForeignKey("dbo.Researches", t => t.ResearchId, cascadeDelete: true)
                .Index(t => t.ResearchId)
                .Index(t => t.MeasureConditionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearchMeasureConditions", "ResearchId", "dbo.Researches");
            DropForeignKey("dbo.ResearchMeasureConditions", "MeasureConditionId", "dbo.MeasureConditions");
            DropIndex("dbo.ResearchMeasureConditions", new[] { "MeasureConditionId" });
            DropIndex("dbo.ResearchMeasureConditions", new[] { "ResearchId" });
            DropTable("dbo.ResearchMeasureConditions");
            RenameTable(name: "dbo.ResearchMeasureCondition1", newName: "ResearchMeasureConditions");
        }
    }
}
