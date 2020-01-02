using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using e_Recarga.DAL;
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
        public ActionResult Create([Bind(Include = "Id_PostoCarregamento,Nome,VelocidadeCarregamento,NumTomadas,Municipio,Localizacao,ValorFixoInicial,ValorVariavelTempoMenos30Min,ValorVariavelTempoMais30Min,Ativo")] PostoCarregamento postoCarregamento)
        {
            postoCarregamento.Id_OPC = User.Identity.GetUserId();
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
        public ActionResult Edit([Bind(Include = "Id_PostoCarregamento,Id_OPC,Nome,VelocidadeCarregamento,NumTomadas,Municipio,Localizacao,ValorFixoInicial,ValorVariavelTempoMenos30Min,ValorVariavelTempoMais30Min,Ativo")] PostoCarregamento postoCarregamento)
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
