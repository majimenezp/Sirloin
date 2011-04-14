using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirloin.Domain;
using NHibernate.Linq;

namespace Sirloin.Controllers
{
    public class MenuController : ApplicationController
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CurrentMenu(int id)
        {
            List<Domain.MenuItem> elems = new List<MenuItem>();
            List<Domain.Menu> elemsSrc;
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                elemsSrc = (List<Menu>)session.Query<Domain.Menu>().Where(x => x.idparent == id).AsEnumerable().ToList();

                elems = session.Query<Domain.Menu>()
                    .Where(x => x.idparent == id)
                    .AsEnumerable<Domain.Menu>().ToList()
                    .ConvertAll<Domain.MenuItem>(x => new MenuItem()
                    {
                        data = x.MenuText,
                        state = "closed",
                        attr = new MenuAttributes() { id = x.iditem }
                    }).ToList();

            }
            //elems = MenuConversion(elemsSrc);
            return Json(elems, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult PagesNotInMenu()
        {
            List<Domain.PageNotInMenu> elemsSrc = new List<PageNotInMenu>();
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                elemsSrc = (from pg in session.Query<Domain.Page>()
                            where !(from opc in session.Query<Domain.Menu>() where opc.idpage > 0 select opc.idpage).Contains(pg.PageID) && pg.Published
                            select new Domain.PageNotInMenu() { PageID =pg.PageID , ShortID = pg.ShortID , Title =pg.Title  }).ToList();
            }
            return Json(elemsSrc, JsonRequestBehavior.AllowGet);
        }
        private List<MenuItem> MenuConversion(List<Menu> options)
        {
            MenuItem elem;
            List<Domain.MenuItem> elems = new List<MenuItem>();
            if (options.Count > 0)
            {
                foreach (Menu option in options)
                {
                    elem =new MenuItem();
                    elem.data = option.MenuText;
                    elem.attr = new MenuAttributes() { id=option.iditem};
                    elem.state = "open";
                    if (option.Children.Count > 0)
                    {
                        elem.Children =MenuConversion(option.Children.ToList());
                    }
                    else
                    {
                        elem.Children = new List<MenuItem>();
                    }
                    elems.Add(elem);
                }
            }
            return elems;
        }
       

    }
}
