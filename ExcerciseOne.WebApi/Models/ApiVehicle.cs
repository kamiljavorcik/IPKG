using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApi.Models
{
    public class ApiVehicle
    {
        public int Id { get; set; }
        public int VehicleId {get;set;}
        public string Name { get; set; }
        public decimal EnterCost { get; set; }
        public decimal DistanceCost { get; set; }
    }
}