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

        public Subject Subject { get; set; }
        public byte SubjectId { get; set; }

        public ICollection<ResearchStudy> ResearchStudies { get; set; }

        public Outcome Outcome { get; set; }
        public byte OutcomeId { get; set; }
        public string OutcomeResult { get; set; }

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
            SubjectId = viewModel.Subject;
            TreatmentId = viewModel.Treatment;
            OutcomeId = viewModel.Outcome;
            OutcomeResult = viewModel.OutcomeResult;
            AbstractSummary = viewModel.AbstractSummary;
            CancerType = viewModel.CancerType;
            OtherCondition = viewModel.OtherCondition;
            
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

    }
    
}