using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class StreamZip
    {
        public static string GZip(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            using (var ms = new MemoryStream())
            using (var zipStream = new GZipStream(ms, CompressionMode.Compress))
            {
                zipStream.Write(buffer, 0, buffer.Length);
                zipStream.Close();
                
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Gunzip(string text)
        {
            byte[] gzBuffer = Convert.FromBase64String(text);

            MemoryStream outBuffer = new MemoryStream();
            using (var stream = new MemoryStream(gzBuffer))
            using (var zipStream = new GZipStream(stream, CompressionMode.Decompress))
            { 
                byte[] bytes = new byte[1024];
                int index = 0;
                while(true){
                    index = zipStream.Read(bytes, 0, bytes.Length);
                    if (index <= 0)
                        break;
                    else
                        outBuffer.Write(bytes, 0, index);
                }
            }

            return Encoding.UTF8.GetString(outBuffer.ToArray());
        }
    }
}
