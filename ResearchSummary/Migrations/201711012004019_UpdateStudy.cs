namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Researches", "StudyId", "dbo.Studies");
            DropForeignKey("dbo.ResearchStudies", "Study_Id", "dbo.Studies");
            DropForeignKey("dbo.ResearchStudies", "ResearchId", "dbo.Researches");
            DropIndex("dbo.Researches", new[] { "StudyId" });
            DropIndex("dbo.ResearchStudies", new[] { "ResearchId" });
            DropIndex("dbo.ResearchStudies", new[] { "Study_Id" });
            DropPrimaryKey("dbo.Studies");
            DropPrimaryKey("dbo.ResearchStudies");
            AddColumn("dbo.ResearchStudies", "Research_Id", c => c.Int());
            AlterColumn("dbo.Studies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ResearchStudies", "ResearchId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Studies", "Id");
            AddPrimaryKey("dbo.ResearchStudies", "ResearchId");
            CreateIndex("dbo.ResearchStudies", "Research_Id");
            AddForeignKey("dbo.ResearchStudies", "Research_Id", "dbo.Researches", "Id");
            DropColumn("dbo.Researches", "StudyId");
            DropColumn("dbo.ResearchStudies", "StudyId");
            DropColumn("dbo.ResearchStudies", "Study_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResearchStudies", "Study_Id", c => c.Byte());
            AddColumn("dbo.ResearchStudies", "StudyId", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "StudyId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.ResearchStudies", "Research_Id", "dbo.Researches");
            DropIndex("dbo.ResearchStudies", new[] { "Research_Id" });
            DropPrimaryKey("dbo.ResearchStudies");
            DropPrimaryKey("dbo.Studies");
            AlterColumn("dbo.ResearchStudies", "ResearchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Studies", "Id", c => c.Byte(nullable: false));
            DropColumn("dbo.ResearchStudies", "Research_Id");
            AddPrimaryKey("dbo.ResearchStudies", new[] { "ResearchId", "StudyId" });
            AddPrimaryKey("dbo.Studies", "Id");
            CreateIndex("dbo.ResearchStudies", "Study_Id");
            CreateIndex("dbo.ResearchStudies", "ResearchId");
            CreateIndex("dbo.Researches", "StudyId");
            AddForeignKey("dbo.ResearchStudies", "ResearchId", "dbo.Researches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResearchStudies", "Study_Id", "dbo.Studies", "Id");
            AddForeignKey("dbo.Researches", "StudyId", "dbo.Studies", "Id", cascadeDelete: true);
        }
    }
}
