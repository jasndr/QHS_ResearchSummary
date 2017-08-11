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

        [Authorize]
        public ActionResult Create()
        {
            var model = new ResearchViewModel
            {
                AvailableMeasures = _context.MeasureConditions.ToList(),
                SelectedMeasures = new List<MeasureCondition>(),

                Treatments = _context.Treatments.ToList(),
                Subjects = _context.Subjects.ToList(),
                Studies = _context.Studies.ToList(),
                Outcomes = _context.Outcomes.ToList()
            };

            var test = _context.Researchs
                         .Include(r => r.ResearchMeasureConditions)
                         .FirstOrDefault(r => r.Id == 2);

            return View(model);
        }

        [Authorize]
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
                StudyId = viewModel.Study,
                TreatmentId = viewModel.Treatment,
                OutcomeId = viewModel.Outcome,
                AbstractSummary = viewModel.AbstractSummary
                //MeasureConditions = viewModel.PostedMeasures != null ? _context.MeasureConditions.Where(m => viewModel.PostedMeasures.Contains(m.Id)).ToList() : null
            };

            foreach (var measureCondition in viewModel.PostedMeasures)
            {
                _context.ResearchMeasureConditions.Add(new ResearchMeasureCondition
                {
                    Research = research,
                    MeasureConditionId = measureCondition
                });
            }

            _context.Researchs.Add(research);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");

        }

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            if (id > 0)
            {
                var research = _context.Researchs
                    .Include(r => r.ResearchMeasureConditions)
                    .FirstOrDefault(r => r.Id == id);

                if (research != null)
                {
                    var selectedMeasureList = research.ResearchMeasureConditions.Select(c => c.MeasureConditionId).ToList();

                    var viewModel = new ResearchViewModel
                    {
                        Id = research.Id,
                        Title = research.Title,
                        AvailableMeasures = _context.MeasureConditions.ToList(),
                        SelectedMeasures = _context.MeasureConditions.Where(m => selectedMeasureList.Contains(m.Id)).ToList(),
                        Treatments = _context.Treatments.ToList(),
                        Subjects = _context.Subjects.ToList(),
                        Studies = _context.Studies.ToList(),
                        Outcomes = _context.Outcomes.ToList(),
                        Treatment = research.TreatmentId,
                        Subject = research.SubjectId,
                        Study = research.StudyId,
                        Outcome = research.OutcomeId,
                        PubDateTime = research.PubDateTime.ToShortDateString(),
                        AbstractSummary = research.AbstractSummary,
                        Author = research.Author,
                        Journal = research.Journal,
                        Link = research.Link
                    };

                    return View("Create", viewModel);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(ResearchViewModel viewModel)
        {
            var research = _context.Researchs
                .Include(r => r.ResearchMeasureConditions)
                .FirstOrDefault(r => r.Id == viewModel.Id);

            if (research != null)
            {
                var postedMeasures = viewModel.PostedMeasures;
                var currentMeasures = research.ResearchMeasureConditions.Select(m => m.MeasureConditionId).ToArray();

                var addedMeasures = postedMeasures.Except(currentMeasures);
                foreach (var added in addedMeasures)
                {
                    _context.ResearchMeasureConditions.Add(new ResearchMeasureCondition
                    {
                        ResearchId = research.Id,
                        MeasureConditionId = added
                    });
                }

                var deletedMeasures = currentMeasures.Except(postedMeasures);
                foreach (var deleted in deletedMeasures)
                {
                    var researchMeasure =
                        _context.ResearchMeasureConditions.FirstOrDefault(
                            m => m.ResearchId == research.Id && m.MeasureConditionId == deleted);
                    if (researchMeasure != null)
                        _context.ResearchMeasureConditions.Remove(researchMeasure);
                }

                research.CreatorId = User.Identity.GetUserId();
                research.CreationDate = DateTime.Now;
                research.Title = viewModel.Title;
                research.Author = viewModel.Author;
                research.Journal = viewModel.Journal;
                research.PubDateTime = Convert.ToDateTime(viewModel.PubDateTime);
                research.Link = viewModel.Link;
                research.SubjectId = viewModel.Subject;
                research.StudyId = viewModel.Study;
                research.TreatmentId = viewModel.Treatment;
                research.OutcomeId = viewModel.Outcome;
                research.AbstractSummary = viewModel.AbstractSummary;


                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}