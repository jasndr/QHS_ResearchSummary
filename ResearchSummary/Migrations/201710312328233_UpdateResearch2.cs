namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Researches", "OutcomeResult", c => c.String());
            AddColumn("dbo.Researches", "CancerType", c => c.String());
            AddColumn("dbo.Researches", "OtherCondition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Researches", "OtherCondition");
            DropColumn("dbo.Researches", "CancerType");
            DropColumn("dbo.Researches", "OutcomeResult");
        }
    }
}
