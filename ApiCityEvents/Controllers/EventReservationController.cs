using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using ApiCityEvents.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        private readonly IEventReservationService _eventReservationService;

        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }


        [HttpPost("/CreateNewEventReservation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [ServiceFilter(typeof(LogActionFilterCheckExictsCityEventForId))]
        [Authorize]

        public ActionResult<EventReservation> CreateEventReservation(int index, EventReservation eventReservation)
        {
            if (!(_eventReservationService.CreateEventReservation(index,eventReservation)))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(CreateEventReservation), eventReservation);
        }


        [HttpPatch("/UpdateEventReservationQuantity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateCityEventStatus(int idEvent, long newQuantity, EventReservation eventReservation)
        {
            if (!(_eventReservationService.CheckIfExistsReservation(idEvent,eventReservation)))
            {
                return NotFound();
            }

            if (!(_eventReservationService.UpdateEventRespositoryQuantity(idEvent, newQuantity, eventReservation)))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }


        [HttpDelete("/DeletedEventReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteEventReservation(int idEvent,EventReservation eventReservation)
        {
            if (!(_eventReservationService.CheckIfExistsReservation(idEvent, eventReservation)))
            {
                return NotFound();
            }


            if (!(_eventReservationService.DeleteEventReservation(idEvent, eventReservation)))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpGet("/ForPersonNameAndEventTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [Authorize]
        public ActionResult ForPersonNameAndEventTitle(string personName, string eventTitle)
        {
            var listEventReservation = _eventReservationService.QueryCityEventReservation(personName, eventTitle);

            if (!(listEventReservation.Any()))
            {
                return NotFound();
            }

            return Ok(listEventReservation);

        }

    }
}
