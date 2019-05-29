using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartTravel.Models;
using SmartTravel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SmartTravel.Controllers
{
    public class SearchController : ApiController
    {
        OkloDBEntities _context = new OkloDBEntities();

        [HttpGet]
        public string HotelSearch(SearchViewModel objModel)
        {
            string token = GetAccessToken();

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
            return result;
        }


        [HttpGet]
        public void Test()
        {
            string json = @"{  
            'ClientRequestID': '998db50392ac41a2',  
            'Sid': 'dev2',
            'Results':[
                {
                    'HotelID' : 4052,
                    'HotelContractID' : 5317,
                    'ClientNetSellTotal' :  0.197024197024
                }
            ]
            }";

            HotelResult bsObj = JsonConvert.DeserializeObject<HotelResult>(json);
        }


        [HttpGet]
        public List<LocationObj> GetLocation(string search)
        {
            List<B2B_Locations> lst = _context.B2B_Locations.Where(w => w.IsActive == true && w.LocationName.StartsWith(search)).OrderBy(w => w.LocationName).ToList();
            List<LocationObj> locationObjList = new List<LocationObj>();

            foreach (var item in lst)
            {
                LocationObj infoObj = new LocationObj();
                infoObj.Location_Id = item.LocationID;
                infoObj.Location_Name = item.LocationName;
                locationObjList.Add(infoObj);
            }

            return locationObjList;
        }

        public string GetAccessToken()
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "string" ),
                        new KeyValuePair<string, string>( "sid", "string" ),
                        new KeyValuePair<string, string>( "cid", "string" ),
                        new KeyValuePair<string, string> ( "key", "string" )
                    };

            var content = new FormUrlEncodedContent(pairs);

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using (var client = new HttpClient())
            {
                var response = client.PostAsync("https://virtserver.swaggerhub.com/okloworldAPI/oklo-Exchange/1.0.0/exchange-api/token", content).Result; //client.PostAsync(url + "Token", content).Result;
                var text = response.Content.ReadAsStringAsync();

                var jObj = JObject.Parse(text.Result.ToString());
                string accessToken = jObj.First.Last.ToString();

                return accessToken;
            }
        }
    }
}
