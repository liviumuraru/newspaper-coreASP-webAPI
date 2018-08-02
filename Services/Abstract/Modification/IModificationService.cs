using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract.Modification
{
    interface IModificationService<in T>
    {
        void Update(T obj);
    }
}
