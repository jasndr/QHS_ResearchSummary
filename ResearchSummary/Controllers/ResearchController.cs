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
                _context.Treatments.ToList(), _context.ListTypes.ToList(), 
                 _context.Studies.ToList(), new List<Study>()
            );
            model.PubDateTime = DateTime.Today.ToShortDateString();

            return View("ResearchForm", model);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Create(ResearchViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var addedMeasures = _context.MeasureConditions.Where(m => viewModel.PostedMeasures.Contains(m.Id));
            var addedStudies = _context.Studies.Where(s => viewModel.PostedStudies.Contains(s.Id));

            var research = new Research();
            research.Update(userId, viewModel, addedMeasures, new List<int>(), addedStudies, new List<int>() );
            _context.Researchs.Add(research);
            _context.SaveChanges();

            TempData["message"] = "A New Research is created!";
           
            InitViewModel(viewModel);

            ModelState.Clear();
            return View("ResearchForm", viewModel);
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
                    var subjects = _context.ListTypes.ToList();
                    //var outcomes = _context.Outcomes.ToList();
                    var availableStudies = _context.Studies.ToList();

                    var viewModel = new ResearchViewModel(research, availableMeasures, selectedMeasures,
                        treatments, subjects, availableStudies, selectedStudies);

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
                var deletedMeasures = currentMeasures.Except(postedMeasures);

                var postedStudies = viewModel.PostedStudies;
                var currentStudies = research.ResearchStudies.Select(m => m.StudyId).ToArray();
                var addedStudiesIds = postedStudies.Except(currentStudies);
                var addedStudies = _context.Studies.Where(s => addedStudiesIds.Contains(s.Id));
                var deletedStudies = currentStudies.Except(postedStudies);

                var userId = User.Identity.GetUserId();
                research.Update(userId, viewModel, addedMeasures, deletedMeasures, addedStudies, deletedStudies);
                
                _context.SaveChanges();
            }

            TempData["message"] = "Research is saved!";
            //works, but feel wired
            //return RedirectToAction("Create");
            //return RedirectToAction("Create", "Research", "Add");

            InitViewModel(viewModel);

            ModelState.Clear();
            return View("ResearchForm", viewModel);

            //return RedirectToAction("Researches", "ResearchSummary");
            //return PartialView("Alert");
        }

        private void InitViewModel(ResearchViewModel viewModel)
        {
            viewModel.AvailableMeasures = _context.MeasureConditions.ToList();
            viewModel.AvailableStudies = _context.Studies.ToList();
            //viewModel.Outcomes = _context.Outcomes.ToList();
            viewModel.Treatments = _context.Treatments.ToList();
            viewModel.ListTypes = _context.ListTypes.ToList();
        }
    }
}