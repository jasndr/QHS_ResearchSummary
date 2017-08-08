using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchSummary.ViewModels;
using ResearchSummary.Models;

namespace ResearchSummary.Controllers
{
    public class ResearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResearchController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Research
        public ActionResult Create()
        {
            var model = new ResearchViewModel();
            model.AvailableMeasures = _context.MeasureConditions.ToList();
            model.SelectedMeasures = new List<MeasureCondition>();

            model.Treatments = _context.Treatments.ToList();
            model.Subjects = _context.Subjects.ToList();
            model.Studies = _context.Studies.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ResearchViewModel viewModel)
        {
            var title = viewModel.Title;

            var measureSelected = viewModel.PostedMeasures;

            var treatmentSelected = viewModel.Treatment;

            var subjectSelected = viewModel.Subject;

            var studySelect = viewModel.Study;

            return RedirectToAction("Index", "Home");

        }
    }
}