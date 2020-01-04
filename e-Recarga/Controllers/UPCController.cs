using e_Recarga.DAL;
using e_Recarga.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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

        public ActionResult Reservar(int id)
        {
            ReservaDTO reserva = new ReservaDTO
            {
                IDUser = User.Identity.GetUserId(),
                IDPosto = id,
                NomePosto = db.Postos.Find(id).Nome,
                Inicio = DateTime.Now,
                Fim = DateTime.Now.AddHours(1)
            };
            return View(reserva);
        }

        [HttpPost]
        public ActionResult Reservar(ReservaDTO reservaDTO)
        {
            if (reservaDTO.Fim.CompareTo(reservaDTO.Inicio) > 0)
            {
                reservaDTO.TempoCarregamento = (int)((reservaDTO.Fim - reservaDTO.Inicio).TotalMinutes);

                double valorFixo = db.Postos.Find(reservaDTO.IDPosto).ValorFixoInicial;
                double valorInicial = db.Postos.Find(reservaDTO.IDPosto).ValorVariavelTempoMenos30Min;
                double valorDepois = db.Postos.Find(reservaDTO.IDPosto).ValorVariavelTempoMais30Min;

                if (reservaDTO.TempoCarregamento > 30)
                {
                    reservaDTO.EstimativaPreco = valorFixo + (30 * valorInicial) + ((reservaDTO.TempoCarregamento - 30) * valorDepois);
                }
                else
                {
                    reservaDTO.EstimativaPreco = valorFixo + (reservaDTO.TempoCarregamento * valorInicial);
                }   
            }

            Reservas reserva = new Reservas
            {
                InicioCarregamento = reservaDTO.Inicio,
                FimCarregamento = reservaDTO.Fim,
                id_Cliente = reservaDTO.IDUser,
                id_Posto = reservaDTO.IDPosto
            };
            db.Reservas.Add(reserva);
            db.SaveChanges();
            return View(reservaDTO);
        }

    }
}