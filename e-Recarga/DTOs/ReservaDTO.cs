using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Recarga.DTOs
{
    public class ReservaDTO
    {
        public string IDUser { get; set; }
        public int IDPosto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}