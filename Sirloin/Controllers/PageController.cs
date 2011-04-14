using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirloin.Domain;
using NHibernate.Linq;

namespace Sirloin.Controllers
{
    public class PageController : ApplicationController
    {
        //
        // GET: /Page/

        public ActionResult Show(string pageid)
        {
            Page result;
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                if (!string.IsNullOrEmpty(pageid))
                {
                    result = session.Query<Page>().FirstOrDefault<Page>(x => x.ShortID == pageid);
                }
                else
                {
                    result = session.Query<Page>().FirstOrDefault();
                }
            }
            Sirloin.Models.PageModel modelo = new Models.PageModel(result);
            return View(modelo);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
