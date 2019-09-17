﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TestNHibernate.Mapping;

namespace TestNHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var connectionString = String.Empty;
                    //var connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"];
                    //if (connectionStringSettings != null)
                    //{
                    //    connectionString = connectionStringSettings.ConnectionString;
                    //}
                    var cfgi = new StoreConfiguration();
                    var fluentConfiguration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(@"Data Source=.;Initial Catalog=Employee;User ID=sa;Password=sa123")
                            .ShowSql()
                        );
                    var configuration = fluentConfiguration.Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<A>(cfgi).
                        UseOverridesFromAssemblyOf<AMapping>()));
                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
                        {
                            new SchemaUpdate(cfg).Execute(false, true);
                            new SchemaExport(cfg)
                                .Create(false, false);
                        })
                        .BuildSessionFactory();
                    _sessionFactory = buildSessionFactory;
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
