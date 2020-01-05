using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DTOs
{
    public class MunicipioMaisUtilizados
    {
        [Display(Name = "Município")]
        public string Municipio { get; set; }

        [Display(Name = "# Reservas")]
        public int nUtilizacoes { get; set; }
    }
}