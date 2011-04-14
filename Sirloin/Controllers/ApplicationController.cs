using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sirloin.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/
        private Models.ApplicationContext _datacontext=new Models.ApplicationContext();
        public Models.ApplicationContext DataContext
        {
            get
            {
                return _datacontext;
            }
        }
        public ApplicationController()
        {
            ViewData["MenuData"] = DataContext.ApplicationMenu;
        }

    }
}
