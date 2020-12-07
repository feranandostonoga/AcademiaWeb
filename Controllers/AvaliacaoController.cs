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
    public class AvaliacaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Avaliacao
        public ActionResult Index()
        {
            //var aux2 = System.Web.HttpContext.Current.User.Identity.Name;

            var aux3 = db.Pessoa.ToList();

            var aux4 = db.Avaliacao.ToList();

            var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();


            var avaliacao = db.Avaliacao.Include(a => a.Pessoa).ToList();

            //Aluno
            IEnumerable<Avaliacao> aux;
            aux = db.Avaliacao
                            .Include(a => a.Pessoa)
                            .Where(a => a.Pessoa.Email == System.Web.HttpContext.Current.User.Identity.Name).ToList();
            
            if (objPessoa.TipoPessoa.ToString() != "Aluno")
            {
                //Professor
                aux = db.Avaliacao
                                .Include(a => a.Pessoa)
                                .Where(a => a.Professor == System.Web.HttpContext.Current.User.Identity.Name).ToList();

            }//db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            return View(aux);
        }

        // GET: Avaliacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // GET: Avaliacao/Create
        public ActionResult Create()
        {
            var model = new Avaliacao();
            model.dtCriado = DateTime.Now;

            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email");
            return View(model);
        }

        // POST: Avaliacao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,StatusAvaliacao,Pessoa_ID,dtCriado,dtMarcado")] Avaliacao avaliacao)
        {
            var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                avaliacao.Professor = objPessoa.Email;
                db.Avaliacao.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", avaliacao.Pessoa_ID);
            return View(avaliacao);
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", avaliacao.Pessoa_ID);
            return View(avaliacao);
        }

        // POST: Avaliacao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,StatusAvaliacao,Pessoa_ID,Professor,altura,peso,dtCriado,dtMarcado")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                //var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
                //avaliacao.Pessoa_ID ;
                //Insere Status CONCLUIDA
                avaliacao.StatusAvaliacao = "Concluida";
                //Calcula IMC
                if (Convert.ToDecimal(avaliacao.altura) != 0 && Convert.ToDecimal(avaliacao.peso) != 0) 
                {
                    avaliacao.resultadoIMC = CalculaIMC(Convert.ToDecimal(avaliacao.altura), Convert.ToDecimal(avaliacao.peso));
                }
                db.Entry(avaliacao).State = EntityState.Modified;


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pessoa_ID = new SelectList(db.Pessoa, "Codigo", "Email", avaliacao.Pessoa_ID);
            return View(avaliacao);
        }

        private string CalculaIMC(decimal altura, decimal peso)
        {
            double resultado;
            string res = string.Empty;

            //Multiplica ALTURA X ALTURA
            altura = altura * altura;

            resultado = Convert.ToDouble((peso / altura));

            //Tabela IMC
            if (resultado < 18.5) 
            {
                res = "Abaixo do peso";
            }
            else if (resultado > 18.5  && resultado < 24.9) 
            {
                res = "Peso normal";
            }
            else if (resultado > 25 && resultado < 29.9) 
            {
                res = "Sobrepeso";
            }
            else if (resultado > 30 && resultado < 34.9 ) 
            {
                res = "Obesidade grau 1";
            }
            else if (resultado > 35 && resultado < 39.9)
            {
                res = "Obesidade grau 2";
            }
            else {
                res = "	Obesidade grau 3";
            };


                return res;
        }

        // GET: Avaliacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacao.Find(id);
            db.Avaliacao.Remove(avaliacao);
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
