using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ResearchSummary.ViewModels;
using ResearchSummary.Models;
using System.Data.Entity;

namespace ResearchSummary.Controllers
{
    public class ResearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResearchController()
        {
            _context = new ApplicationDbContext();
        }

        //[Authorize]
        public ActionResult Create()
        {
            var model = new ResearchViewModel(
                new Research(), 
                _context.MeasureConditions.ToList(), new List<MeasureCondition>(),
                _context.Treatments.ToList(), _context.Subjects.ToList(), _context.Outcomes.ToList(),
                 _context.Studies.ToList(), new List<Study>()
            );
            //{
            //    AvailableMeasures = _context.MeasureConditions.ToList(),
            //    SelectedMeasures = new List<MeasureCondition>(),
            //    Treatments = _context.Treatments.ToList(),
            //    Subjects = _context.Subjects.ToList(),
            //    AvailableStudies = _context.Studies.ToList(),
            //    SelectedStudies = new List<Study>(),
            //    Outcomes = _context.Outcomes.ToList()
            //};

            var test = _context.Researchs
                         .Include(r => r.ResearchMeasureConditions)
                         .FirstOrDefault(r => r.Id == 2);

            return View("ResearchForm", model);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Create(ResearchViewModel viewModel)
        {
            var research = new Research
            {
                CreatorId = User.Identity.GetUserId(),
                CreationDate = DateTime.Now,
                Title = viewModel.Title,
                Author = viewModel.Author,
                Journal = viewModel.Journal,
                PubDateTime = Convert.ToDateTime(viewModel.PubDateTime),
                Link = viewModel.Link,
                SubjectId = viewModel.Subject,
                //StudyId = viewModel.Study,
                TreatmentId = viewModel.Treatment,
                OutcomeId = viewModel.Outcome,
                OutcomeResult = viewModel.OutcomeResult,
                AbstractSummary = viewModel.AbstractSummary,
                CancerType = viewModel.CancerType,
                OtherCondition = viewModel.OtherCondition
                //MeasureConditions = viewModel.PostedMeasures != null ? _context.MeasureConditions.Where(m => viewModel.PostedMeasures.Contains(m.Id)).ToList() : null
            };

            var addedMeasures = _context.MeasureConditions.Where(m => viewModel.PostedMeasures.Contains(m.Id));
            foreach (var measureCondition in addedMeasures)
            {
                research.AddMeasure(measureCondition);
                //_context.ResearchMeasureConditions.Add(new ResearchMeasureCondition
                //{
                //    Research = research,
                //    MeasureConditionId = measureCondition
                //});
            }

            foreach (var study in viewModel.PostedStudies)
            {
                _context.ResearchStudies.Add(new ResearchStudy
                {
                    Research = research,
                    StudyId = study
                });
            }

            _context.Researchs.Add(research);
            _context.SaveChanges();
            
            //return RedirectToAction("Researches", "ResearchSummary");
            return View("Alert");
        }

        //[Authorize]
        public ActionResult Edit(int id = 0)
        {
            if (id > 0)
            {
                var research = _context.Researchs
                    .Include(r => r.ResearchMeasureConditions.Select(m => m.MeasureCondition))
                    .Include(r => r.ResearchStudies.Select(s => s.Study))
                    .FirstOrDefault(r => r.Id == id);

                if (research != null)
                {
                    var availableMeasures = _context.MeasureConditions.ToList();
                    //var selectedMeasureList = research.ResearchMeasureConditions.Select(c => c.MeasureConditionId).ToList();
                    //var selectedMeasures = _context.MeasureConditions.Where(m => selectedMeasureList.Contains(m.Id)).ToList();
                    var selectedMeasures = research.ResearchMeasureConditions.Select(m => m.MeasureCondition);
                    
                    //var selectedStudyList = research.ResearchStudies.Select(s => s.StudyId).ToList();
                    //var selectedStudies = _context.Studies.Where(s => selectedStudyList.Contains(s.Id)).ToList();
                    var selectedStudies = research.ResearchStudies.Select(s => s.Study);

                    var treatments = _context.Treatments.ToList();
                    var subjects = _context.Subjects.ToList();
                    var outcomes = _context.Outcomes.ToList();
                    var availableStudies = _context.Studies.ToList();

                    var viewModel = new ResearchViewModel(research, availableMeasures, selectedMeasures,
                        treatments, subjects, outcomes, availableStudies, selectedStudies);
                        
                    //{
                    //    Id = research.Id,
                    //    Title = research.Title,
                    //    AvailableMeasures = _context.MeasureConditions.ToList(),
                    //    SelectedMeasures = _context.MeasureConditions.Where(m => selectedMeasureList.Contains(m.Id)).ToList(),
                    //    Treatments = _context.Treatments.ToList(),
                    //    Subjects = _context.Subjects.ToList(),
                    //    AvailableStudies = _context.Studies.ToList(),
                    //    SelectedStudies = _context.Studies.Where(s => selectedStudyList.Contains(s.Id)).ToList(),
                    //    Outcomes = _context.Outcomes.ToList(),
                    //    Treatment = research.TreatmentId,
                    //    Subject = research.SubjectId,
                    //    //Study = research.StudyId,
                    //    Outcome = research.OutcomeId,
                    //    OutcomeResult = research.OutcomeResult,
                    //    PubDateTime = research.PubDateTime.ToShortDateString(),
                    //    AbstractSummary = research.AbstractSummary,
                    //    Author = research.Author,
                    //    Journal = research.Journal,
                    //    Link = research.Link,
                    //    CancerType = research.CancerType,
                    //    OtherCondition = research.OtherCondition
                    //};

                    return View("ResearchForm", viewModel);
                }
            }

            return RedirectToAction("Researches", "ResearchSummary");
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Update(ResearchViewModel viewModel)
        {
            var research = _context.Researchs
                .Include(r => r.ResearchMeasureConditions)
                .Include(r => r.ResearchStudies)
                .FirstOrDefault(r => r.Id == viewModel.Id);

            if (research != null)
            {
                var postedMeasures = viewModel.PostedMeasures;
                var currentMeasures = research.ResearchMeasureConditions.Select(m => m.MeasureConditionId).ToArray();

                var addedMeasuresIds = postedMeasures.Except(currentMeasures);
                var addedMeasures = _context.MeasureConditions.Where(m => addedMeasuresIds.Contains(m.Id));
                foreach (var addedMeasure in addedMeasures)
                {
                    research.AddMeasure(addedMeasure);
                    //_context.ResearchMeasureConditions.Add(new ResearchMeasureCondition
                    //{
                    //    ResearchId = research.Id,
                    //    MeasureConditionId = added
                    //});
                }

                var deletedMeasures = currentMeasures.Except(postedMeasures);
                foreach (var deleted in deletedMeasures)
                {
                    research.DeleteMeasure(deleted);
                    //var researchMeasure =
                    //    _context.ResearchMeasureConditions.FirstOrDefault(
                    //        m => m.ResearchId == research.Id && m.MeasureConditionId == deleted);
                    //if (researchMeasure != null)
                    //    _context.ResearchMeasureConditions.Remove(researchMeasure);
                }

                var postedStudies = viewModel.PostedStudies;
                var currentStudies = research.ResearchStudies.Select(m => m.StudyId).ToArray();

                var addedStudies = postedStudies.Except(currentStudies);
                foreach (var added in addedStudies)
                {
                    _context.ResearchStudies.Add(new ResearchStudy
                    {
                        ResearchId = research.Id,
                        StudyId = added
                    });
                }

                var deletedStudies= currentStudies.Except(postedStudies);
                foreach (var deleted in deletedStudies)
                {
                    var researchStudy =
                        _context.ResearchStudies.FirstOrDefault(
                            m => m.ResearchId == research.Id && m.StudyId == deleted);
                    if (researchStudy != null)
                        _context.ResearchStudies.Remove(researchStudy);
                }

                research.CreatorId = User.Identity.GetUserId();
                research.CreationDate = DateTime.Now;
                research.Title = viewModel.Title;
                research.Author = viewModel.Author;
                research.Journal = viewModel.Journal;
                research.PubDateTime = Convert.ToDateTime(viewModel.PubDateTime);
                research.Link = viewModel.Link;
                research.SubjectId = viewModel.Subject;
                //research.StudyId = viewModel.Study;
                research.TreatmentId = viewModel.Treatment;
                research.OutcomeId = viewModel.Outcome;
                research.OutcomeResult = viewModel.OutcomeResult;
                research.AbstractSummary = viewModel.AbstractSummary;
                research.CancerType = viewModel.CancerType;
                research.OtherCondition = viewModel.OtherCondition;
                
                _context.SaveChanges();
            }

            TempData["message"] = "Research is saved!";
            //return RedirectToAction("Researches", "ResearchSummary");
            
            //works, but feel wired
            //return RedirectToAction("Create");
            //return RedirectToAction("Create", "Research", "Add");

            viewModel.AvailableMeasures = _context.MeasureConditions.ToList();
            viewModel.AvailableStudies = _context.Studies.ToList();
            viewModel.Outcomes = _context.Outcomes.ToList();
            viewModel.Treatments = _context.Treatments.ToList();
            viewModel.Subjects = _context.Subjects.ToList();

            ModelState.Clear();
            //ResearchViewModel testingModel = new ResearchViewModel();
            return View("ResearchForm", viewModel);

            //return PartialView("Alert");
        }
    }
}