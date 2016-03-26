using System;
namespace Test.Model
{
   public class Customer
    {
       public int hash;

       public Customer(int id, string name) {
           ID = id;
           Name = name;
           hash = id.GetHashCode();
           hash ^= name.GetHashCode();
       }

       public int ID { get; set; }
       public string Name { get; set; }

       public override bool Equals(object obj)
       {
           return Equals((Customer)obj);
       }

       public bool Equals(Customer other)
       {
           return Equals(this, other);
       }

       public bool Equals(Customer obj1, Customer obj2)
       {
           if (Object.Equals(null, obj1) ||
               Object.Equals(null, obj2))
               return false;

           return obj1.ID == obj2.ID &&
               obj1.Name == obj2.Name;
       }

       public override int GetHashCode()
       {
           return hash;
       }
    }
}
