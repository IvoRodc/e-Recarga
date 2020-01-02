using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Recarga.DAL
{
    public class Reservas
    {
        [Key]
        public int id_Reserva { get; set; }
        
        [Required]
        [StringLength(128)]
        [Display(AutoGenerateField = false)]
        [HiddenInput(DisplayValue = false)]
        public string id_Cliente { get; set; }


        [Required]
        [Display(Name = "Inicio do carregamento")]
        public DateTime InicioCarregamento { get; set; }

        [Required]
        [Display(Name = "Fim do carregamento")]
        public DateTime FimCarregamento { get; set; }
    }
}