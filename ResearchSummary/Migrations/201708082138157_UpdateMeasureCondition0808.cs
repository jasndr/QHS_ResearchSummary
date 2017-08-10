namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeasureCondition0808 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResearchMeasureCondition1", "Research_Id", "dbo.Researches");
            DropForeignKey("dbo.ResearchMeasureCondition1", "MeasureCondition_Id", "dbo.MeasureConditions");
            DropIndex("dbo.ResearchMeasureCondition1", new[] { "Research_Id" });
            DropIndex("dbo.ResearchMeasureCondition1", new[] { "MeasureCondition_Id" });
            AddColumn("dbo.MeasureConditions", "Research_Id", c => c.Int());
            CreateIndex("dbo.MeasureConditions", "Research_Id");
            AddForeignKey("dbo.MeasureConditions", "Research_Id", "dbo.Researches", "Id");
            DropTable("dbo.ResearchMeasureCondition1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResearchMeasureCondition1",
                c => new
                    {
                        Research_Id = c.Int(nullable: false),
                        MeasureCondition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Research_Id, t.MeasureCondition_Id });
            
            DropForeignKey("dbo.MeasureConditions", "Research_Id", "dbo.Researches");
            DropIndex("dbo.MeasureConditions", new[] { "Research_Id" });
            DropColumn("dbo.MeasureConditions", "Research_Id");
            CreateIndex("dbo.ResearchMeasureCondition1", "MeasureCondition_Id");
            CreateIndex("dbo.ResearchMeasureCondition1", "Research_Id");
            AddForeignKey("dbo.ResearchMeasureCondition1", "MeasureCondition_Id", "dbo.MeasureConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResearchMeasureCondition1", "Research_Id", "dbo.Researches", "Id", cascadeDelete: true);
        }
    }
}
