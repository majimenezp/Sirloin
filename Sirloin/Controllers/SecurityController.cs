using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirloin.Models;
using Sirloin.Domain;
using NHibernate.Linq;
using NHibernate;
using System.Web.Routing;
using Sirloin.Security;

namespace Sirloin.Controllers
{
    public class SecurityController : ApplicationController
    {
        //
        // GET: /Security/
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            //if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private bool ValidateUser(string username, string password)
        {
            Sirloin.Domain.User result;
            Security.PasswordManager pmanager = new Security.PasswordManager();
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                result = session.Query<Domain.User>().FirstOrDefault<Domain.User>(x => x.Username.ToLower() == username.ToLower());
            }
            if (result != null)
            {
                //user was found
                return pmanager.IsValidPassword(username, password, result.Password);
            }
            else
            {
                return false;
            }
        }

        private void CreateAdmin()
        {
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
                Security.PasswordManager pwdmng = new Security.PasswordManager();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Domain.User adminusr = new Domain.User();
                    adminusr.UserID = 0;
                    adminusr.Username = "majimenezp";
                    adminusr.FullName = "Miguel Jimenez";
                    adminusr.Password = pwdmng.HashPassword(adminusr.Username, "123456789");
                    session.Save(adminusr);
                    transaction.Commit();
                }

            }
        }
    }
}
