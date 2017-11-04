namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudy2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResearchStudies", "Research_Id", "dbo.Researches");
            DropIndex("dbo.ResearchStudies", new[] { "Research_Id" });
            DropTable("dbo.ResearchStudies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResearchStudies",
                c => new
                    {
                        ResearchId = c.Int(nullable: false, identity: true),
                        Research_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ResearchId);
            
            CreateIndex("dbo.ResearchStudies", "Research_Id");
            AddForeignKey("dbo.ResearchStudies", "Research_Id", "dbo.Researches", "Id");
        }
    }
}
