using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApi.Models
{
    public class ApiParking
    {
        public int Id { get; set; }
        public int ParkingId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}