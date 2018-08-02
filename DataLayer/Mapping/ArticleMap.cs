using DataLayer.Entity;
using FluentNHibernate.Mapping;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Mapping
{
    public class ArticleMap
        : ClassMap<Article>
    {
        public ArticleMap()
        {
            SetupORM();
        }

        protected virtual void SetupORM()
        {
            Table("dbo.Article");

            Id(article => article.ID);

            References(article => article.Category).Column("categoryID");

            Map(article => article.Title, "title");
            Map(article => article.Author, "author");
            Map(article => article.Summary, "summary");
            Map(article => article.PublicationDate, "publicationdate");
            Map(article => article.Body, "body");
            Map(article => article.Views, "views");
            Map(article => article.IsPublished, "ispublished");
        }
    }
}
