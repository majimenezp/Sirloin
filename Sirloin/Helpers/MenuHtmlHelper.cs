using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirloin.Domain;
using System.Text;

namespace Sirloin.Helpers
{
    public static class MenuHtmlHelper
    {
        public static string MenuTree(this HtmlHelper html, IEnumerable<Menu> options)
        {
            string output = string.Empty;
            string pagina = string.Empty;
            
            if (options.Count() > 0)
            {
                output += "<ul id=\"nav\">";
                foreach (Menu option in options)
                {
                    if (option.idpage == 0)
                    {
                        pagina = "#";
                    }
                    else
                    {                       
                        pagina = VirtualPathUtility.ToAbsolute("~/" + option.ReferencePage.ShortID);
                    }
                    output += "<li>";
                    output += "<a href=\"" + pagina + "\">" + option.MenuText + "</a>";
                    output += MenuSubTree(option.Children);
                    output += "</li>";
                }
                output += "</ul>";
            }
            return output;
        }
        private static string MenuSubTree(IEnumerable<Menu> options)
        {
            string output = string.Empty;
            string pagina = string.Empty;
            if (options.Count() > 0)
            {
                output += "<ul>";
                foreach (Menu option in options)
                {
                    if (option.idpage == 0)
                    {
                        pagina = "#";
                    }
                    else
                    {
                        pagina = VirtualPathUtility.ToAbsolute("~/" + option.ReferencePage.ShortID);
                    }
                    output += "<li>";
                    output += "<a href=\"" + pagina + "\">" + option.MenuText + "</a>";
                    output += MenuSubTree(option.Children);
                    output += "</li>";
                }
                output += "</ul>";
            }
            return output;
        }


    }
}