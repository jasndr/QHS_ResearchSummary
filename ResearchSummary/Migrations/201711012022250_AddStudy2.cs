namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudy2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchStudies",
                c => new
                    {
                        ResearchId = c.Int(nullable: false),
                        StudyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResearchId, t.StudyId })
                .ForeignKey("dbo.Researches", t => t.ResearchId, cascadeDelete: true)
                .ForeignKey("dbo.Studies", t => t.StudyId, cascadeDelete: true)
                .Index(t => t.ResearchId)
                .Index(t => t.StudyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearchStudies", "StudyId", "dbo.Studies");
            DropForeignKey("dbo.ResearchStudies", "ResearchId", "dbo.Researches");
            DropIndex("dbo.ResearchStudies", new[] { "StudyId" });
            DropIndex("dbo.ResearchStudies", new[] { "ResearchId" });
            DropTable("dbo.ResearchStudies");
        }
    }
}
