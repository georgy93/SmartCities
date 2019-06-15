using System;
using System.ComponentModel.DataAnnotations;

namespace SmartCities.Models
{
    public class SearchObjectVm
    {
        [Display(Name = "Male")]
        public bool IncludeMale { get; set; }
        
        [Display(Name = "Female")]
        public bool IncludeFemale { get; set; }

        [Display(Name = "not specified")]
        public bool IncludeUnknowGender { get; set; }

        [Display(Name = "18-25")]
        public bool Include_18_to_25 { get; set; }

        [Display(Name = "26-35")]
        public bool Include_26_to_35 { get; set; }

        [Display(Name = "36-45")]
        public bool Include_36_to_45 { get; set; }

        [Display(Name = "46-65")]
        public bool Include_46_to_65 { get; set; }

        [Display(Name = "66-100")]
        public bool Include_66_to_100 { get; set; }

        [Display(Name = "Start date")]
        public DateTime? StartDate { get; set; }
    }
}
