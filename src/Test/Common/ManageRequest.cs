using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Interface;

namespace Test.Common
{
    public class ManageRequest : IFilter
    {
        public void FilteRequest()
        {
            Console.WriteLine("implement Request filter");
        }
    }
}
