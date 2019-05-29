using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTravel.ViewModels
{
    public class SearchViewModel
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public List<B2B_Locations> LocationList { get; set; }
    }
    public class LocationObj
    {
        public int Location_Id { get; set; }
        public string Location_Name { get; set; }
    }
}