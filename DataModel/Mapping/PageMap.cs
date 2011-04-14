using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace Sirloin.Domain {
    
    
    public class PageMap : ClassMap<Page> {
        
        public PageMap() {
            Not.LazyLoad();
			Table("Pages");            
			Id(x => x.PageID).GeneratedBy.Identity().Column("PageID");
			Map(x => x.ShortID).Not.Nullable().Column("ShortID");
			Map(x => x.Title).Not.Nullable().Column("Title");
			Map(x => x.Description).Not.Nullable().Column("Description");
			Map(x => x.PageContent).Not.Nullable().Column("PageContent");
			Map(x => x.CreationDate).Not.Nullable().Column("CreationDate");
			Map(x => x.LastModifiedDate).Not.Nullable().Column("LastModifiedDate");
			Map(x => x.Published).Not.Nullable().Column("Published");
         
        }
    }
}
