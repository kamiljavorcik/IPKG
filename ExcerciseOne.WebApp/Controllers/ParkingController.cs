using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcerciseOne.WebApp.Services.WebApi;

namespace ExcerciseOne.WebApp.Controllers
{
    [HandleError]
    public class ParkingController : Controller
    {

        private Services.WebApi.IDatabase api { get; set; }

        public ParkingController()
        {
            var uri = new Uri(Configuration.WebApiUrl);
            var cred = new Microsoft.Rest.BasicAuthenticationCredentials();
            var client = new Services.WebApi.ExcerciseOneWebApi(uri, cred);
            var svc = new Services.WebApi.Database(client);
            this.api = svc;
        }

        public ParkingController(Services.WebApi.IDatabase api)
        {
            this.api = api;
        }

        // GET: Parking
        public ActionResult Index()
        {
            var parkings = api.GetParkings();

            var model = new Models.ParkingIndex();
            model.parkings = parkings.Select(x => new Models.Parking()
            {
                Id = x.Id,
                ParkingId = x.ParkingId,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).AsEnumerable();
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            var parking = api.GetParking(id ?? 0);
            var model = new Models.Parking()
            {
                Id = parking.Id,
                ParkingId = parking.ParkingId,
                Name = parking.Name,
                Latitude = parking.Latitude,
                Longitude = parking.Longitude
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(Models.Parking parking)
        {
            if (ModelState.IsValid)
            {
                Services.WebApi.Models.ApiParking apiParking = new Services.WebApi.Models.ApiParking()
                {
                    Id = parking.Id,
                    ParkingId = parking.ParkingId,
                    Name = parking.Name,
                    Latitude = parking.Latitude,
                    Longitude = parking.Longitude
                };
                api.SetParking(apiParking);

                return RedirectToAction("Index");
            }

            return View(parking);
        }

    }
}