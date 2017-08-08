﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResearchSummary.Models
{
    public class MeasureCondition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Research> Researchs { get; set; }
    }
}