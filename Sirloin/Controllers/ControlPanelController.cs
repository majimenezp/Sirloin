using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sirloin.Controllers
{
    public class ControlPanelController : ApplicationController
    {
        //
        // GET: /ControlPanel/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
