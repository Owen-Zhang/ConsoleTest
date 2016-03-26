using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Test.Common
{
    [XmlRoot("Person")]
    public class Person
    {
        public int Id { get; set; }

        public string Name {get; set;}

        public bool IsEnabled {get; set;}

        public int? ParentId { get; set; }

        public List<item> ItemList { get; set; }
    }

    public class item {
        public string Name { get; set; }
    }
}
