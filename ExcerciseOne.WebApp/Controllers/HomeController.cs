using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcerciseOne.WebApp.Services.WebApi;

namespace ExcerciseOne.WebApp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {

        private Services.WebApi.IDatabase api { get; set; }

        public HomeController()
        {
            var uri = new Uri(Configuration.WebApiUrl);
            var cred = new Microsoft.Rest.BasicAuthenticationCredentials();
            var client = new Services.WebApi.ExcerciseOneWebApi(uri, cred);
            var svc = new Services.WebApi.Database(client);
            this.api = svc;
        }

        public HomeController(Services.WebApi.IDatabase api)
        {
            this.api = api;
        }

        public ActionResult Index()
        {
            var summaries = api.GetSummary();
            var model = new Models.SummaryIndex();

            var list = summaries.Select(x => new Models.Summary()
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
            }).ToList();

            var gps_src = new System.Device.Location.GeoCoordinate(0, 0);
            var gps_dst = new System.Device.Location.GeoCoordinate(0, 0);

            foreach (var summary in list)
            {
                gps_src.Latitude = summary.DepLatitude ?? 0;
                gps_src.Longitude = summary.DepLongitude ?? 0;
                gps_dst.Latitude = summary.DesLatitude ?? 0;
                gps_dst.Longitude = summary.DesLongitude ?? 0;

                summary.Distance = Math.Round(gps_src.GetDistanceTo(gps_dst) / 1000, 2); // in km
                summary.Cost = Math.Round((summary.EnterCost??0) + (summary.Distance??0) * (summary.DistanceCost??0), 2);
            }

            model.summaries = list;

            return View(model);
        }
    }
}