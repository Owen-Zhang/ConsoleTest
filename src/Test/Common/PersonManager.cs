﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public static class PersonManager
    {
        public static void AddPersonStatus(Person p) {
            p.IsEnabled = new PersonOther().IsMananger();
        }
    }
}
