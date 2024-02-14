using LivingMapAPI.Models;
using LivingMapAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistences.Models;

namespace LivingMapAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {
        // GET: MapController
        //public ActionResult Index()
        //{
        //    //return View();
        //}


        [HttpGet("{div}")]
        public IEnumerable<Coordinate> GetByLevel2(string div, [FromQuery]string level2)
        {
            //string encodedLevel2 = Uri.EscapeDataString(level2);

            LivingMapService service = new LivingMapService();
            List<Coordinate> locations = service.GetCoordinatesByLevel2(div, level2);

            return locations;
        }


        [HttpGet("coord")]
        public LocationRes GetByCoord([FromQuery]Coordinate coord)
        {
            LivingMapService service = new LivingMapService();
            Location? location = service.GetLocationByCoord(coord);
            LocationRes res = new(location);
            return res;
        }
    }
}
