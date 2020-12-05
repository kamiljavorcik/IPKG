using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApp.Models
{
    public class Parking
    {
        public int? Id { get; set; }
        public int? ParkingId { get; set; }
        public string Name { get; set; }
        [Range(-90,90)]
        public double? Latitude { get; set; }
        [Range(-180, 180)]
        public double? Longitude { get; set; }
    }
}