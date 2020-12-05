using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApi.Models
{
    public class ApiRoute
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int VehicleId { get; set; }
        public int DepartureId { get; set; }
        public int DestinationId { get; set; }
    }
}