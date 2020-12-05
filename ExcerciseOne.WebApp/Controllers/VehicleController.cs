using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcerciseOne.WebApp.Services.WebApi;

namespace ExcerciseOne.WebApp.Controllers
{
    [HandleError]
    public class VehicleController : Controller
    {
        private Services.WebApi.IDatabase api { get; set; }

        public VehicleController()
        {
            var uri = new Uri(Configuration.WebApiUrl);
            var cred = new Microsoft.Rest.BasicAuthenticationCredentials();
            var client = new Services.WebApi.ExcerciseOneWebApi(uri, cred);
            var svc = new Services.WebApi.Database(client);
            this.api = svc;
        }

        public VehicleController(Services.WebApi.IDatabase api)
        {
            this.api = api;
        }

        public ActionResult Index()
        {
            var vehicles = api.GetVehicles();

            var model = new Models.VehicleIndex();
            model.vehicles = vehicles.Select(x => new Models.Vehicle()
            {
                Id = x.Id,
                Name = x.Name,
                VehicleId = x.VehicleId,
                EnterCost = x.EnterCost,
                DistanceCost = x.DistanceCost
            }).AsEnumerable();
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            var vehicle = api.GetVehicle(id ?? 0);
            var model = new Models.Vehicle()
            {
                Id = vehicle?.Id,
                Name = vehicle?.Name,
                VehicleId = vehicle?.VehicleId,
                EnterCost = vehicle?.EnterCost,
                DistanceCost = vehicle?.DistanceCost
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(Models.Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Services.WebApi.Models.ApiVehicle apiVehicle = new Services.WebApi.Models.ApiVehicle() {
                    Id = vehicle.Id,
                    VehicleId = vehicle.VehicleId,
                    Name = vehicle.Name,
                    EnterCost = vehicle.EnterCost,
                    DistanceCost = vehicle.DistanceCost
                };
                api.SetVehicle(apiVehicle);

                return RedirectToAction("Index");
            }

            return View(vehicle);
        }
    }
}