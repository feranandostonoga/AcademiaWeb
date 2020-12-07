using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Academia.Models;

namespace Academia.Controllers
{
    public class CarrinhoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carrinho
        public ActionResult Index()
        {
            double total = 0;

            var pessoaID = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Codigo;

            //var carrinhoAux = db.Carrinho.
            //    Include(c => c.Pessoas).
            //    Include(c => c.Produtos).ToList();
                

            var carrinho = db.Carrinho.
                Include(c => c.Pessoas).
                Include(c => c.Produtos).
                Where(c => c.Pessoa_ID == pessoaID).ToList();

            foreach (var item in carrinho)
            {
                total = item.Produtos.valor + total;
            }

            ViewData["total"] = total;

            return View(carrinho.ToList());
        }

        // GET: Carrinho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinho carrinho = db.Carrinho.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        // GET: Carrinho/Create
        public ActionResult Create()
        {
            var pessoaID = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Codigo;

            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", pessoaID);
            ViewBag.Produto_ID = new SelectList(db.Produto, "Codigo", "nome");
            return View();
        }

        // POST: Carrinho/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Pessoa_ID,Produto_ID")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                var pessoaID = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Codigo;
                carrinho.Pessoa_ID = pessoaID;

                db.Carrinho.Add(carrinho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", carrinho.Pessoa_ID);
            ViewBag.Produto_ID = new SelectList(db.Produto, "Codigo", "nome", carrinho.Produto_ID);
            return View(carrinho);
        }

        // GET: Carrinho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinho carrinho = db.Carrinho.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", carrinho.Pessoa_ID);
            ViewBag.Produto_ID = new SelectList(db.Produto, "Codigo", "nome", carrinho.Produto_ID);
            return View(carrinho);
        }

        // POST: Carrinho/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Pessoa_ID,Produto_ID")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", carrinho.Pessoa_ID);
            ViewBag.Produto_ID = new SelectList(db.Produto, "Codigo", "nome", carrinho.Produto_ID);
            return View(carrinho);
        }

        // GET: Carrinho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinho carrinho = db.Carrinho.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        // POST: Carrinho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrinho carrinho = db.Carrinho.Find(id);
            db.Carrinho.Remove(carrinho);
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
