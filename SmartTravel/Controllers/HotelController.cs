using Newtonsoft.Json;
using SmartTravel.Models;
using SmartTravel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTravel.Controllers
{
    public class HotelController : Controller
    {
        OkloDBEntities _context = new OkloDBEntities();
        // GET: Hotel
        public ActionResult Index()
        {
            Hotel obj = new Hotel();
            obj.Destination = new Destination { group = "Country", id = 11082, text = "SRI LANKA (LK)" };

            obj.CheckIn = DateTime.Now.AddDays(1);
            obj.CheckOut = DateTime.Now.AddDays(2);
            obj.Honeymoon = false;
            obj.Wedding = false;
            obj.Offers = "";
            obj.Market = "";
            obj.Skip = 0;
            obj.RoomCount = 1;
            obj.ResultsPerPage = "25";
            obj.RoomOrderLimit = "1";
            obj.MinStars = "";
            obj.MaxStars = "";
            obj.Options = new Options { AddTransfers = false, AllRoomsSameCategory = false, BookPackages = false, HideRates = false, SingleDoupleTriple = false, TourBuilder = false };
            obj.Rooms = new Rooms(1, 0)
            {
                RoomCount = "1"
            };

            string result = JsonConvert.SerializeObject(obj);
            result = result.Replace("RoomTable", "Rooms");
            Console.WriteLine(result);

            return View();
        }

        public ActionResult Hotels()
        {
            SearchViewModel objModel = new SearchViewModel();
            objModel.LocationList = _context.B2B_Locations.Where(w => w.IsActive == true).OrderBy(w => w.LocationName).ToList();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchHotel(SearchViewModel objModel)
        {
            return View();
        }
    }
}