using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using TestGodaddy.domain;
using NHibernate.Linq;

namespace TestGodaddy.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            var cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();
            var session = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(x => x.FromConnectionStringWithKey("Database"))
                .DoNot.UseReflectionOptimizer())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Menu>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildSessionFactory();
            using (var sesion = session.OpenSession())
            {
                var datos=sesion.Query<domain.Menu>().Where(x => x.idparent == 0).ToList<domain.Menu>();
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
