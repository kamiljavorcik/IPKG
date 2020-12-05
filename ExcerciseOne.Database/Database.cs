using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseOne.Database
{
    public class Database : IDatabase
    {
        private DatabaseEntities db { get; set; }

        public Database() : this(new ExcerciseOne.Database.DatabaseEntities()) { }

        public Database(DatabaseEntities db)
        {
            this.db = db;
        }

        public IQueryable<Models.DbParking> GetParkings()
        {
            return db.TblParkings
                .Select(x =>
                    new Models.DbParking()
                    {
                        Id = x.Id,
                        ParkingId = x.ParkingId,
                        Name = x.Name,
                        Latitude = x.Latitude,
                        Longitude = x.Longitude
                    }).AsQueryable();
        }

        public void SetParkings(IQueryable<Models.DbParking> parkings)
        {
            db.TblParkings
                .AddRange(parkings.Select(x => new TblParking()
                {
                    Id = db.TblParkings.Select(y => y.Id).DefaultIfEmpty(0).Max() + 1,
                    ParkingId = x.ParkingId < 1 ? db.TblParkings.Select(y => y.ParkingId).DefaultIfEmpty(0).Max() + 1 : x.ParkingId,
                    Name = x.Name,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude
                }));

            db.SaveChanges();
        }

        public IQueryable<Models.DbVehicle> GetVehicles()
        {
            return db.TblVehicles
                .Select(x =>
                    new Models.DbVehicle()
                    {
                        Id = x.Id,
                        VehicleId = x.VehicleId,
                        Name = x.Name,
                        EnterCost = x.EnterCost,
                        DistanceCost = x.DistanceCost
                    }).AsQueryable();
        }

        public void SetVehicles(IQueryable<Models.DbVehicle> vehicles)
        {
            db.TblVehicles
                .AddRange(vehicles.Select(x => new TblVehicle()
                {
                    Id = db.TblVehicles.Select(y => y.Id).DefaultIfEmpty(0).Max() + 1,
                    VehicleId = x.VehicleId < 1 ? db.TblVehicles.Select(y => y.VehicleId).DefaultIfEmpty(0).Max() + 1 : x.VehicleId,
                    Name = x.Name,
                    EnterCost = x.EnterCost,
                    DistanceCost = x.DistanceCost
                }));

            db.SaveChanges();
        }

        public IQueryable<Models.DbRoute> GetRoutes()
        {
            return db.TblRoutes
                .Select(x =>
                    new Models.DbRoute()
                    {
                        Id = x.Id,
                        RouteId = x.RouteId,
                        VehicleId = x.VehicleId,
                        DepartureId = x.DepartureId,
                        DestinationId = x.DestinationId
                    }).AsQueryable();
        }

        public void SetRoutes(IQueryable<Models.DbRoute> routes)
        {
            db.TblRoutes
                .AddRange(routes.Select(x => new TblRoute()
                {
                    Id = db.TblRoutes.Select(y => y.Id).DefaultIfEmpty(0).Max() + 1,
                    RouteId = x.RouteId < 1 ? db.TblRoutes.Select(y => y.RouteId).DefaultIfEmpty(0).Max() + 1 : x.RouteId,
                    VehicleId = x.VehicleId,
                    DepartureId = x.DepartureId,
                    DestinationId = x.DestinationId
                }));

            db.SaveChanges();
        }
        
        public IQueryable<Models.DbSummary> GetSummary()
        {
            return db.VieSummaries.Select(x => new Models.DbSummary() 
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
            }).AsQueryable();
        }
        
    }
}
