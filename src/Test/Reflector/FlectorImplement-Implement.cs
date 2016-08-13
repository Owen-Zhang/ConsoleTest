using System;
namespace Test.Reflector
{
    public class FlectorImplement_Implement : FlectorImplement
    {
        public FlectorImplement_Implement(string name) : base(name) 
        {
 
        }

        public override void TestImpl()
        {
            base.TestImpl();
            Console.WriteLine("other -- implement");
        }
    }
}
