using System.ComponentModel.DataAnnotations;

namespace Shopping1.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Departamento/Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        public String Name { get; set; }

        public int CountryId { get; set; }
    }
}
