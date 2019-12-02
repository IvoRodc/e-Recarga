using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Recarga.DAL
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(25)]
        public string IBAN { get; set; }

        [Required]
        public int CapacidadeBateria { get; set; }
    }
}