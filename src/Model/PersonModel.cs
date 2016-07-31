using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    public class PersonModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name="TestName")]
        public string Name { get; set; }

        [DataMember(Name = "Num")]
        public TestEnum testNum { get; set; }

        public DateTime dt { get; set; }
    }

    public enum TestEnum
    {
        [DataMember(Name = "first Name")]
        first,
        [DataMember(Name = "Sencond Name")]
        second
    }
}
