using IScaleAPI.Entities;
using IScaleAPI.Repository.Rainfall;
using IScaleAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

namespace IScaleAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RainfallController : Controller
    {
        private readonly IRainfallService service;

        public RainfallController(IRainfallService rainfallService) {
            service = rainfallService;
        }
        
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseSchema), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseSchema), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RainfallViewModel), StatusCodes.Status200OK)]
        public ActionResult<Item> LoadMessurement(int id)
        {           
            try
            {
                return Ok(service.LoadMessurement(id));
            }
            catch (Exception)
            {
                return BadRequest(new ResponseSchema { Message = "Bad Request" });
            }           
        }      
    }
}
