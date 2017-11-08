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

        public byte ListTypeId { get; set; }
        public IEnumerable<ListType> ListTypes { get; set; }

        //public byte Study { get; set; }
        //public IEnumerable<Study> Studies { get; set; }

        public IEnumerable<Study> AvailableStudies { get; set; }

        public IEnumerable<Study> SelectedStudies { get; set; }
        public int[] PostedStudies { get; set; }

        //public byte Outcome { get; set; }
        //public IEnumerable<Outcome> Outcomes { get; set; }

        public string OutcomeResult { get; set; }

        public string PubDateTime { get; set; }

        public string AbstractSummary { get; set; }

        public string Link { get; set; }

        public string CancerType { get; set; }

        public string OtherCondition { get; set; }


        //public Research Research { get; set; }

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

        public ResearchViewModel()
        {
        }

        public ResearchViewModel(Research research, 
            IEnumerable<MeasureCondition> availableMeasures, 
            IEnumerable<MeasureCondition> selectedMeasures, 
            IEnumerable<Treatment> treatments,
            IEnumerable<ListType> listTypes,
            //IEnumerable<Outcome> outcomes,
            IEnumerable<Study> availableStudie,
            IEnumerable<Study> selectedStudies
            )
        {
            Id = research.Id;
            Title = research.Title;
            AvailableMeasures = availableMeasures;
            SelectedMeasures = selectedMeasures;
            Treatments = treatments;
            ListTypes = listTypes;
            AvailableStudies = availableStudie;
            SelectedStudies = selectedStudies;
            Treatment = research.TreatmentId;
            TreatmentOther = research.TreatmentOther;
            ListTypeId = research.ListTypeId;
            ListTypeOther = research.ListTypeOther;
            PubDateTime = research.PubDateTime.ToShortDateString();
            AbstractSummary = research.AbstractSummary;
            Author = research.Author;
            Journal = research.Journal;
            Link = research.Link;
            CancerType = research.CancerType;
            OtherCondition = research.OtherCondition;

            SubjectFemale = research.SubjectFemale;
            SubjectMale = research.SubjectMale;
            SubjectAgeFrom = research.SubjectAgeFrom;
            SubjectAgeTo = research.SubjectAgeTo;
            TreatmentFemale = research.TreatmentFemale;
            TreatmentMale = research.TreatmentMale;
            TreatmentAgeFrom = research.TreatmentAgeFrom;
            TreatmentAgeTo = research.TreatmentAgeTo;
            ControlFemale = research.ControlFemale;
            ControlMale = research.ControlMale;
            ControlAgeFrom = research.ControlAgeFrom;
            ControlAgeTo = research.ControlAgeTo;
            Dosage = research.Dosage;
            Duration = research.Duration;
            DurationUnit = research.DurationUnit;
            PositiveOutcome = research.PositiveOutcome;
            NoOutcome = research.NoOutcome;
            NegativeOutcome = research.NegativeOutcome;
        }

        public int? SubjectFemale { get; set; }
        public int? SubjectMale { get; set; }
        public int? SubjectAgeFrom { get; set; }
        public int? SubjectAgeTo { get; set; }
        public int? TreatmentFemale { get; set; }
        public int? TreatmentMale { get; set; }
        public int? TreatmentAgeFrom { get; set; }
        public int? TreatmentAgeTo { get; set; }
        public int? ControlFemale { get; set; }
        public int? ControlMale { get; set; }
        public int? ControlAgeFrom { get; set; }
        public int? ControlAgeTo { get; set; }
        public string ListTypeOther { get; set; }
        public string TreatmentOther { get; set; }
        public int? Dosage { get; set; }
        public int? Duration { get; set; }
        public DurationUnit DurationUnit { get; set; }
        public string PositiveOutcome { get; set; }
        public string NoOutcome { get; set; }
        public string NegativeOutcome { get; set; }
        
    }
}