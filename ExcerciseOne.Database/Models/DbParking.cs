using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseOne.Database.Models
{
    public class DbParking
    {
        public int Id { get; set; }
        public int ParkingId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
