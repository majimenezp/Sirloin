using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace Sirloin.Domain {
    
    
    public class UserMap : ClassMap<User> {
        
        public UserMap() {
            Not.LazyLoad();
			Table("Users");			
			Id(x => x.UserID).GeneratedBy.Identity().Column("UserID");
			Map(x => x.Username).Not.Nullable().Column("Username");
			Map(x => x.Password).Not.Nullable().Column("Password");
			Map(x => x.FullName).Not.Nullable().Column("FullName");
        }
    }
}
