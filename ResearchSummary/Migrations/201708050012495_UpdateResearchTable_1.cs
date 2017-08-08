namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearchTable_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Researches", "Title", c => c.String());
            AddColumn("dbo.Researches", "Author", c => c.String());
            AddColumn("dbo.Researches", "Journal", c => c.String());
            AddColumn("dbo.Researches", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Researches", "Link");
            DropColumn("dbo.Researches", "Journal");
            DropColumn("dbo.Researches", "Author");
            DropColumn("dbo.Researches", "Title");
        }
    }
}
