using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class EmitterFactory
    {
        public static IEmitter Create()
        {
            string mode = RestResourceConfiguration.Mode;
            if (string.IsNullOrEmpty(mode))
                throw new Exception("sdfasd");
            
            //IEmitter emitter = null;
           
            return CreateCustomerEmitter(RestResourceConfiguration.LogPath);            
        }

        private static IEmitter CreateCustomerEmitter(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentException("");

            Type provider = Type.GetType(providerName);
            var emitter = Activator.CreateInstance(provider) as IEmitter;
            if (emitter == null)
                throw new ArgumentException("");
            return emitter;
        }
    }
}
