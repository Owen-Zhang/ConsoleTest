using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    class BaseOther<T> where T :class
    {
        public T Dowork()
        {
            return ConstructResponse();
        }

        public virtual T ConstructResponse() { return default(T); }
    }
}
