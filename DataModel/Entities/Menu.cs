using System.Collections.Generic; 
using System.Text; 
using System; 


namespace Sirloin.Domain {
    
    public class Menu {
        public virtual int iditem { get; set; }
        public virtual string MenuText { get; set; }
        public virtual int idparent { get; set; }
        public virtual int idpage { get; set; }
        public virtual IList<Menu> Children { get; set; }
        public virtual Page ReferencePage { get; set; }
        public Menu()
        {
            Children = new List<Menu>();
        }
    }
}
