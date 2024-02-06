using LivingMapAPI.Models;
using Persistences;
using Persistences.Models;

namespace LivingMapAPI.Services
{
    public class LivingMapService
    {
        public List<Coordinate> GetCoordinatesByLevel2(string divText, string areaLevel2)
        {
            List<Coordinate> rtnVal = [];

            string div = "";
            // divText 를 통해 div 값 받아오기
            switch (divText)
            {
                case "close":
                    div = "DIV01";
                    break;
                case "battery":
                    div = "DIV02";
                    break;
                case "smoke":
                    div = "DIV03";
                    break;
                default:
                    break;
            }

            using(var context = new LivingMapContext())
            {
                rtnVal = context.Locations.Where(location => 
                    location.Div == div &&
                    location.Level2 == areaLevel2 && 
                    location.UseYn && 
                    location.SuccessYn).Select(i => new Coordinate(i.Latitude, i.Longitude)) .ToList();
            }

            return rtnVal;
        }
    }
}
