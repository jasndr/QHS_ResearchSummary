namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Researches", name: "Creator_Id", newName: "CreatorId");
            RenameIndex(table: "dbo.Researches", name: "IX_Creator_Id", newName: "IX_CreatorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Researches", name: "IX_CreatorId", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Researches", name: "CreatorId", newName: "Creator_Id");
        }
    }
}
