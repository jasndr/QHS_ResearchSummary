using ResearchSummary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResearchSummary.ViewModels
{
    public class ResearchSummaryViewModel
    {
        public IEnumerable<ResearchViewModel> Researches { get; set; }
        
        public bool HasRecords()
        {
            return Researches.Any();
        }
    }
}