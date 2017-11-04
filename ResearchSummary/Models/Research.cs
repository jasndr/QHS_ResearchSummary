using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResearchSummary.Models
{
    public class Research
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public string Journal { get; set; }

        public string Link { get; set; }

        public DateTime PubDateTime { get; set; }

        public string AbstractSummary { get; set; }

        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<ResearchMeasureCondition> ResearchMeasureConditions { get; set; }

        public Treatment Treatment { get; set; }
        public byte TreatmentId { get; set; }

        public Subject Subject { get; set; }
        public byte SubjectId { get; set; }

        public ICollection<ResearchStudy> ResearchStudies { get; set; }

        public Outcome Outcome { get; set; }
        public byte OutcomeId { get; set; }
        public string OutcomeResult { get; set; }

        public string CancerType { get; set; }

        public string OtherCondition { get; set; }

    }
    
}