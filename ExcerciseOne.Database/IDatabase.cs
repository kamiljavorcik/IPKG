using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseOne.Database
{
    public interface IDatabase
    {
        IQueryable<Models.DbParking> GetParkings();
        void SetParkings(IQueryable<Models.DbParking> parkings);

        IQueryable<Models.DbVehicle> GetVehicles();
        void SetVehicles(IQueryable<Models.DbVehicle> vehicles);

        IQueryable<Models.DbRoute> GetRoutes();
        void SetRoutes(IQueryable<Models.DbRoute> routes);

        IQueryable<Models.DbSummary> GetSummary();
    }
}
