using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sirloin.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Sirloin
{
    public sealed class DomainAccess
    {
        static readonly DomainAccess instance = new DomainAccess();
        ISessionFactory session;
        static DomainAccess()
        {
        }
        DomainAccess()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();
            session = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(x => x.FromConnectionStringWithKey("Database"))
                .DoNot.UseReflectionOptimizer())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Page>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildSessionFactory();
        }

        public static DomainAccess Instance
        {
            get
            {
                return instance;
            }
        }
        public ISessionFactory CurrentSession
        {
            get
            {
                return session;
            }
        }
    }
}