using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirloin.Models
{
    public class EditModel
    {
        public Domain.Page PagetoEdit { get; set; }

        public EditModel()
        {
            PagetoEdit = new Domain.Page();
        }
        public EditModel(Domain.Page result)
        {
            // TODO: Complete member initialization
            this.PagetoEdit = result;
        }

    }
}