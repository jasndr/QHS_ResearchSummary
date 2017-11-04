namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResearchStudy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchStudies",
                c => new
                    {
                        ResearchId = c.Int(nullable: false),
                        StudyId = c.Int(nullable: false),
                        Study_Id = c.Byte(),
                    })
                .PrimaryKey(t => new { t.ResearchId, t.StudyId })
                .ForeignKey("dbo.Researches", t => t.ResearchId, cascadeDelete: true)
                .ForeignKey("dbo.Studies", t => t.Study_Id)
                .Index(t => t.ResearchId)
                .Index(t => t.Study_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearchStudies", "Study_Id", "dbo.Studies");
            DropForeignKey("dbo.ResearchStudies", "ResearchId", "dbo.Researches");
            DropIndex("dbo.ResearchStudies", new[] { "Study_Id" });
            DropIndex("dbo.ResearchStudies", new[] { "ResearchId" });
            DropTable("dbo.ResearchStudies");
        }
    }
}
