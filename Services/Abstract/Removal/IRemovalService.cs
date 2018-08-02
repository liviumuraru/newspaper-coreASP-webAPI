using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract.Removal
{
    public interface IRemovalService<in T_id>
    {
        void Remove(T_id id);
    }
}
