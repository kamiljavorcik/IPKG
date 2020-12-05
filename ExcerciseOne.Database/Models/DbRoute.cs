using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseOne.Database.Models
{
    public class DbRoute
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int DepartureId { get; set; }
        public int DestinationId { get; set; }
        public int VehicleId { get; set; }
    }
}
