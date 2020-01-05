using e_Recarga.DAL;
using e_Recarga.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using e_Recarga.ViewModels;

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

        public ActionResult Detalhes2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostoCarregamento postoCarregamento = db.Postos.Find(id);
            if (postoCarregamento == null)
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
                int nTomadasPosto = db.Postos.Find(reservaDTO.IDPosto).NumTomadas;

                int nReservasSimultaneo = db.Reservas.Where(r => r.InicioCarregamento < reservaDTO.Inicio && r.FimCarregamento > reservaDTO.Inicio).Count();

                if (nTomadasPosto > nReservasSimultaneo)
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

                    Reservas reserva = new Reservas
                    {
                        InicioCarregamento = reservaDTO.Inicio,
                        FimCarregamento = reservaDTO.Fim,
                        id_Cliente = reservaDTO.IDUser,
                        id_Posto = reservaDTO.IDPosto,
                        CustoReserva = reservaDTO.EstimativaPreco
                    };

                    db.Reservas.Add(reserva);
                    db.SaveChanges();
                    return RedirectToAction("ListaReservas");
                }
            }
            reservaDTO.erro = true;
            return View(reservaDTO);
        }

        public ActionResult ListaReservas()
        {
            string id_user = User.Identity.GetUserId();
            List<Reservas> listaDB = db.Reservas.Where(r => r.id_Cliente == id_user).OrderByDescending(r => r.InicioCarregamento).ToList();

            List<ReservasUPCViewModel> listaReservas = new List<ReservasUPCViewModel>();

            foreach(Reservas item in listaDB)
            {
                PostoCarregamento p = db.Postos.Find(item.id_Posto);

                ReservasUPCViewModel aux = new ReservasUPCViewModel
                {
                    id_posto = item.id_Posto,
                    NomePosto = p.Nome,
                    Inicio = item.InicioCarregamento,
                    Fim = item.FimCarregamento,
                    Duracao = (int)(item.FimCarregamento - item.InicioCarregamento).TotalMinutes,
                    Custo = item.CustoReserva
                };
                listaReservas.Add(aux);
            }

            return View(listaReservas);
        }

    }
}