using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SpeakerAssignment
    {
        public int SacramentPlanID { get; set; }
        public int SpeakerID { get; set; }
        public SacramentPlan SacramentPlan { get; set; }
        public Speaker Speaker { get; set; }
    }
}
