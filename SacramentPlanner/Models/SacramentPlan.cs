using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SacramentPlan
    {
        public int SacramentPlanID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required, StringLength(60)]
        public string Conducting { get; set; }

        [Required, StringLength(30), Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }

        [Required, StringLength(80)]
        public string Invocation { get; set; }

        [Required, StringLength(30), Display(Name = "Sacrament Hymn")]
        public string SacramentHymn { get; set; }

        [StringLength(30)]
        [Display(Name = "Intermediate Hymn"), DisplayFormat(NullDisplayText = "")] // I'm not sure this is the best way to do this...
        public string IntermediateHymn { get; set; }

        [Required, StringLength(30), Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }

        [Required, StringLength(80)]
        public string Benediction { get; set; }
    }
}
