using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CityEvent> CreateCityEvent(CityEvent cityEvent)
        {
            if (!(_cityEventService.CheckExictsCityEvent(cityEvent)))
            {
                return Conflict();
            }

            if (!(_cityEventService.CreateCityEvent(cityEvent))){

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(CreateCityEvent),cityEvent);

        }

        [HttpPut("/UpdateCityEventAllInformation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateCityEventComplete(int index, CityEvent cityEvent)
        {
            if (_cityEventService.CheckExictsCityEvent(index))
            {
                return NotFound();
            }

           if(!(_cityEventService.UpdateCityEvent(index, cityEvent)))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpPatch("/UpdateCityEventStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult UpdateCityEventStatus(int index, bool status)
        {
            if (_cityEventService.CheckExictsCityEvent(index))
            {
                return NotFound();
            }

            if (!(_cityEventService.UpdateCityEvent(index, status)))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpDelete("/DeletedEventNoReservations/InactiveEventWithReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCityEvent(int index)
        {
            if (_cityEventService.CheckExictsCityEvent(index))
            {
                return NotFound();
            }

            if (_cityEventService.CheckExictsReservationForCityEvent(index))
            {
                _cityEventService.UpdateCityEvent(index, false);
                return NoContent();
            }

            if (!(_cityEventService.DeleteCityEvent(index)))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpGet("/Title/{nameTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CityEvent>> QueryForTitle(string nameTitle)
        {
            var listCityEvent = _cityEventService.SelectCityEvent(nameTitle);

            if (!(listCityEvent.Any()))
            {
                return NotFound();
            }

            return Ok(listCityEvent);

        }

        [HttpGet("/ForLocalAndDateFormatdd/MM/yyyy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult QueryForLocalAndDate(string local, string date)
        {
            var listCityEvent = _cityEventService.SelectCityEvent(local, date);

            if (!(listCityEvent.Any()))
            {
                return NotFound();
            }

            return Ok(listCityEvent);

        }

        [HttpGet("/ForRangePriceAndDateFormatdd/MM/yyyy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult QueryForRangePriceAndDate(
              decimal inicialPrice
            , decimal finalPrice
            , string date)
        {
            var listCityEvent = _cityEventService.SelectCityEvent(inicialPrice, finalPrice, date);

            if (!(listCityEvent.Any()))
            {
                return NotFound();
            }

            return Ok(listCityEvent);

        }
    }
}