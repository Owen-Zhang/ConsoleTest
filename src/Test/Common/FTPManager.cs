using System.IO;
using System.Net;
namespace Test.Common
{
    public class FTPManager
    {
        private string ftpUSerName;
        private string ftpPassWord;
        private string ftpHost;

        public FTPManager(string ftpUSerName, string ftpPassWord, string ftpHost)
        {
            this.ftpHost = ftpHost;
            this.ftpUSerName = ftpUSerName;
            this.ftpPassWord = ftpPassWord;
        }
        public bool UpLoadFile(string originFilePath, string ftpFileName)
        {
            if (!File.Exists(originFilePath))
                return false;

            var ftPUrl = string.Format("ftp://{0}/{1}", ftpHost, ftpFileName);
            int buffLength = 1024;
            byte[] buff = new byte[buffLength];

            int realByteLength;
            using (FileStream fs = File.OpenRead(originFilePath))
            {
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(ftPUrl);
                ftpRequest.Credentials = new NetworkCredential(ftpUSerName, ftpPassWord);
                ftpRequest.KeepAlive = false;
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.UseBinary = true;
                ftpRequest.Proxy = null;
                ftpRequest.ContentLength = fs.Length;

                using (Stream stream = ftpRequest.GetRequestStream())
                {
                    realByteLength = fs.Read(buff, 0, buffLength);
                    while (realByteLength > 0)
                    {
                        stream.Write(buff, 0, realByteLength);
                        realByteLength = fs.Read(buff, 0, buffLength);
                    }
                    stream.Flush();
                }
            }
            return true;
        }

        public Stream DownLoadFile()
        {
            return null;
        }
    }
}
