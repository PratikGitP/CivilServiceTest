using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApplication1.Class;
using WebApplication1.Repository;
using WebApplication1.Extension;

namespace WebApplication1.Mediator
{
    public class PeopleMediator
    {
        public IEnumerable<User> GetByCityRange(string city,int range)
        {
            LatLng london = new LatLng(51.509865, -0.118092);

            ServiceRepo repo = new ServiceRepo();

            var londonUsers = repo.GetUsersByCity(city);
            var allUsers = repo.GetUsers().ToList();
            for(int i=0; i < allUsers.Count();i++)
            {
                allUsers[i].Distance = Distance(london, new LatLng(allUsers[i].latitude, allUsers[i].longitude));
            }

            var closest = allUsers.OrderBy(x => x.Distance).Where(x => x.Distance <= range);

            var results = londonUsers.Concat(closest);

            return results;
        }

        private double Distance(LatLng pos1, LatLng pos2)
        {
            double R = 3960;
            var lat = (pos2.Latitude - pos1.Latitude).ToRadians();
            var lng = (pos2.Longitude - pos1.Longitude).ToRadians();
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                          Math.Cos(pos1.Latitude.ToRadians()) * Math.Cos(pos2.Latitude.ToRadians()) *
                          Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            return R * h2;
        }

    }
}