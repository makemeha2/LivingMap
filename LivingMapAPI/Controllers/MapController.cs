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
            string encodedLevel2 = Uri.EscapeDataString(level2);

            LivingMapService service = new LivingMapService();
            List<Coordinate> locations = service.GetCoordinatesByLevel2(div, level2);

            return locations;
        }

        //// GET: MapController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: MapController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MapController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: MapController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: MapController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: MapController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: MapController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
