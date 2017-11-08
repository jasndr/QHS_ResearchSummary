namespace ResearchSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResearch7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Researches", "SubjectFemale", c => c.Int());
            AlterColumn("dbo.Researches", "SubjectMale", c => c.Int());
            AlterColumn("dbo.Researches", "SubjectAgeFrom", c => c.Int());
            AlterColumn("dbo.Researches", "SubjectAgeTo", c => c.Int());
            AlterColumn("dbo.Researches", "TreatmentFemale", c => c.Int());
            AlterColumn("dbo.Researches", "TreatmentMale", c => c.Int());
            AlterColumn("dbo.Researches", "TreatmentAgeFrom", c => c.Int());
            AlterColumn("dbo.Researches", "TreatmentAgeTo", c => c.Int());
            AlterColumn("dbo.Researches", "ControlFemale", c => c.Int());
            AlterColumn("dbo.Researches", "ControlMale", c => c.Int());
            AlterColumn("dbo.Researches", "ControlAgeFrom", c => c.Int());
            AlterColumn("dbo.Researches", "ControlAgeTo", c => c.Int());
            AlterColumn("dbo.Researches", "Dosage", c => c.Int());
            AlterColumn("dbo.Researches", "Duration", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Researches", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "Dosage", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "ControlAgeTo", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "ControlAgeFrom", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "ControlMale", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "ControlFemale", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "TreatmentAgeTo", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "TreatmentAgeFrom", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "TreatmentMale", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "TreatmentFemale", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "SubjectAgeTo", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "SubjectAgeFrom", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "SubjectMale", c => c.Int(nullable: false));
            AlterColumn("dbo.Researches", "SubjectFemale", c => c.Int(nullable: false));
        }
    }
}
