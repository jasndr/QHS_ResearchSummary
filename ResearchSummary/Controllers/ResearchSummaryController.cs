﻿using ResearchSummary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ResearchSummary.ViewModels;

namespace ResearchSummary.Controllers
{
    public class ResearchSummaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResearchSummaryController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ResearchSummary
        public ActionResult Researches()
        {
            var researches = _context.Researchs
                .Include(r => r.ResearchMeasureConditions)
                .Include(r => r.Treatment)
                .Include(r => r.Subject)
                .Include(r => r.Study)
                .Include(r => r.Outcome)
                .ToList();

            return View(researches);
        }
    }
}