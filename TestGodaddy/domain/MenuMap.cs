using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace TestGodaddy.domain
{
    
    
    public class MenuMap : ClassMap<Menu> {
        
        public MenuMap() {
            Not.LazyLoad();
			Table("Menu");            
			Id(x => x.iditem).GeneratedBy.Identity().Column("iditem");
			Map(x => x.MenuText).Not.Nullable().Column("MenuText");
			Map(x => x.idparent).Not.Nullable().Column("idparent");
			Map(x => x.idpage).Not.Nullable().Column("idpage");
            HasMany(x => x.Children).KeyColumn("idparent").NotFound.Ignore().Not.LazyLoad();
        }
    }
}
