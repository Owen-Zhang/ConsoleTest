using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Log : ILog
    {
        private IEmitter emitter = EmitterFactory.Create();
        public void WriteLog(string content)
        {
            emitter.EmitLog(content);
        }
    }
}
