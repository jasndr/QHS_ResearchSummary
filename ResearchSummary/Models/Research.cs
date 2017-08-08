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

        public DateTime CreationDate { get; set; }

        public ICollection<MeasureCondition> MeasureConditions { get; set; }

        public Treatment Treatment { get; set; }
        public byte TreatmentId { get; set; }

        public Subject Subject { get; set; }
        public byte SubjectId { get; set; }

        public Study Study { get; set; }
        public byte StudyId { get; set; }

    }
    
}