using System.ComponentModel.DataAnnotations;

namespace Shopping1.Data.Entities
{
    public class State
    {
        public int Id { get; set; }


        [Display(Name = "Departamento/Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        public String Name { get; set; }
        public  Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
