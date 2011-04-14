using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirloin.Domain
{
    public class MenuItem
    {
        public string data { get; set; }
        public string state { get; set; }
        public MenuAttributes attr { get; set; }
        public IList<MenuItem> Children { get; set; }
        public MenuItem()
        {
            Children = new List<MenuItem>();
        }

        static public implicit operator MenuItem(Menu menu)
        {
            MenuItem elem = new MenuItem() { data = menu.MenuText, state = "open", attr = new MenuAttributes() { id=menu.iditem }, Children = new List<MenuItem>() };
            foreach (Menu elem1 in menu.Children)
            {
                elem.Children.Add(new MenuItem() { data=elem1.MenuText,state="closed"});
            }
            return elem;
        }
    }
    // menu item attributes
    public class MenuAttributes
    {
        public int id { get; set; }
    }
}
