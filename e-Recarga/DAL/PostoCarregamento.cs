using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DAL
{
    public class PostoCarregamento // Onde as estações se encontram
    {
        [Key]
        public int Id_PostoCarregamento { get; set; }

        [Required]
        public int Id_OPC { get; set; }

        [Required]
        [StringLength(9)]
        [MinLength(9)]
        [MaxLength(9)]
        public string Nome { get; set; }

        [Required]
        public int VelocidadeCarregamento { get; set; } //kW

        [Required]
        public int NumTomadas { get; set; }

        [Required]
        [StringLength(20)]
        public string Municipio { get; set; }

        [Required]
        [StringLength(200)]
        public string Localizacao { get; set; }

        [Required]
        public double ValorFixoInicial { get; set; }

        [Required]
        public double ValorVariavelTempoMenos30Min { get; set; }  // ( € / minuto ) < 30 min

        [Required]
        public double ValorVariavelTempoMais30Min { get; set; } // ( € / minuto ) > 30 min

        
        [Required]
        public bool Ativo { get; set; }  //Se posto de carregamento está ativo
    }
}