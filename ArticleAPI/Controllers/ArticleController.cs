using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticleAPI.Models;
using ArticleAPI.Utils;
using ArticleAPI.Validators;
using DataLayer.Config;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Services.ArticleServices;

namespace ArticleAPI.Controllers
{
    [Route("api/articles")]
    public class ArticleController : Controller
    {
        public ArticleController(ArticleService service = null)
        {
            if (service == null)
                _articleService = new ArticleService(new DataLayer.Utils.ArticleRepository());
            else
                _articleService = service;
        }   

        private readonly ArticleService _articleService;

        [HttpGet("{id}")]
        public Article Get(Guid id)
        {
            return _articleService.GetByID(id);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Article> Get([FromQuery] ArticleFilterData filterData, [FromQuery] bool? sortByViews, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var raw = _articleService.GetAll(filterData.PubDate, filterData.CategoryID, filterData.Views);
            var filtered = raw;

            if(sortByViews.HasValue)
            {
                filtered = filtered.OrderBy(a => a.Views);
            }


            PagedData<Article> page;
            if (pageNumber.HasValue && pageSize.HasValue)
                page = new PagedData<Article>(filtered, pageSize.Value, pageNumber.Value);
            else
                page = new PagedData<Article>(filtered, 10, 0);

            return page.Current;
        }

        // POST api/articles
        [HttpPost]
        public object Post([FromBody]ArticleInsertionData data)
        {
            var article = new Article();
            DataTransfer.ModifyArticle(article, data);
            var validationResults = new ArticleValidator().Validate(article);
            var errorString = JsonConvert.SerializeObject(validationResults.Errors);
            var jsonResult = Json(errorString);

            if (!validationResults.IsValid)
            {
                jsonResult.StatusCode = 400;
            }

            try
            {
                _articleService.Insert(article);
                jsonResult.Value += JsonConvert.SerializeObject(article);
            }
            catch(Exception ex)
            {
                
            }

            return jsonResult;
        }

        // PUT api/articles/5
        [HttpPut("{id}")]
        public object Put(Guid id, [FromBody]ArticleModificationData value)
        {

            Article article;
        
            try
            {
                article = _articleService.GetByID(id);
                
                try
                {
                    DataTransfer.ModifyArticle(article, value);
                    _articleService.Update(article);
                }
                catch(Exception ex)
                {
                    return new StatusCodeResult(400);
                }
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(404);
            }
           
            return article;
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public object Delete(Guid id)
        {
            try
            {
                _articleService.Remove(id);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(404);
            }

            return new StatusCodeResult(200);
        }
    }
}
