using Academia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Academia.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Principal()
        {
            var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            //if (objPessoa != null)
            //{

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name.Equals("appSettings"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                        if (node.Attributes[0].Value.Equals("TipoUsuario"))
                        {
                            if (objPessoa != null)
                            {
                                node.Attributes[1].Value = objPessoa.TipoPessoa.ToString();
                            }
                            else {
                                node.Attributes[1].Value = string.Empty;
                            }
                            }
                        }
                    }
                }
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("appSettings");


            //}

            return View();
        }

        public PartialViewResult BuscaClientes(string nome)
        {
            var result = db.Pessoa
                                   .Where(c => c.Nome.Contains(nome)).ToList();
            return PartialView("_GridView", result);

        }

        public ActionResult Index()
        {
               var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            if (objPessoa != null)
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name.Equals("appSettings"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("TipoUsuario"))
                            {
                                node.Attributes[1].Value = objPessoa.TipoPessoa.ToString();
                            }
                        }
                    }
                }
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("appSettings");

                
            }
            var res = db.Pessoa.ToList();
            return View(res);
        }
            // GET: Clientes
        //    public ActionResult Index()
        //{
        //    var usuarios = db.Pessoa.ToList();

        //    var x = db.Users.ToList();

        //    // var list = db.Pessoa.ToList();

        //    var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();

        //    IList<gridUsuarioDTO> lstobjGridUsuarios = new List<gridUsuarioDTO> {};
        //    IEnumerable<gridUsuarioDTO> lstCont;
        //    int cont = 0;
        //    foreach (var item in usuarios)
        //    {
        //        var objGridUsuarios = new gridUsuarioDTO();
        //        objGridUsuarios.Codigo = item.Codigo;
        //        objGridUsuarios.Nome = item.Nome;
        //        objGridUsuarios.Email = item.Email;
        //        objGridUsuarios.TipoPessoa = item.TipoPessoa;

        //        lstobjGridUsuarios.Add(objGridUsuarios);
        //    }
            
        //    lstCont = lstobjGridUsuarios.AsEnumerable();
        //    if (objPessoa != null)
        //    {

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        //        foreach (XmlElement element in xmlDoc.DocumentElement)
        //        {
        //            if (element.Name.Equals("appSettings"))
        //            {
        //                foreach (XmlNode node in element.ChildNodes)
        //                {
        //                    if (node.Attributes[0].Value.Equals("TipoUsuario"))
        //                    {
        //                        node.Attributes[1].Value = objPessoa.TipoPessoa.ToString();
        //                    }
        //                }
        //            }
        //        }
        //        xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        //        ConfigurationManager.RefreshSection("appSettings");
        //    }
        //    return View(lstCont);
        //}

        public PartialViewResult BuscaUsuarios(string nome)
        {

            IEnumerable<Pessoa> result;
            if (nome != "")
            {
                result = db.Pessoa
                                       .Where(c => c.Nome.Contains(nome));
            }
            else {
                result = db.Pessoa.ToList();
            }

            IList<gridUsuarioDTO> lstobjGridUsuarios = new List<gridUsuarioDTO> { };
            IEnumerable<gridUsuarioDTO> lstCont;
            foreach (var item in result)
            {
                var objGridUsuarios = new gridUsuarioDTO();
                objGridUsuarios.Codigo = item.Codigo;
                objGridUsuarios.Nome = item.Nome;
                objGridUsuarios.Email = item.Email;
                objGridUsuarios.TipoPessoa = item.TipoPessoa;

                lstobjGridUsuarios.Add(objGridUsuarios);
            }

            lstCont = lstobjGridUsuarios.AsEnumerable();


            return PartialView("_GridView", result);

        }

        public ActionResult IndexFiltrado(string text)
        {
            var clientes = db.Pessoa
                                 .Where(c => c.Nome.Contains(text));
            return View(clientes.ToList());
        }


        //public ActionResult Index()
        //{
        //    var x = db.Users.ToList();

        //   // var list = db.Pessoa.ToList();

        //    var objPessoa = db.Pessoa.Where(a => a.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();

        //    if (objPessoa != null) {

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        //        foreach (XmlElement element in xmlDoc.DocumentElement)
        //        {
        //            if (element.Name.Equals("appSettings"))
        //            {
        //                foreach (XmlNode node in element.ChildNodes)
        //                {
        //                    if (node.Attributes[0].Value.Equals("TipoUsuario"))
        //                    {
        //                        node.Attributes[1].Value = objPessoa.TipoPessoa.ToString();
        //                    }
        //                }
        //            }
        //        }
        //        xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        //        ConfigurationManager.RefreshSection("appSettings");
        //    }
        //    return View();
        //}



        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}