﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Test.Common;

namespace Test.Common
{
    public class SerializeManager
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="reqObj"></param>
        /// <returns></returns>
        public static string Serialize(object reqObj, string contentType)
        {
            if (reqObj is string)
            {
                return reqObj as string;
            }

            //var accept = this.Header["Content-Type"];
            if (string.IsNullOrWhiteSpace(contentType))
            {
                return null;
            }

            if (string.Compare(contentType, ContentFormat.Xml, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return ServiceStack.Text.XmlSimpleSerializer.SerializeToString(reqObj);
            }

            return string.Compare(contentType, ContentFormat.Json, StringComparison.OrdinalIgnoreCase) == 0 ? ServiceStack.Text.JsonSerializer.SerializeToString(reqObj) : null;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseStr"></param>
        /// <param name="accept"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string responseStr, string accept)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(responseStr))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(accept))
            {
                return null;
            }

            var t = default(T);
            if (string.Compare(accept, ContentFormat.Xml, StringComparison.OrdinalIgnoreCase) == 0)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(responseStr);
                using (var stream = new MemoryStream(buffer))
                {
                    t = ServiceStack.Text.XmlSimpleSerializer.DeserializeFromStream<T>(stream);
                }
            }
            else if (string.Compare(accept, ContentFormat.Json, StringComparison.OrdinalIgnoreCase) == 0)
            {
                t = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(responseStr);
            }

            return t;
        }
    }
}
