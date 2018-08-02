using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract.Insertion
{
    interface IInsertionService<in T>
    {
        void Insert(T obj);
    }
}
