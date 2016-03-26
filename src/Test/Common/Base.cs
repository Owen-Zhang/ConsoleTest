using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Base
    {
        public  object TestObject() {
            return GetObjec();
        }

        public virtual object GetObjec() { return null; }
    }
}
