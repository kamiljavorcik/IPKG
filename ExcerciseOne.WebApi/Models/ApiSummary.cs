using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApi.Models
{
    public class ApiSummary
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string Vehicle { get; set; }
        public decimal? EnterCost { get; set; }
        public decimal? DistanceCost { get; set; }
        public string DepName { get; set; }
        public decimal? DepLatitude { get; set; }
        public decimal? DepLongitude { get; set; }
        public string DesName { get; set; }
        public decimal? DesLatitude { get; set; }
        public decimal? DesLongitude { get; set; }
    }
}