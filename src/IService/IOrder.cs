using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IService
{
    public interface IOrder
    {
        List<OrderModel> ConsoleSomething(string aaa);
        void UsePersonInfo(string info);
    }
}
