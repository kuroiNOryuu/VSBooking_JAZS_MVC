using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSBooking_JAZS_MVC.ViewModels
{
    public class SearchResultsVM
    {
        public IList<SearchResult> SearchResult { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
    }
}