namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Subjects", newName: "ListTypes");
            DropForeignKey("dbo.Researches", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Researches", new[] { "SubjectId" });
            AddColumn("dbo.Researches", "ListType_Id", c => c.Byte());
            CreateIndex("dbo.Researches", "ListType_Id");
            AddForeignKey("dbo.Researches", "ListType_Id", "dbo.ListTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Researches", "ListType_Id", "dbo.ListTypes");
            DropIndex("dbo.Researches", new[] { "ListType_Id" });
            DropColumn("dbo.Researches", "ListType_Id");
            CreateIndex("dbo.Researches", "SubjectId");
            AddForeignKey("dbo.Researches", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ListTypes", newName: "Subjects");
        }
    }
}
