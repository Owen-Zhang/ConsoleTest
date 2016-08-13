using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class TestReflectorClass
    {
        string name;
        public TestReflectorClass(string name)
        {
            this.name = name;
        }

        public void TestConsole()
        {
            Console.WriteLine(name);
        }
    }
}
