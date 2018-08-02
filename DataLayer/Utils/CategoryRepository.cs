using DataLayer.Config;
using DataLayer.Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Utils
{
    public class CategoryRepository
        : IDisposable
    {
        public CategoryRepository()
        {
            _session = ORMConfig.GetSessionFactory().OpenSession();
        }

        public CategoryRepository(ISession session)
        {
            _session = session;  
        }

        private readonly ISession _session;

        public Category Get(int ID)
        {
            return _session.Load<Category>(ID);
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
