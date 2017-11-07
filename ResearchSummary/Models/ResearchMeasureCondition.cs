using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResearchSummary.Models
{
    public class ResearchMeasureCondition
    {
        [Key, Column(Order = 1)]
        public int ResearchId { get; set; }

        [Key, Column(Order = 2)]
        public int MeasureConditionId { get; set; }

        public Research Research { get; private set; }

        public MeasureCondition MeasureCondition { get; private set; }

        protected ResearchMeasureCondition()
        {
        }
        public ResearchMeasureCondition(Research research, MeasureCondition measureCondition)
        {
            if (research == null)
            {
                throw new ArgumentNullException("researchesearch");
            }
            if (measureCondition == null)
            {
                throw  new ArgumentNullException("measureCondition");
            }

            Research = research;
            MeasureCondition = measureCondition;
        }

    }
}