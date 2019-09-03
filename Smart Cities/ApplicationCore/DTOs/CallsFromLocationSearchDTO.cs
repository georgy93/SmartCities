namespace ApplicationCore.DTOs
{
    using System;

    public class CallsFromLocationSearchDTO
    {
        public bool IncludeMale { get; set; }
        public bool IncludeFemale { get; set; }
        public bool IncludeUnknowGender { get; set; }
        public bool Include_18_to_25 { get; set; }
        public bool Include_26_to_35 { get; set; }
        public bool Include_36_to_45 { get; set; }
        public bool Include_46_to_65 { get; set; }
        public bool Include_66_to_100 { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
