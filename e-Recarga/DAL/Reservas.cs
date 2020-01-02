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
        public DateTime Data { get; set; }  //Data.Date (dará apenas o MM/DD/YYYY)

        [Required]
        public int HoraInicioCarregamento { get; set; }

        [Required]
        public int HoraFimCarregamento { get; set; }
    }
}