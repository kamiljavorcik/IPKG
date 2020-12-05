using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ExcerciseOne.Database.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void GetParkings()
        {
            IDatabase db = new Database();
            var result = db.GetParkings();
            var list = result.ToList();
        }

        [TestMethod]
        public void SetParkings()
        {
            IDatabase db = new Database();
            List<Models.DbParking> parkings = new List<Models.DbParking>();
            db.SetParkings(parkings.AsQueryable());
        }

        [TestMethod]
        public void SetParkingsItem()
        {
            IDatabase db = new Database();
            List<Models.DbParking> parkings = new List<Models.DbParking>();

            Models.DbParking parking = new Models.DbParking()
            {
                Id = 0,
                ParkingId = 0,
                Name = "test",
                Latitude = 0,
                Longitude = 0
            };
            parkings.Add(parking);

            db.SetParkings(parkings.AsQueryable());

            var result = db.GetParkings();
            var list = result.ToList();

        }

        [TestMethod]
        public void GetVehicles()
        {
            IDatabase db = new Database();
            var result = db.GetVehicles();
            var list = result.ToList();
        }

        [TestMethod]
        public void SetVehicles()
        {
            IDatabase db = new Database();
            List<Models.DbVehicle> vehicles = new List<Models.DbVehicle>();
            db.SetVehicles(vehicles.AsQueryable());
        }

        [TestMethod]
        public void SetVehiclesItem()
        {
            IDatabase db = new Database();
            List<Models.DbVehicle> vehicles = new List<Models.DbVehicle>();

            Models.DbVehicle vehicle = new Models.DbVehicle()
            {
                Id = 0,
                VehicleId = 0,
                Name = "test",
                EnterCost = 0,
                DistanceCost = 0
            };
            vehicles.Add(vehicle);

            db.SetVehicles(vehicles.AsQueryable());

            var result = db.GetParkings();
            var list = result.ToList();

        }

        [TestMethod]
        public void GetRoutes()
        {
            IDatabase db = new Database();
            var result = db.GetRoutes();
            var list = result.ToList();
        }

        [TestMethod]
        public void SetRoutes()
        {
            IDatabase db = new Database();
            List<Models.DbRoute> routes = new List<Models.DbRoute>();
            db.SetRoutes(routes.AsQueryable());
        }

        [TestMethod]
        public void SetRoutesItem()
        {
            IDatabase db = new Database();

            //parkings
            List<Models.DbParking> parkings = new List<Models.DbParking>();
            Models.DbParking parking = new Models.DbParking()
            {
                Id = 1,
                ParkingId = 1,
                Name = "test",
                Latitude = 0,
                Longitude = 0
            };
            parkings.Add(parking);
            db.SetParkings(parkings.AsQueryable());

            //vehicles
            List<Models.DbVehicle> vehicles = new List<Models.DbVehicle>();
            Models.DbVehicle vehicle = new Models.DbVehicle()
            {
                Id = 1,
                VehicleId = 1,
                Name = "test",
                EnterCost = 0,
                DistanceCost = 0
            };
            vehicles.Add(vehicle);
            db.SetVehicles(vehicles.AsQueryable());

            //route
            List<Models.DbRoute> routes = new List<Models.DbRoute>();

            Models.DbRoute route = new Models.DbRoute()
            {
                Id = 1,
                RouteId = 1,
                VehicleId = 1,
                DepartureId = 1,
                DestinationId = 1
            };
            routes.Add(route);

            db.SetRoutes(routes.AsQueryable());

            var result = db.GetParkings();
            var list = result.ToList();
        }

        [TestMethod]
        public void GetSummary()
        {
            IDatabase db = new Database();
            var result = db.GetSummary();
            var list = result.ToList();
        }
    }
}
