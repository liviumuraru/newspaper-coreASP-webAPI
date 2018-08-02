using DataLayer.Entity;
using DataLayer.Utils;
using Services.Abstract.Insertion;
using Services.Abstract.Modification;
using Services.Abstract.Removal;
using Services.Abstract.Retrieval;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ArticleServices
{
    public class ArticleService
        : IRetrieverService<Article, Guid>
        , IRemovalService<Guid>
        , IInsertionService<Article>
        , IModificationService<Article>
    {
        public ArticleService(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private readonly ArticleRepository _articleRepository;

        public virtual IEnumerable<Article> GetAll(object p1, object p2, object p3)
        {
            return _articleRepository.GetAll((DateTime?)p1, (int?)p2, (int?)p3);
        }

        public virtual Article GetByID(Guid id)
        {
            return _articleRepository.Get(id);
        }

        public virtual void Remove(Guid id)
        {
            _articleRepository.Delete(id);
        }

        public virtual void Insert(Article article)
        {
            _articleRepository.Create(article);
        }

        public virtual void Update(Article article)
        {
            _articleRepository.Update(article);
        }
    }
}
