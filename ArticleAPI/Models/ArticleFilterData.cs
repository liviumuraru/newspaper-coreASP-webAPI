using System;

namespace ArticleAPI.Controllers
{
    public class ArticleFilterData
    {
        public DateTime? PubDate { get; set; }
        public int? Views { get; set; }
        public int? CategoryID { get; set; }
    }
}