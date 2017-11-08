using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ResearchSummary.Models
{ 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Research> Researchs { get; set; }
        public DbSet<MeasureCondition> MeasureConditions { get; set; }
        public DbSet<ResearchMeasureCondition> ResearchMeasureConditions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<ListType> ListTypes { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<ResearchStudy> ResearchStudies { get; set; }
        //public DbSet<Outcome> Outcomes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<Research>()
        //    //            .HasMany<Symptom>(s => s.Symptoms)
        //    //            .WithMany(c => c.Researches)
        //    //            .Map(cs =>
        //    //            {
        //    //                cs.MapLeftKey("ResearchId");
        //    //                cs.MapRightKey("SymptomId");
        //    //                cs.ToTable("ResearchSymptoms");
        //    //            });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}