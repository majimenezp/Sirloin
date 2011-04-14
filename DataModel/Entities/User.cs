using System.Collections.Generic; 
using System.Text; 
using System; 


namespace Sirloin.Domain {
    
    public class User {
        public User() { }
        public virtual int UserID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string FullName { get; set; }
    }
}
