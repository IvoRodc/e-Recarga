using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DTOs
{
    public class PostoCarregamentoDTO
    {
        public int IDPosto { get; set; }
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:F} kW", ApplyFormatInEditMode = false)]
        public double Potencia { get; set; }
        public int NTomadas { get; set; }
        public string Municipio { get; set; }
        public string Localizacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double ValorInicial { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Menos30Min { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Mais30Min { get; set; }
    }
}