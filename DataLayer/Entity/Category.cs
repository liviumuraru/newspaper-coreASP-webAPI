using DataLayer.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity
{
    public class Category
    {
        public Category()
        {
        }

        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
}
