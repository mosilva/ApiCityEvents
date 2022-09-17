using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCityEvents.Core.Model
{
    public class EventReservation
    {
        //public long IdReservation { get; set; }

        //[Required(ErrorMessage = "The Id Event is Required")]
        //public long? IdEvent { get; set; }

        [Required(ErrorMessage = "The Person Name is Required", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Person Name")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "The Quantity is Required")]
        [Range(1, 9999)]
        [DisplayName("Quantity")]
        public long? Quantity { get; set; }



    }
}
