using IService;
using NUnit.Framework;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestFixture]
    public class OrderTester
    {
        [Test]
        public  void GetOrderList()
        {
            IPerson person = new Person();
            var list = new Order(person).ConsoleSomething("aaa");

            Assert.AreNotSame(0, list.Count);
        }
    }
}
