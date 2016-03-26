using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test
{
    public class TextEmitter : IEmitter
    {
        public void EmitLog(string content)
        {
            WriteFile(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"),
                content);
        }

        private void WriteFile(string fileName, string content)
        {
            byte[] text = Encoding.UTF8.GetBytes(content);
            using (FileStream logStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                logStream.Write(text, 0, text.Length);
            }
        }
    }
}
