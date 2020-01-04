using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Recarga.DTOs
{
    public class ReservaDTO
    {
        [Display(AutoGenerateField = false)]
        [HiddenInput(DisplayValue = false)]
        [Required]
        public string IDUser { get; set; }

        [Display(AutoGenerateField = false)]
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int IDPosto { get; set; }

        [Required]
        public string NomePosto { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Fim { get; set; }

        [Display(AutoGenerateField = true)]
        public int TempoCarregamento { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double EstimativaPreco { get; set; }
    }
}