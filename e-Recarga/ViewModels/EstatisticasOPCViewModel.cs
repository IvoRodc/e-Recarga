using e_Recarga.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_Recarga.ViewModels
{
    public class EstatisticasOPCViewModel
    {
        public List<MunicipioMaisUtilizados> MunicipioMaisUtilizados { get; set; }

        public List<PostosMaisUsados> PostosMaisUsados { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Lucro { get; set; }
    }
}