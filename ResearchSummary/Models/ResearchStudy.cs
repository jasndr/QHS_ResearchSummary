﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchSummary.Models
{
    public class ResearchStudy
    {
        [Key, Column(Order = 1)]
        public int ResearchId { get; set; }

        [Key, Column(Order = 2)]
        public int StudyId { get; set; }

        public Research Research { get; set; }

        public Study Study { get; set; }
    }
}