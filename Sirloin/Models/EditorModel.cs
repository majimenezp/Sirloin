using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sirloin.Domain;
namespace Sirloin.Models
{
    public class EditorModel
    {
        public EditorModel(IList<Page> pages)
        {
            PagesList = (List<Page>)pages;
        }
        public List<Sirloin.Domain.Page> PagesList { get; set; }
    }
}