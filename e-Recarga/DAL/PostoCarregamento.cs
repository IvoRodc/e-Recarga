using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Recarga.DAL
{
    [Table("PostoCarregamento")]
    public class PostoCarregamento // Onde as estações se encontram
    {
        [Key]
        public int Id_PostoCarregamento { get; set; }

        [Required]
        [StringLength(128)]
        [Display(AutoGenerateField = false)]
        [HiddenInput(DisplayValue = false)]
        public string Id_OPC { get; set; }

        [Required]
        [StringLength(9)]
        [MinLength(9)]
        [MaxLength(9)]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Potência")]
        public double VelocidadeCarregamento { get; set; } //kW

        [Required]
        [DisplayName("# Tomadas")]
        public int NumTomadas { get; set; }

        [Required]
        [StringLength(20)]
        public string Municipio { get; set; }

        [Required]
        [StringLength(200)]
        public string Localizacao { get; set; }

        [Required]
        [DisplayName("Valor fixo")]
        public double ValorFixoInicial { get; set; }

        [Required]
        [DisplayName("€/min (<30 minutos)")]
        public double ValorVariavelTempoMenos30Min { get; set; }  // ( € / minuto ) < 30 min

        [Required]
        [DisplayName("€/min (>30 minutos)")]
        public double ValorVariavelTempoMais30Min { get; set; } // ( € / minuto ) > 30 min

        
        [Required]
        public bool Ativo { get; set; }  //Se posto de carregamento está ativo

        public ICollection <Reservas> Reservas { get; set; }
    }
}