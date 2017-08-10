namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable080801 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Outcomes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Researches", "OutcomeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Researches", "OutcomeId");
            AddForeignKey("dbo.Researches", "OutcomeId", "dbo.Outcomes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Researches", "OutcomeId", "dbo.Outcomes");
            DropIndex("dbo.Researches", new[] { "OutcomeId" });
            DropColumn("dbo.Researches", "OutcomeId");
            DropTable("dbo.Outcomes");
        }
    }
}
