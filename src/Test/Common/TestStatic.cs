using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class TestStatic
    {
        private Person p;

        public TestStatic() { 
            p = new Person(){ Id = 1, IsEnabled = true, Name = "1"};
            Console.WriteLine("bbbbb");
        }

        public static void TestStatic1() {
            Console.WriteLine("aaaaa");
        }

        public void TestStatic2()
        {
            Console.WriteLine("aaaaa");
        }
    }
}
