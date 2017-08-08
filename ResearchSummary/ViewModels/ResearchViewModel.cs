using ResearchSummary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResearchSummary.ViewModels
{
    public class ResearchViewModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Journal { get; set; }

        public IEnumerable<MeasureCondition> AvailableMeasures { get; set; }

        public IEnumerable<MeasureCondition> SelectedMeasures { get; set; }

        public string[] PostedMeasures { get; set; }

        public byte Treatment { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public byte Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public byte Study { get; set; }
        public IEnumerable<Study> Studies { get; set; }

        public string PubDateTime { get; set; }

        public string AbstractSummary { get; set; }

        public string Link { get; set; }

    }
}