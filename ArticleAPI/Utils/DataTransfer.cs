using ArticleAPI.Controllers;
using ArticleAPI.Models;
using DataLayer.Entity;
using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleAPI.Utils
{
    public static class DataTransfer
    {
        public static void ModifyArticle(Article article, ArticleModificationData data)
        {
            article.PublicationDate = data.PublicationDate;
            article.Summary = data.Summary;
            article.Title = data.Title;
            article.Views = data.Views;
            article.Author = data.Author;
            article.IsPublished = data.IsPublished;
            article.Body = data.Body;

            
        }

        public static void ModifyArticle(Article article, ArticleInsertionData data)
        {
            article.PublicationDate = data.PublicationDate;
            article.Summary = data.Summary;
            article.Title = data.Title;
            article.Views = data.Views;
            article.Author = data.Author;
            article.IsPublished = data.IsPublished;
            article.Category = new CategoryRepository().Get(data.CategoryID);
            article.Body = data.Body;

            //if (article.Title == null || article.Title.Count() == 0
            //    || article.Author == null || article.Author.Count() == 0
            //    || article.Summary == null || article.Summary.Count() == 0)
            //    throw new InvalidOperationException();
        }
    }
}
