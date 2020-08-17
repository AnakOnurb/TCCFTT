using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARE_Web_API.Models
{
    public class ICoordinate
    {
        double Latitude { get; set; }
        double Longitude { get; set; }

        public ICoordinate() 
        { }

        public ICoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Returns the Euclidian Distance between the two coodinates
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public double getDistance(ICoordinate newCoord)
        {
            return Utils.Utils.EuclidianDistance(Latitude, Longitude, newCoord.Latitude, newCoord.Longitude);
        }
    }
}
