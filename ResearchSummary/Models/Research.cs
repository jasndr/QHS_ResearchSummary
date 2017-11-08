using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ListType ListType { get; set; }
        public byte ListTypeId { get; set; }

        public ICollection<ResearchStudy> ResearchStudies { get; set; }

        //public Outcome Outcome { get; set; }
        //public byte OutcomeId { get; set; }
        //public string OutcomeResult { get; set; }

        public string CancerType { get; set; }

        public string OtherCondition { get; set; }

        public Research()
        {
            ResearchMeasureConditions = new Collection<ResearchMeasureCondition>();
            ResearchStudies = new Collection<ResearchStudy>();
        }

        public void AddMeasure(MeasureCondition measureCondition)
        {
            ResearchMeasureConditions.Add(new ResearchMeasureCondition(this, measureCondition));
        }

        public void DeleteMeasure(int measureId)
        {
            ResearchMeasureConditions.Remove(ResearchMeasureConditions.Single(m => m.MeasureConditionId == measureId));
        }

        public void AddStudy(Study study)
        {
            ResearchStudies.Add(new ResearchStudy(this, study));
        }

        public void DeleteStudy(int studyId)
        {
            ResearchStudies.Remove(ResearchStudies.Single(s => s.StudyId == studyId));
        }
        
        public void Update(string userId, ViewModels.ResearchViewModel viewModel
                            ,IEnumerable<MeasureCondition> addedMeasures, IEnumerable<int> deletedMeasures
                            ,IEnumerable<Study> addedStudies, IEnumerable<int> deletedStudies)
        {
            CreatorId = userId;
            CreationDate = DateTime.Now;
            Title = viewModel.Title;
            Author = viewModel.Author;
            Journal = viewModel.Journal;
            PubDateTime = Convert.ToDateTime(viewModel.PubDateTime);
            Link = viewModel.Link;
            ListTypeId = viewModel.ListTypeId;
            ListTypeOther = viewModel.ListTypeOther;
            TreatmentId = viewModel.Treatment;
            TreatmentOther = viewModel.TreatmentOther;
            AbstractSummary = viewModel.AbstractSummary;
            CancerType = viewModel.CancerType;
            OtherCondition = viewModel.OtherCondition;

            SubjectFemale = viewModel.SubjectFemale;
            SubjectMale = viewModel.SubjectMale;
            SubjectAgeFrom = viewModel.SubjectAgeFrom;
            SubjectAgeTo = viewModel.SubjectAgeTo;
            TreatmentFemale = viewModel.TreatmentFemale;
            TreatmentMale = viewModel.TreatmentMale;
            TreatmentAgeFrom = viewModel.TreatmentAgeFrom;
            TreatmentAgeTo = viewModel.TreatmentAgeTo;
            ControlFemale = viewModel.ControlFemale;
            ControlMale = viewModel.ControlMale;
            ControlAgeFrom = viewModel.ControlAgeFrom;
            ControlAgeTo = viewModel.ControlAgeTo;
            Dosage = viewModel.Dosage;
            Duration = viewModel.Duration;
            DurationUnit = viewModel.DurationUnit;
            PositiveOutcome = viewModel.PositiveOutcome;
            NoOutcome = viewModel.NoOutcome;
            NegativeOutcome = viewModel.NegativeOutcome;
            
            foreach (var addedMeasure in addedMeasures)
            {
                AddMeasure(addedMeasure);
            }
            
            foreach (var deleted in deletedMeasures)
            {
                DeleteMeasure(deleted);
            }
          
            foreach (var addedStudy in addedStudies)
            {
                AddStudy(addedStudy);
            }

            foreach (var deleted in deletedStudies)
            {
                DeleteStudy(deleted);
            }
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