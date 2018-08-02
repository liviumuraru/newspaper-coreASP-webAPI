using DataLayer.Entity;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Config
{
    public static class ORMConfig
    {
        public static ISessionFactory GetSessionFactory()
        {
            if (sessionFactory != null) return sessionFactory;

            const string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";

            sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql7.ConnectionString(connectionString))
                            .Mappings(m =>
                                m.FluentMappings
                                    .AddFromAssemblyOf<Article>()
                                    )
                            .BuildSessionFactory();

            return sessionFactory;
        }

        private static ISessionFactory sessionFactory;
    }
}
