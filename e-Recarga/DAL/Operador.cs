using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DAL
{
    public class Operador
    {
        [Key]
        public int IdOperador { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<PontoCarregamento> PontosCarregamento { get; set; }
    }
}