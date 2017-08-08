using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResearchSummary.Models
{
    public class Subject
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}