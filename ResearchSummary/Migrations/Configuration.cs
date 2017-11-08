namespace ResearchSummary.Migrations
{
    using ResearchSummary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResearchSummary.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResearchSummary.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.MeasureConditions.AddOrUpdate(x => x.Id,
                //new MeasureCondition() { Id = 1, Name = "ADHD" },
                //new MeasureCondition() { Id = 2, Name = "Anxiety" },
                //new MeasureCondition() { Id = 3, Name = "Asthma" },
                //new MeasureCondition() { Id = 4, Name = "Burnout" },
                //new MeasureCondition() { Id = 5, Name = "Cancer" },
                //new MeasureCondition() { Id = 6, Name = "Diabetes" },
                //new MeasureCondition() { Id = 7, Name = "Depression" },
                //new MeasureCondition() { Id = 8, Name = "Eating disorders" },
                //new MeasureCondition() { Id = 9, Name = "Fatigue" },
                //new MeasureCondition() { Id = 10, Name = "Fibromyalgia" },
                //new MeasureCondition() { Id = 11, Name = "Grief" },
                //new MeasureCondition() { Id = 12, Name = "Headaches" },
                //new MeasureCondition() { Id = 13, Name = "Hypertension" },
                //new MeasureCondition() { Id = 14, Name = "Gastrointestinal distress" },
                //new MeasureCondition() { Id = 15, Name = "Mental health" },
                //new MeasureCondition() { Id = 16, Name = "Multiple sclerosis" },
                //new MeasureCondition() { Id = 17, Name = "Pain" },
                //new MeasureCondition() { Id = 18, Name = "Panic attacks" },
                //new MeasureCondition() { Id = 19, Name = "Psychosis" },
                //new MeasureCondition() { Id = 20, Name = "Post-traumatic stress disorder (PTSD)" },
                //new MeasureCondition() { Id = 21, Name = "Smoking" },
                //new MeasureCondition() { Id = 22, Name = "Stress" },
                //new MeasureCondition() { Id = 23, Name = "Well-being" },
                //new MeasureCondition() { Id = 24, Name = "Other" }
                new MeasureCondition(1, "ADHD"),
                new MeasureCondition(2, "Anxiety"),
                new MeasureCondition(3, "Asthma"),
                new MeasureCondition(4, "Burnout"),
                new MeasureCondition(5, "Cancer"),
                new MeasureCondition(6, "Diabetes"),
                new MeasureCondition(7, "Depression"),
                new MeasureCondition(8, "Eating disorders"),
                new MeasureCondition(9, "Fatigue"),
                new MeasureCondition(10, "Fibromyalgia"),
                new MeasureCondition(11, "Grief"),
                new MeasureCondition(12, "Headaches"),
                new MeasureCondition(13, "Hypertension"),
                new MeasureCondition(14, "Gastrointestinal distress"),
                new MeasureCondition(15, "Mental health"),
                new MeasureCondition(16, "Multiple sclerosis"),
                new MeasureCondition(17, "Pain"),
                new MeasureCondition(18, "Panic attacks"),
                new MeasureCondition(19, "Psychosis"),
                new MeasureCondition(20, "Post-traumatic stress disorder (PTSD)"),
                new MeasureCondition(21, "Smoking"),
                new MeasureCondition(22, "Stress"),
                new MeasureCondition(23, "Well-being"),
                new MeasureCondition(24, "Other")
                );

            context.Treatments.AddOrUpdate(x => x.Id,
                new Treatment() { Id = 1, Name = "Herbal supplements" },
                new Treatment() { Id = 2, Name = "Mindfulness" },
                new Treatment() { Id = 3, Name = "Diet" }
                );

            context.ListTypes.AddOrUpdate(x => x.Id,
                new ListType() { Id = 1, Name = "Students" },
                new ListType() { Id = 2, Name = "Health professionals" },
                new ListType() { Id = 3, Name = "Children" },
                new ListType() { Id = 4, Name = "Seniors" },
                new ListType() { Id = 5, Name = "Youth" },
                new ListType() { Id = 6, Name = "Women" },
                new ListType() { Id = 99, Name = "Other" }
                );

            context.Studies.AddOrUpdate(x => x.Id,
                new Study() { Id = 1, Name = "Test-tube research (lab study)" },
                new Study() { Id = 2, Name = "Animal research" },
                new Study() { Id = 3, Name = "Human research" },
                new Study() { Id = 4, Name = "Survey" },
                new Study() { Id = 5, Name = "Case Report" },
                new Study() { Id = 6, Name = "Case series" },
                new Study() { Id = 7, Name = "Case-control study" },
                new Study() { Id = 8, Name = "Cross-sectional study" },
                new Study() { Id = 9, Name = "Cross-over" },
                new Study() { Id = 10, Name = "Record examination" },
                new Study() { Id = 11, Name = "Cohort (prospective observational study)" },
                new Study() { Id = 12, Name = "Longitudinal" },
                new Study() { Id = 13, Name = "Not controlled" },
                new Study() { Id = 14, Name = "Controlled" },
                new Study() { Id = 15, Name = "Not blinded" },
                new Study() { Id = 16, Name = "Single blind" },
                new Study() { Id = 17, Name = "Double-blind" },
                new Study() { Id = 18, Name = "Randomized" },
                new Study() { Id = 19, Name = "Clinical trial" },
                new Study() { Id = 20, Name = "Randomized Controlled Trial" },
                new Study() { Id = 21, Name = "Review" },
                new Study() { Id = 22, Name = "Systematic Review" },
                new Study() { Id = 23, Name = "Meta-analysis" }
                );

            //context.Outcomes.AddOrUpdate(x => x.Id,
            //    new Outcome() { Id = 1, Name = "Significant effect" },
            //    new Outcome() { Id = 2, Name = "Moderate effect" },
            //    new Outcome() { Id = 3, Name = "No effect" }
            //    );
        }
    }
}
