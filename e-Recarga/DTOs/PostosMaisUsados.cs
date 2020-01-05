using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DTOs
{
    public class PostosMaisUsados
    {
        [Display(Name = "Posto")]
        public string Nome { get; set; }

        [Display(Name = "# Reservas")]
        public int nUtilizacoes { get; set; }
    }
}