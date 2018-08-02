using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract.Retrieval
{
    public interface IRetrieverService<out T, in T_id>
        : IService
    {
        IEnumerable<T> GetAll(object o1, object o2, object o3);
        T GetByID(T_id id);
    }
}
