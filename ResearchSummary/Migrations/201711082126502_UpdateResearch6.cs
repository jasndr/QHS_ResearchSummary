namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Researches", "OutcomeId", "dbo.Outcomes");
            DropIndex("dbo.Researches", new[] { "OutcomeId" });
            AddColumn("dbo.Researches", "SubjectFemale", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "SubjectMale", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "SubjectAgeFrom", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "SubjectAgeTo", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "TreatmentFemale", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "TreatmentMale", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "TreatmentAgeFrom", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "TreatmentAgeTo", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "ControlFemale", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "ControlMale", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "ControlAgeFrom", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "ControlAgeTo", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "ListTypeOther", c => c.String());
            AddColumn("dbo.Researches", "TreatmentOther", c => c.String());
            AddColumn("dbo.Researches", "Dosage", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "DurationUnit", c => c.Int(nullable: false));
            AddColumn("dbo.Researches", "PositiveOutcome", c => c.String());
            AddColumn("dbo.Researches", "NoOutcome", c => c.String());
            AddColumn("dbo.Researches", "NegativeOutcome", c => c.String());
            DropColumn("dbo.Researches", "OutcomeId");
            DropColumn("dbo.Researches", "OutcomeResult");
            DropTable("dbo.Outcomes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Outcomes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Researches", "OutcomeResult", c => c.String());
            AddColumn("dbo.Researches", "OutcomeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Researches", "NegativeOutcome");
            DropColumn("dbo.Researches", "NoOutcome");
            DropColumn("dbo.Researches", "PositiveOutcome");
            DropColumn("dbo.Researches", "DurationUnit");
            DropColumn("dbo.Researches", "Duration");
            DropColumn("dbo.Researches", "Dosage");
            DropColumn("dbo.Researches", "TreatmentOther");
            DropColumn("dbo.Researches", "ListTypeOther");
            DropColumn("dbo.Researches", "ControlAgeTo");
            DropColumn("dbo.Researches", "ControlAgeFrom");
            DropColumn("dbo.Researches", "ControlMale");
            DropColumn("dbo.Researches", "ControlFemale");
            DropColumn("dbo.Researches", "TreatmentAgeTo");
            DropColumn("dbo.Researches", "TreatmentAgeFrom");
            DropColumn("dbo.Researches", "TreatmentMale");
            DropColumn("dbo.Researches", "TreatmentFemale");
            DropColumn("dbo.Researches", "SubjectAgeTo");
            DropColumn("dbo.Researches", "SubjectAgeFrom");
            DropColumn("dbo.Researches", "SubjectMale");
            DropColumn("dbo.Researches", "SubjectFemale");
            CreateIndex("dbo.Researches", "OutcomeId");
            AddForeignKey("dbo.Researches", "OutcomeId", "dbo.Outcomes", "Id", cascadeDelete: true);
        }
    }
}
