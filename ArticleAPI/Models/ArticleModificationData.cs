using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleAPI.Models
{
    public class ArticleModificationData
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public int Views { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsPublished { get; internal set; }
    }
}
