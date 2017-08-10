namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeasureCondition080901 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeasureConditions", "Research_Id", "dbo.Researches");
            DropIndex("dbo.MeasureConditions", new[] { "Research_Id" });
            DropColumn("dbo.MeasureConditions", "Research_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeasureConditions", "Research_Id", c => c.Int());
            CreateIndex("dbo.MeasureConditions", "Research_Id");
            AddForeignKey("dbo.MeasureConditions", "Research_Id", "dbo.Researches", "Id");
        }
    }
}
