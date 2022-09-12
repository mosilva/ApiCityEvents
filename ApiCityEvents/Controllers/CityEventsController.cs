using ApiCityEvents.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityEventsController : ControllerBase
    {

        public CityEvent cityEvent;
        private readonly ILogger<CityEventsController> _logger;

        public CityEventsController(ILogger<CityEventsController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "/CreateNewCityEvent")]
        public ActionResult<CityEvent> CreateCityEvent(CityEvent city)
        {

            return CreatedAtAction(nameof(CreateCityEvent), city);

        }

        [HttpGet(Name = "/Title")]
        public IActionResult QueryForTitle()
        {
            return Ok();
        }

        [HttpPut(Name = "/UpdateCityEventComplete")]
        public IActionResult UpdateCityEventComplete(int index,CityEvent city)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCityEvent(int index)
        {
            return Ok();
        }



    }
}