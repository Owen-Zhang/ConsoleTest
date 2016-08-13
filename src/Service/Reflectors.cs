using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Service
{
    public class Reflectors
    {
        public static void CreateInstance(Type instancetype)
        {
            var constructor = instancetype.GetConstructor(new Type[] { typeof(string) });
            var instance = constructor.Invoke(new object []{instancetype.FullName});

            var method = instancetype.GetMethod("TestConsole");
            method.Invoke(instance, null);
        }
    }
}
