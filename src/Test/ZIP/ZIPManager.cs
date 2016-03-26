// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZIPManager.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2016 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   ZIPManager created at  1/5/2016 5:05:58 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;

namespace Test.ZIP
{
    public class ZIPManager
    {
        /// <summary>
        /// 对单个文件进行压缩
        /// </summary>
        public static void ZipFile(string sourceFilePath, string zipedFilePath, int compressionLevel)
        {
            if (!File.Exists(sourceFilePath))
                return;

            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipedFilePath)))
            {
                s.SetLevel(compressionLevel);
                byte[] buffer = new byte[4096];
                ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFilePath));
                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(sourceFilePath))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
                s.Finish();
                s.Close();
            }
        }

        /// <summary>
        /// 文件夹压缩
        /// </summary>
        public static void ZipDirectory(string sourceDirectory, string zipedFilePath, int compressionLevel = 9)
        {
            if (!Directory.Exists(sourceDirectory))
                return;

            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipedFilePath)))
            {
                s.SetLevel(compressionLevel);
                byte[] buffer = new byte[4096];

                string[] filesName = Directory.GetFiles(sourceDirectory);

                foreach (var fileName in filesName)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(fileName));
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(fileName))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                s.Finish();
                s.Close();
            }
        }

        public static void CopyHttpFile(string url, string resultFile)
        {
            byte[] buffer = new byte[4096];

            Stream fs = null;
            WebRequest request = WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                fs = new FileStream(resultFile, FileMode.Create);

                int sourceBytes;
                do
                {
                    sourceBytes = responseStream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, sourceBytes);
                } while (sourceBytes > 0);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
