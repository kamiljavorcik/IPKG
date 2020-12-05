using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcerciseOne.WebApp.Models
{
    public class Route
    {
        public int? Id { get; set; }
        public int? RouteId { get; set; }
        public int? VehicleId { get; set; }
        public int? DepartureId { get; set; }
        public int? DestinationId { get; set; }

        public IEnumerable<SelectListItem> vehicles { get; set; }
        public IEnumerable<SelectListItem> departures { get; set; }
        public IEnumerable<SelectListItem> destinations { get; set; }
    }
}