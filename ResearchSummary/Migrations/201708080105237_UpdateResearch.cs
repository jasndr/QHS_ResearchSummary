namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Researches", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Researches", "Title", c => c.String());
        }
    }
}
