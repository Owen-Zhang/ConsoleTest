using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IService;
using Model;

namespace Service
{
    public class Order : IOrder
    {
        private IPerson person;

        public Order(IPerson person)
        {
            this.person = person;
        }

        public void UsePersonInfo(string info)
        {
            person.ConsolePeson(info);
        }

        public List<OrderModel> ConsoleSomething(string aaa)
        {

            return new List<OrderModel> { 
                new OrderModel(){
                     Id = 1,
                     OrderNumber = "Number1"
                },
                new OrderModel(){
                    Id = 2,
                    OrderNumber = "Number2"
                }
            };
        }
    }
}
