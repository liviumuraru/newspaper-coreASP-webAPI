using DataLayer.Config;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity
{
    public class Article
    {
        public Article()
        {
            
        }

        public virtual Guid ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Summary { get; set; }
        public virtual DateTime PublicationDate { get; set; }
        public virtual string Body { get; set; }
        public virtual int Views { get; set; }
        public virtual bool IsPublished { get; set; }

        public virtual Category Category { get; set; }
        


        public virtual void Save()
        {
            throw new InvalidOperationException();
        }

        public virtual void Update()
        {
            throw new InvalidOperationException();
        }

        
    }
}
