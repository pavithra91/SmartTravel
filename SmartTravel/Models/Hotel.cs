using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SmartTravel.Models
{
    public class Hotel
    {
        public Destination Destination { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Wedding { get; set; }
        public bool Honeymoon { get; set; }
        public string Offers { get; set; }
        public string Market { get; set; }
        public int RoomCount { get; set; }
        public string ResultsPerPage { get; set; }
        public int Skip { get; set; }
        public string RoomOrderLimit { get; set; }
        public string MinStars { get; set; }
        public string MaxStars { get; set; }
        public Options Options { get; set; }

        public Rooms Rooms { get; set; }

    }

    public class Rooms
    {
        public Rooms(int Adults, int Children)
        {
            RoomTable = CreateDataTable();
            RoomTable.Rows.Add(Adults, Children);
        }
        public string RoomCount { get; set; }
        public DataTable RoomTable { get; set; }
        public static DataTable CreateDataTable()
        {

            DataTable Rooms = new DataTable();
            Rooms.Columns.Add("Adults", typeof(int));
            Rooms.Columns.Add("Children", typeof(int));
            return Rooms;
        }
    }

    public struct Destination
    {
        public string group { get; set; }
        public int id { get; set; }
        public string text { get; set; }
    }
    public class Options
    {
        public bool AllRoomsSameCategory { get; set; }
        public bool HideRates { get; set; }
        public bool SingleDoupleTriple { get; set; }
        public bool TourBuilder { get; set; }
        public bool BookPackages { get; set; }
        public bool AddTransfers { get; set; }
    }

    public class HotelResult
    {
        public string ClientRequestID { get; set; }
        //public string Sid { get; set; }

        public List<Results> Results { get; set; }
    }

    public struct Results
    {
        public int HotelID { get; set; }
        public int HotelContractID { get; set; }
        public double ClientNetSellTotal { get; set; }
    }
}