using System.ComponentModel.DataAnnotations;

namespace Shopping1.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        public String Name { get; set; }
        public int StateId { get; set; }
    }
}
