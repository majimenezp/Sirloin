using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirloin.Domain
{
    public class PageNotInMenu
    {
        public int PageID
        {
            get;
            set;
        }
        public string ShortID { get; set; }
        public string Title { get; set; }
    }
}
