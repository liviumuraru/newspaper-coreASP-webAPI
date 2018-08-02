using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entity;
using FluentNHibernate.Mapping;

namespace DataLayer.Mapping
{
   public class CategoryMap
        : ClassMap<Category>
   {
        public CategoryMap()
        {
            SetupORM();
        }

        protected virtual void SetupORM()
        {
            Table("dbo.Category");

            Id(category => category.ID);

            Map(category => category.Name);
        }
   }
}
