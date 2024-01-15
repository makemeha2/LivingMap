using LivingMapAPI.Models;
using Persistences;
using Persistences.Models;

namespace LivingMapAPI.Services
{
    public class LivingMapService
    {
        public List<Coordinate> GetCoordinatesByLevel2(string div, string areaLevel2)
        {
            List<Coordinate> rtnVal = [];

            using(var context = new LivingMapContext())
            {
                rtnVal = context.Locations.Where(location => location.Level2 == areaLevel2 && location.UseYn && location.SuccessYn).Select(i => new Coordinate(i.Latitude, i.Longitude)) .ToList();
            }

            return rtnVal;
        }
    }
}
