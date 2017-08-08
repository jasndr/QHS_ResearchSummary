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
                new MeasureCondition() { Id = 1, Name = "Pain" },
                new MeasureCondition() { Id = 2, Name = "Fibromyalgia" },
                new MeasureCondition() { Id = 3, Name = "Depression" },
                new MeasureCondition() { Id = 4, Name = "Fatigue" },
                new MeasureCondition() { Id = 5, Name = "Headaches" },
                new MeasureCondition() { Id = 6, Name = "Gastrointestinal Distress" },
                new MeasureCondition() { Id = 7, Name = "Post traumatic stress disorder" },
                new MeasureCondition() { Id = 8, Name = "Anxiety, stress" },
                new MeasureCondition() { Id = 9, Name = "Asthma" },
                new MeasureCondition() { Id = 10, Name = "Chronic illness (cancer, diabetes, hSleep disordereart disease, etc.)" },
                new MeasureCondition() { Id = 11, Name = "Eating disorder, obesity" },
                new MeasureCondition() { Id = 12, Name = "High blood pressure" },
                new MeasureCondition() { Id = 13, Name = "Panic attacks" }
                );

            context.Treatments.AddOrUpdate(x => x.Id,
                new Treatment() { Id = 1, Name = "Herbal supplements" },
                new Treatment() { Id = 2, Name = "Mindfulness" },
                new Treatment() { Id = 3, Name = "Diet" }
                );

            context.Subjects.AddOrUpdate(x => x.Id,
                new Subject() { Id = 1, Name = "Prisoners" },
                new Subject() { Id = 2, Name = "Health professionals" },
                new Subject() { Id = 3, Name = "Children" },
                new Subject() { Id = 4, Name = "Seniors" },
                new Subject() { Id = 5, Name = "Youth" },
                new Subject() { Id = 6, Name = "Women" }
                );

            context.Studies.AddOrUpdate(x => x.Id,
                new Study() { Id = 1, Name = "Randomized Control Study" },
                new Study() { Id = 2, Name = "Cohort or longitudinal" },
                new Study() { Id = 3, Name = "Meta-analysis" },
                new Study() { Id = 4, Name = "Systematic Review" }
                );
        }
    }
}
