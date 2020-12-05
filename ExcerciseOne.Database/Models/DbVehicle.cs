using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseOne.Database.Models
{
    public class DbVehicle
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public decimal EnterCost { get; set; }
        public decimal DistanceCost { get; set; }
    }
}
