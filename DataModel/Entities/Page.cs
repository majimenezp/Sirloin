using System.Collections.Generic; 
using System.Text; 
using System; 


namespace Sirloin.Domain {
    
    public class Page {
        public Page() { }
        public virtual int PageID { get; set; }
        public virtual string ShortID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string PageContent { get; set; }
        public virtual System.DateTime CreationDate { get; set; }
        public virtual System.DateTime LastModifiedDate { get; set; }
        public virtual bool Published { get; set; }

        public virtual string Nombre { get; set; }

    }
}
