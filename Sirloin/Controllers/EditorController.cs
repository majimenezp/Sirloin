using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirloin.Domain;
using NHibernate.Linq;
using Sirloin.Models;
using NHibernate;

namespace Sirloin.Controllers
{
    public class EditorController : ApplicationController
    {
        //
        // GET: /Editor/
        [Authorize]
        public ActionResult Index()
        {
            Sirloin.Models.EditorModel model;
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                var lista = session.CreateCriteria<Page>().List<Page>();
                //using (var transaction = session.BeginTransaction())
                //{
                //    var pagina1 = new Page
                //    {
                //        ShortID = "test001",
                //        CreationDate = DateTime.Now,
                //        Description = "prueba de pagina",
                //        LastModifiedDate = DateTime.Now,
                //        PageContent = "<div>prueba prueba <p>dato dato dato</p></div>",
                //        Title = "titulo",
                //        PageID = 0
                //    };
                //    session.SaveOrUpdate(pagina1);
                //    transaction.Commit();
                //}
                model=new Models.EditorModel(lista);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Page result;
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                if (id>0)
                {
                    result = session.Query<Page>().FirstOrDefault<Page>(x => x.PageID == id);
                }
                else
                {
                    result = new Page();
                }
            }
            EditModel model = new EditModel(result);
            return View(model);
        }

        [Authorize]
        [HttpPost,ValidateInput(false)]
        public ActionResult Edit(EditModel model)
        {
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    model.PagetoEdit.LastModifiedDate = DateTime.Now;
                    session.Update(model.PagetoEdit);
                    transaction.Commit();
                }
                
            }
            return View();
        }
    }
}
