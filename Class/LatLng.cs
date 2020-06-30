using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LatLng(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
        }
    }
}