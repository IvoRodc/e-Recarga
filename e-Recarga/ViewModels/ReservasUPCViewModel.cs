using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Recarga.ViewModels
{
    public class ReservasUPCViewModel
    {
        [Display(AutoGenerateField = false)]
        [HiddenInput(DisplayValue = false)]
        public int id_posto { get; set; }

        [Display(Name = "Posto")]
        public string NomePosto { get; set; }

        [Display(Name = "Inicio carregamento")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime Inicio { get; set; }

        [Display(Name = "Fim carregamento")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime Fim { get; set; }

        [Display(Name = "Duração carregamento (min)")]
        public int Duracao { get; set; }

        [Display(Name = "Custo total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Custo { get; set; }
    }
}