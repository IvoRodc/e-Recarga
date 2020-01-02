using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Recarga.DTOs
{
    public class PostoCarregamentoDTO
    {
        public int IDPosto { get; set; }
        public string Nome { get; set; }
        public double Potencia { get; set; }
        public int NTomadas { get; set; }
        public string Municipio { get; set; }
        public string Localizacao { get; set; }
        public double ValorInicial { get; set; }
        public double Menos30Min { get; set; }
        public double Mais30Min { get; set; }
    }
}