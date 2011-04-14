using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirloin.Models
{
    public class PageModel
    {
        public string Content { get; set; }
        public string PageTittle { get; set; }

        public PageModel(Domain.Page data)
        {
            Content = data.PageContent;
            PageTittle = data.Title;
        }
    }
}