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
        [MinLength(9, ErrorMessage ="O nome do posto tem de ter 9 caracteres!")]
        [MaxLength(9, ErrorMessage ="O nome do posto não pode ter mais do que 9 caracteres!")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Potência")]
        [DisplayFormat(DataFormatString = "{0:F} kW", ApplyFormatInEditMode = false)]
        [Range(1.00, double.MaxValue, ErrorMessage = "A potencia tem de ser superior a 0 kW")]
        public double VelocidadeCarregamento { get; set; } //kW

        [Required]
        [DisplayName("# Tomadas")]
        [Range(1, double.MaxValue, ErrorMessage = "O número de tomadas tem de ser igual ou superior a 1")]
        public int NumTomadas { get; set; }

        [Required]
        [StringLength(20)]
        public string Municipio { get; set; }

        [Required]
        [StringLength(200)]
        public string Localizacao { get; set; }

        [Required]
        [DisplayName("Valor fixo")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Range(0.00, double.MaxValue, ErrorMessage = "O valor não pode ser negativo")]
        [DataType("double")]
        public double ValorFixoInicial { get; set; }

        [Required]
        [DisplayName("€/min (<30 minutos)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Range(0.00, double.MaxValue, ErrorMessage = "O valor não pode ser negativo")]
        public double ValorVariavelTempoMenos30Min { get; set; }  // ( € / minuto ) < 30 min

        [Required]
        [DisplayName("€/min (>30 minutos)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Range(0.00, double.MaxValue, ErrorMessage = "O custo não pode ser negativo")]
        public double ValorVariavelTempoMais30Min { get; set; } // ( € / minuto ) > 30 min

        
        [Required]
        public bool Ativo { get; set; }  //Se posto de carregamento está ativo

        public ICollection <Reservas> Reservas { get; set; }
    }
}