using System;

namespace Test.Reflector
{
    public class FlectorImplement : FlectoerCreateInstanceAbstract
    {
        public FlectorImplement(string name) : base(name)
        { 
               
        }

        public override void TestImpl() {
            Console.WriteLine("TestImpl..............");
        }
    }
}
