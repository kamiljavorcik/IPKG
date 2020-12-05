using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcerciseOne.WebApp.Services.WebApi;

namespace ExcerciseOne.WebApp.Controllers
{
    [HandleError]
    public class RouteController : Controller
    {
        private Services.WebApi.IDatabase api { get; set; }

        public RouteController()
        {
            var uri = new Uri(Configuration.WebApiUrl); 
            var cred = new Microsoft.Rest.BasicAuthenticationCredentials();
            var client = new Services.WebApi.ExcerciseOneWebApi(uri,cred);
            var svc = new Services.WebApi.Database(client);
            this.api = svc;
        }

        public RouteController(Services.WebApi.IDatabase svc)
        {
            this.api = svc;
        }

        // GET: Route
        public ActionResult Index()
        {
            var model = new Models.RouteIndex();
            var routes = api.GetRoutes();
            model.routes = routes.Select(x => new Models.Route() {
                Id = x.Id,
                RouteId = x.RouteId,
                VehicleId = x.VehicleId,
                DepartureId = x.DepartureId,
                DestinationId = x.DestinationId
            }).AsEnumerable();
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            var route = api.GetRoute(id ?? 0);
            var model = new Models.Route()
            {
                Id = route?.Id,
                RouteId = route?.RouteId,
                VehicleId = route?.VehicleId,
                DepartureId = route?.DepartureId,
                DestinationId = route?.DestinationId
            };
            var parkings = api.GetParkings();
            
            var vehicles = new List<SelectListItem>();
            var departures = new List<SelectListItem>();
            var destinations = new List<SelectListItem>();

            if (route != null)
            {
                vehicles.Add(new SelectListItem() { Text = "Current", Value = (model.VehicleId ?? 0).ToString() });
                departures.Add(new SelectListItem() { Text = "Current", Value = (model.DepartureId ?? 0).ToString() });
                destinations.Add(new SelectListItem() { Text = "Current", Value = (model.DestinationId ?? 0).ToString() });
            }

            vehicles.AddRange(api.GetVehicles().Select(x => new SelectListItem() { Text = x.Name, Value = (x.Id ?? 0).ToString() }));
            departures.AddRange(parkings.Select(x => new SelectListItem() { Text = x.Name, Value = (x.Id ?? 0).ToString() }));
            destinations.AddRange(parkings.Select(x => new SelectListItem() { Text = x.Name, Value = (x.Id ?? 0).ToString() }));

            model.vehicles = vehicles;            
            model.departures = departures;
            model.destinations = destinations;


            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(Models.Route route)
        {
            if (ModelState.IsValid)
            {
                Services.WebApi.Models.ApiRoute apiRoute = new Services.WebApi.Models.ApiRoute()
                {
                    Id = route.Id,
                    RouteId = route.RouteId,
                    VehicleId = route.VehicleId,
                    DepartureId = route.DepartureId,
                    DestinationId = route.DestinationId
                };
                api.SetRoute(apiRoute);

                return RedirectToAction("Index");
            }

            return View(route);
        }
    }
}
