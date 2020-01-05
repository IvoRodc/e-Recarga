using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using e_Recarga.DAL;
using e_Recarga.DTOs;
using e_Recarga.ViewModels;
using Microsoft.AspNet.Identity;

namespace e_Recarga.Controllers
{
    [Authorize(Roles = "OPC")]
    public class OPCController : Controller
    {
        private eRecargaDB db = new eRecargaDB();

        // GET: OPC
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<PostoCarregamento> lista = db.Postos.Where(m => m.Id_OPC == userId).ToList();
            return View(lista);
        }

        // GET: OPC/Details/5
        public ActionResult Details(int? id)
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

        // GET: OPC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OPC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostoCarregamento postoCarregamento)
        {
            postoCarregamento.Id_OPC = User.Identity.GetUserId();
            if (postoCarregamento.ValorVariavelTempoMais30Min == 0)
                postoCarregamento.ValorVariavelTempoMais30Min = postoCarregamento.ValorVariavelTempoMenos30Min;
            ModelState.Clear();
            TryValidateModel(postoCarregamento);
            if (ModelState.IsValid)
            {
                db.Postos.Add(postoCarregamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postoCarregamento);
        }

        // GET: OPC/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: OPC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostoCarregamento postoCarregamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postoCarregamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postoCarregamento);
        }

        // GET: OPC/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: OPC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostoCarregamento postoCarregamento = db.Postos.Find(id);
            db.Postos.Remove(postoCarregamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Estatisticas()
        {
            string userId = User.Identity.GetUserId();
            EstatisticasOPCViewModel estatisticasOPCViewModel = new EstatisticasOPCViewModel();
            List<PostoCarregamento> listaPostos = db.Postos.Where(p => p.Id_OPC == userId).ToList();


            //5 Municipios com mais utilização
            List<string> listaMunicipios = db.Postos.Select(p => p.Municipio).Distinct().ToList();
            List<MunicipioMaisUtilizados> municipioMaisUtilizados = new List<MunicipioMaisUtilizados>();
            foreach(string municipio in listaMunicipios)
            {
                int nUtilizações = 0;
                foreach(PostoCarregamento p in listaPostos.Where(p => p.Municipio == municipio))
                {
                    nUtilizações += db.Reservas.Where(r => r.id_Posto == p.Id_PostoCarregamento).Count();
                }
                municipioMaisUtilizados.Add(new MunicipioMaisUtilizados { Municipio = municipio, nUtilizacoes = nUtilizações });
            }
            estatisticasOPCViewModel.MunicipioMaisUtilizados = municipioMaisUtilizados.OrderBy(m => m.nUtilizacoes).Take(5).ToList();
            
            /*estatisticasOPCViewModel.gráficoMunicipios = new Chart(600, 600)
                                    .AddTitle("5 Municipios com mais utilizações")
                                    .AddSeries("Default", chartType: "Pie", xValue: municipioMaisUtilizados, xField: "Municipio", yValues: municipioMaisUtilizados, yFields: "nUtilizacoes");*/

            //5 postos mais utilizados
            List<PostosMaisUsados> postosMaisUsados = new List<PostosMaisUsados>();
            foreach(PostoCarregamento p in listaPostos)
            {
                int nUtilizacoes = db.Reservas.Where(r => r.id_Posto == p.Id_PostoCarregamento).Count();
                postosMaisUsados.Add(new PostosMaisUsados { Nome = p.Nome, nUtilizacoes = nUtilizacoes });
            }
            estatisticasOPCViewModel.PostosMaisUsados = postosMaisUsados.OrderBy(p => p.nUtilizacoes).Take(5).ToList();

            //total pago pelos consumidores
            double total = 0;
            foreach(PostoCarregamento p in listaPostos)
            {
                total += db.Reservas.Where(r => r.id_Posto == p.Id_PostoCarregamento).Sum(r => r.CustoReserva);
            }
            estatisticasOPCViewModel.Lucro = total;

            return View(estatisticasOPCViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
