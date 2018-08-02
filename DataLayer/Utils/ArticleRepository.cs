using DataLayer.Config;
using DataLayer.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Utils
{
    public class ArticleRepository
        : IDisposable
    {
        public ArticleRepository()
        {
            _session = ORMConfig.GetSessionFactory().OpenSession();
        }

        public ArticleRepository(ISession session)
        {
            _session = session;
        }

        private readonly ISession _session;

        public void Delete(Guid ID)
        {
            var article = Get(ID);
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(article);
                transaction.Commit();
            }
        }

        public virtual IEnumerable<Article> GetAll(DateTime? pubDate, int? categoryID, int? viewCount)
        {
            var qo = _session.QueryOver<Article>().Fetch(x => x.Category).Eager;
            var filtered = qo;

            if (pubDate.HasValue)
            {
                filtered = filtered.Where(a => a.PublicationDate == pubDate);
            }

            if (categoryID.HasValue)
            {
                filtered = filtered.Where(a => a.Category.ID == categoryID);
            }

            if (viewCount.HasValue)
            {
                filtered = filtered.Where(a => a.Views == viewCount);
            }

            return qo.List();
        }

        public virtual IEnumerable<Article> GetAllByCategory(Category category)
        {
            return _session.QueryOver<Article>()
                    .Where(article => article.Category.ID == category.ID)
                    .Fetch(x => x.Category).Eager
                    .List();
        }

        public virtual IEnumerable<Article> GetAllByViewCount(int viewCount)
        {
            return _session.QueryOver<Article>()
                    .Where(article => article.Views == viewCount)
                    .Fetch(x => x.Category).Eager
                    .List();
        }

        public virtual Article Get(Guid guid)
        {
            return _session.QueryOver<Article>().Where(article => article.ID == guid).Fetch(x => x.Category).Eager.List()[0];
        }

        public virtual void Update(Article article)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(article);
                transaction.Commit();
            }
        }

        public virtual void Create(Article article)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(article);
                transaction.Commit();
            }
        }

        public virtual void Dispose()
        {
            _session.Dispose();
        }
    }
}
