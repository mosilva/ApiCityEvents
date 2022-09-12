using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCityEvents.Core.Model
{
    public class CityEvent
    {
        //public long idEvent { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "The Date Hour Event is Required")]
        [Column(TypeName = "datetime")]
        [DisplayName("Date Hour Event")]
        public string DateHourEvent { get; set; }

        [Required(ErrorMessage = "The Local Event is Required")]
        [StringLength(100, MinimumLength = 2)]
        [DisplayName("Local Event")]
        public string Local { get; set; }

        [StringLength(200, MinimumLength = 5)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Status is Reqired")]
        [DisplayName("Status")]
        public bool Status { get; set; }




    }
}
