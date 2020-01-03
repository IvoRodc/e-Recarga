using e_Recarga.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace e_Recarga.Controllers
{
    [Authorize(Roles = "UPC")]
    public class UPCController : Controller
    {
        private eRecargaDB db = new eRecargaDB();
        public ActionResult Index()
        {
            List<PostoCarregamento> lista = db.Postos.Where(p => p.Ativo == true).ToList();
            return View(lista);
        }

        public ActionResult Detalhes(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostoCarregamento postoCarregamento = db.Postos.Find(id);
            if(postoCarregamento == null)
            {
                return HttpNotFound();
            }
            return View(postoCarregamento);
        }

        public ActionResult Reservar()
        {
            return View();
        }
    }
}