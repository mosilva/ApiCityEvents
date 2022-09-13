using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class CityEventsController : ControllerBase
    {

        public CityEvent cityEvent;

        private readonly ICityEventService _cityEventService;

        public CityEventsController(ICityEventService cityEventService)            
        {
            _cityEventService = cityEventService;
        }


        [HttpPost("/CreateNewCityEvent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CityEvent> CreateCityEvent(CityEvent cityEvent)
        {
            if (!(_cityEventService.CheckConflictCityEventInsert(cityEvent)))
            {
                return Conflict();
            }

            if (!(_cityEventService.CreateCityEvent(cityEvent))){

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(CreateCityEvent),cityEvent);

        }


        [HttpGet("/Title/{nameTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult QueryForTitle(string nameTitle)
        {
            //return Ok();

            return Ok(cityEvent);

        }


        [HttpGet("/Event/{local}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult QueryForLocalAndDate(string local, DateTime date)
        {
            //return Ok();

            return Ok(cityEvent);

        }

        [HttpGet("/Event")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult QueryForRangePriceAndDate(
              decimal inicialPrice
            , decimal finalPrice
            , DateTime date)
        {
            //return Ok();

            return Ok(cityEvent);

        }




        [HttpPut("/UpdateCityEventAllInformation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateCityEventComplete(int index)
        {
            return NoContent();
        }

        [HttpDelete("/DeletedEventNoReservations/InactiveEventWithReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityEvent> DeleteCityEvent(int index)
        {
            return Ok(cityEvent);
        }



    }
}