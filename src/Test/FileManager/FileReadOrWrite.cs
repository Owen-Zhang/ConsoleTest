using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FileManager
{
    public class FileReadOrWrite
    {
        public static byte[] ReadFile(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                byte[] contentBytes = new byte[stream.Length];
                stream.Read(contentBytes, 0, contentBytes.Length);
                return contentBytes;
            }
        }

        public static bool WriteFileFromBytes(string filePath, byte[] fileBytes)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write)) {
                stream.Write(fileBytes, 0, fileBytes.Length);
            }
            return true;
        }
    }
}
