using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApp.Models
{
    public class Summary
    {
        public int? Id { get; set; }
        public int? RouteId { get; set; }
        public string Vehicle { get; set; }
        public double? EnterCost { get; set; }
        public double? DistanceCost { get; set; }
        public string DepName { get; set; }
        public double? DepLatitude { get; set; }
        public double? DepLongitude { get; set; }
        public string DesName { get; set; }
        public double? DesLatitude { get; set; }
        public double? DesLongitude { get; set; }
        public double? Distance { get; set; }
        public double? Cost { get; set; }
    }
}