using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGodaddy.domain
{
    public class Menu
    {
        public virtual int iditem { get; set; }
        public virtual string MenuText { get; set; }
        public virtual int idparent { get; set; }
        public virtual int idpage { get; set; }
        public virtual IList<Menu> Children { get; set; }
        public Menu()
        {
            Children = new List<Menu>();
        }
    }
}