using LivingMapAPI.DTOs;
using LivingMapAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost("complaint")]
        public IActionResult RegisterComplaint([FromBody]ComplaintReq complaintReq)
        {
            IActionResult actionResult = null;
            try
            {
                LivingMapService service = new LivingMapService();
                int result = service.RegisterCompliant(complaintReq);

                if (result > 0)
                {
                    actionResult = Ok(ResponseInfo<int>.CreateSuccess(result));
                }
                else
                {
                    actionResult = Ok(ResponseInfo<object>.CreateFailure("오류발생"));
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex1)
            {
                if(ex1.InnerException != null)
                {
                    if(ex1.InnerException.Message.Contains("FK_Complaint_Location"))
                    {
                        actionResult = Ok(ResponseInfo<object>.CreateFailure("존재하지 않는 위치입니다."));
                    }
                    else
                    {
                        actionResult = Ok(ResponseInfo<object>.CreateFailure(ex1.InnerException.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                actionResult = Ok(ResponseInfo<object>.CreateFailure(ex.Message));
            }

            return actionResult;
        }
    }
}
