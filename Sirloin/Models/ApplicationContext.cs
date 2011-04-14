using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;

namespace Sirloin.Models
{
    public class ApplicationContext
    {
        public IEnumerable<Domain.Menu> ApplicationMenu
        {
            get;
            set;
        }
        public ApplicationContext()
        {
            using (var session = DomainAccess.Instance.CurrentSession.OpenSession())
            {
               
                ApplicationMenu = session.Query<Domain.Menu>().Where(x=>x.idparent ==0).AsEnumerable<Domain.Menu>().ToList();
            }
        }
    }
}