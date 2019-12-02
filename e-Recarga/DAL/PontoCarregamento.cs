using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DAL
{
    public class PontoCarregamento // Onde as estações se encontram
    {
        [Key]
        public int IdPontoCarregamento { get; set; }

        [Required]
        [StringLength(9)]
        [MinLength(9)]
        [MaxLength(9)]
        public string Nome { get; set; }

        [Required]
        public int VelocidadeCarregamento { get; set; } //kW

        [Required]
        [StringLength(20)]
        public string Municipio { get; set; }

        [Required]
        [StringLength(200)]
        public string Localizacao { get; set; }

        [Required]
        public float ValorFixoInicial { get; set; }

        [Required]
        public float ValorVariavelMinutoPorMeiaHora { get; set; }

        [Required]
        public float ValorVariavelMinutoPorMaisTempo { get; set; }

        [Required]
        public float ValorVariavelKWh { get; set; }

        [Required]
        public int IdOperador { get; set; }
    }
}