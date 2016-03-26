using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Implement : Base
    {
        public override object GetObjec() {
            return new Person() { 
                 Id = 1,
                  IsEnabled = false,
                   Name = "2",
                    ParentId = 3
            };
        }
    }
}
