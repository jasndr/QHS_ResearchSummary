namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Studies",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Researches", "PubDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Researches", "AbstractSummary", c => c.String());
            AddColumn("dbo.Researches", "TreatmentId", c => c.Byte(nullable: false));
            AddColumn("dbo.Researches", "SubjectId", c => c.Byte(nullable: false));
            AddColumn("dbo.Researches", "StudyId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Researches", "TreatmentId");
            CreateIndex("dbo.Researches", "SubjectId");
            CreateIndex("dbo.Researches", "StudyId");
            AddForeignKey("dbo.Researches", "StudyId", "dbo.Studies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Researches", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Researches", "TreatmentId", "dbo.Treatments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Researches", "TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.Researches", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Researches", "StudyId", "dbo.Studies");
            DropIndex("dbo.Researches", new[] { "StudyId" });
            DropIndex("dbo.Researches", new[] { "SubjectId" });
            DropIndex("dbo.Researches", new[] { "TreatmentId" });
            DropColumn("dbo.Researches", "StudyId");
            DropColumn("dbo.Researches", "SubjectId");
            DropColumn("dbo.Researches", "TreatmentId");
            DropColumn("dbo.Researches", "AbstractSummary");
            DropColumn("dbo.Researches", "PubDateTime");
            DropTable("dbo.Treatments");
            DropTable("dbo.Subjects");
            DropTable("dbo.Studies");
        }
    }
}
