using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExcerciseOne.WebApi.Controllers
{
    public class DatabaseController : ApiController
    {
        private Database.IDatabase db { get; set; }

        public DatabaseController() : this(new Database.Database()) { }

        public DatabaseController(Database.IDatabase db)
        {
            this.db = db;
        }

        public IEnumerable<Models.ApiParking> GetParkings()
        {
            return db.GetParkings().GroupBy(x => x.ParkingId)
                .Select(x => x.FirstOrDefault(y => y.Id == x.Max(z => z.Id)))
                .Select(x => new Models.ApiParking()
                {
                    Id = x.Id,
                    ParkingId = x.ParkingId,
                    Name = x.Name,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude

                }).ToList();
        }

        public Models.ApiParking GetParking(int parkingId)
        {
            return db.GetParkings()
                .GroupBy(x => x.ParkingId)
                .Select(x => x.FirstOrDefault(y => y.Id == x.Max(z => z.Id)))
                .Select(x => new Models.ApiParking()
                {
                    Id = x.Id,
                    ParkingId = x.ParkingId,
                    Name = x.Name,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude

                }).FirstOrDefault(x => x.ParkingId == parkingId);
        }

        public void SetParking([FromBody]Models.ApiParking parking)
        {
            List<Models.ApiParking> list = new List<Models.ApiParking>();
            list.Add(parking);

            db.SetParkings(list.Select(x => new Database.Models.DbParking()
            {
                Id = x.Id,
                ParkingId = x.ParkingId,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).AsQueryable());
        }

        public IEnumerable<Models.ApiVehicle> GetVehicles()
        {
            return db.GetVehicles().GroupBy(x => x.VehicleId)
                .Select(x => x.FirstOrDefault(y => y.Id == x.Max(z => z.Id)))
                .Select(x => new Models.ApiVehicle()
                {
                    Id = x.Id,
                    VehicleId = x.VehicleId,
                    Name = x.Name,
                    EnterCost = x.EnterCost,
                    DistanceCost = x.DistanceCost

                }).ToList();
        }

        public Models.ApiVehicle GetVehicle(int vehicleId)
        {
            return db.GetVehicles()
                .GroupBy(x => x.VehicleId)
                .Select(x => x.FirstOrDefault(y => y.Id == x.Max(z => z.Id)))
                .Select(x => new Models.ApiVehicle()
                {
                    Id = x.Id,
                    VehicleId = x.VehicleId,
                    Name = x.Name,
                    EnterCost = x.EnterCost,
                    DistanceCost = x.DistanceCost

                }).FirstOrDefault(x => x.VehicleId == vehicleId);
        }

        public void SetVehicle([FromBody]Models.ApiVehicle vehicle)
        {
            List<Models.ApiVehicle> list = new List<Models.ApiVehicle>();
            list.Add(vehicle);

            db.SetVehicles(list.Select(x => new Database.Models.DbVehicle()
            {
                Id = x.Id,
                VehicleId = x.VehicleId,
                Name = x.Name,
                EnterCost = x.EnterCost,
                DistanceCost = x.DistanceCost
            }).AsQueryable());
        }

        public IEnumerable<Models.ApiRoute> GetRoutes()
        {
            return db.GetRoutes().GroupBy(x => x.RouteId)
                .Select(x => x.FirstOrDefault(y => y.Id == x.Max(z => z.Id)))
                .Select(x => new Models.ApiRoute()
                {
                    Id = x.Id,
                    VehicleId = x.VehicleId,
                    RouteId = x.RouteId,
                    DepartureId = x.DepartureId,
                    DestinationId = x.DestinationId
                }).ToList();
        }

        public Models.ApiRoute GetRoute(int routeId)
        {
            return db.GetRoutes()
                .GroupBy(x => x.RouteId)
                .Select(x => x.FirstOrDefault(y => y.Id == x.Max(z => z.Id)))
                .Select(x => new Models.ApiRoute()
                {
                    Id = x.Id,
                    RouteId = x.RouteId,
                    VehicleId = x.VehicleId,
                    DepartureId = x.DepartureId,
                    DestinationId = x.DestinationId
                }).FirstOrDefault(x => x.RouteId == routeId);
        }

        public void SetRoute([FromBody]Models.ApiRoute route)
        {
            List<Models.ApiRoute> list = new List<Models.ApiRoute>();
            list.Add(route);

            db.SetRoutes(list.Select(x => new Database.Models.DbRoute()
            {
                Id = x.Id,
                RouteId = x.RouteId,
                VehicleId = x.VehicleId,
                DepartureId = x.DepartureId,
                DestinationId = x.DestinationId
            }).AsQueryable());
        }
        
        public IEnumerable<Models.ApiSummary> GetSummary()
        {
            return db.GetSummary().Select(x => new Models.ApiSummary()
            {
                Id = x.Id,
                RouteId = x.RouteId,
                Vehicle = x.Vehicle,
                EnterCost = x.EnterCost,
                DistanceCost = x.DistanceCost,
                DepName = x.DepName,
                DepLatitude = x.DepLatitude,
                DepLongitude = x.DepLongitude,
                DesName = x.DesName,
                DesLatitude = x.DesLatitude,
                DesLongitude = x.DesLongitude
            }).AsEnumerable();
        }
        
    }
}
