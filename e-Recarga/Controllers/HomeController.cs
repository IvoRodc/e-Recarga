using e_Recarga.DAL;
using e_Recarga.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Recarga.Controllers
{
    public class HomeController : Controller
    {
        private eRecargaDB db = new eRecargaDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ListaPostos()
        {
            List<PostoCarregamentoDTO> lista = (from a in db.Postos
                                where a.Ativo == true
                                select new PostoCarregamentoDTO
                                {
                                    IDPosto = a.Id_PostoCarregamento,
                                    Nome = a.Nome,
                                    Potencia = a.VelocidadeCarregamento,
                                    NTomadas = a.NumTomadas,
                                    Municipio = a.Municipio,
                                    Localizacao = a.Localizacao,
                                    ValorInicial = a.ValorFixoInicial,
                                    Menos30Min = a.ValorVariavelTempoMenos30Min,
                                    Mais30Min = a.ValorVariavelTempoMais30Min
                                })
                            .ToList();
            return View(lista);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}