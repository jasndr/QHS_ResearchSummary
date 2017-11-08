namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Researches", "ListType_Id", "dbo.ListTypes");
            DropIndex("dbo.Researches", new[] { "ListType_Id" });
            RenameColumn(table: "dbo.Researches", name: "ListType_Id", newName: "ListTypeId");
            AlterColumn("dbo.Researches", "ListTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Researches", "ListTypeId");
            AddForeignKey("dbo.Researches", "ListTypeId", "dbo.ListTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Researches", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Researches", "SubjectId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Researches", "ListTypeId", "dbo.ListTypes");
            DropIndex("dbo.Researches", new[] { "ListTypeId" });
            AlterColumn("dbo.Researches", "ListTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Researches", name: "ListTypeId", newName: "ListType_Id");
            CreateIndex("dbo.Researches", "ListType_Id");
            AddForeignKey("dbo.Researches", "ListType_Id", "dbo.ListTypes", "Id");
        }
    }
}
