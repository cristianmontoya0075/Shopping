﻿using System.ComponentModel.DataAnnotations;

namespace Shopping1.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }


        [Display(Name="País")]
        [Required (ErrorMessage ="El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage ="El campo {0} debe tener máximo {1} carácteres")]
        public String Name { get; set; }


    }
}
