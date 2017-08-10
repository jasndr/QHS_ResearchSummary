using ResearchSummary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ResearchSummary.Controllers;
using System.Web.Mvc;

namespace ResearchSummary.ViewModels
{
    public class ResearchViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Journal { get; set; }

        public IEnumerable<MeasureCondition> AvailableMeasures { get; set; }

        public IEnumerable<MeasureCondition> SelectedMeasures { get; set; }

        public int[] PostedMeasures { get; set; }

        public string ResearchMeasures { get; set; }

        public byte Treatment { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public byte Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public byte Study { get; set; }
        public IEnumerable<Study> Studies { get; set; }

        public byte Outcome { get; set; }
        public IEnumerable<Outcome> Outcomes { get; set; }

        public string PubDateTime { get; set; }

        public string AbstractSummary { get; set; }

        public string Link { get; set; }

        public Research Research { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ResearchController, ActionResult>> create = (c => c.Create(this));
                Expression<Func<ResearchController, ActionResult>> update = (c => c.Update(this));

                var action = (Id > 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
        
    }
}