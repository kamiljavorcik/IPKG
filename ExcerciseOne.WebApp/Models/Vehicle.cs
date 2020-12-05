using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApp.Models
{
    public class Vehicle
    {
        public int? Id { get; set; }
        public int? VehicleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double? EnterCost { get; set; }
        [Required]
        public double? DistanceCost { get; set; }
    }
}