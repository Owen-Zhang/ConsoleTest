using System;
using System.Net;
using System.Text;
namespace Test.Common
{
    public class HttpRestClient
    {
        WebHeaderCollection Header;
        public string responseStr;

        public HttpRestClient(WebHeaderCollection header)
        {
            this.Header = header;
        }

        public T PostByStrService<T>(string url, string method, object body = null, string encoding = "Utf-8")
            where T : class
        {
            var requestStr = GetRequestBodyStr(body);
            string responseStr = string.Empty;
            try
            {
                responseStr =
                new RequestHelper()
                    .GetHttpResponseStr(
                        new RequestInfo { 
                            Url = url,
                            Body = Encoding.GetEncoding(encoding).GetBytes(requestStr),
                            Method = method,
                            Header = this.Header
                        });
            }
            catch (Exception e)
            { 
                
            }
            return 
                SerializeManager.Deserialize<T>(responseStr, this.Header["Accept"]);
        }

        public T PostByteService<T>(string url, string method, byte[] byteContent)
            where T : class
        {
            string responseStr = string.Empty;

            try
            {
                responseStr = 
                new RequestHelper()
                   .GetHttpResponseStr(
                        new RequestInfo
                        {
                            Url = url,
                            Body = byteContent,
                            Method = method,
                            Header = this.Header
                        });
            }
            catch (Exception e)
            { 
                
            }
            return SerializeManager.Deserialize<T>(responseStr, this.Header["Accept"]);
        }

        public byte[] GetByteService(string url, string method, object body = null, string encoding = "Utf-8")
        {
            var requestStr = GetRequestBodyStr(body);
            try
            {
                return
                new RequestHelper()
                    .GetHttpResponseByte(
                        new RequestInfo
                        {
                            Url = url,
                            Body = Encoding.GetEncoding(encoding).GetBytes(requestStr),
                            Method = method,
                            Header = this.Header
                        });
            }
            catch (Exception e)
            { 
            
            }
            return null;
        }

        private string GetRequestBodyStr(object body)
        {
            if (body == null)
                return string.Empty;
            return SerializeManager.Serialize(body, this.Header["Content-Type"]);
        }
    }
}

//当使用 application/x-www-form-urlencoded提交时使用以下方式

public class ConvertRequest
    {

        private static String ServerURL = "http://opencc.byvoid.com/convert";


        public static String CN2HK(String cnText)
        {
            if (string.IsNullOrEmpty(cnText))
            {
                return cnText;
            }
            if (Regex.IsMatch(cnText, "^[0-9a-zA-Z]+$"))
            {
                return cnText;
            }

            String hkText = cnText;
            cnText = System.Web.HttpUtility.UrlEncode(cnText, Encoding.UTF8);
            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("config", "s2t.json"));
            content.Add(new KeyValuePair<string, string>("precise", "0"));
            content.Add(new KeyValuePair<string, string>("text", cnText));
            try
            {
                hkText = SendRequest(ServerURL, content, "POST");
            }
            catch (Exception ex)
            {
                hkText = cnText;
            }
            return hkText;
        }

        /// <summary>
        /// HTTP请求并返回结果
        /// </summary>
        /// <param name="url">URL地址，http/https格式，不能含?和参数</param>
        /// <param name="paraList">参数，以keyvalue列表的方式，key表示参数名，value为参数值，value不要urlencode编码</param>
        /// <param name="method">POST/GET</param>
        /// <returns>返回结果，如果发生异常则直接向外抛出</returns>
        private static string SendRequest(string url, List<KeyValuePair<string, string>> paraList, string method)
        {
            string strResult = string.Empty;
            if (url == null || url == "")
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(method))
            {
                method = "GET";
            }

            // GET方式
            if (method.ToUpper() == "GET")
            {

                string fullUrl = url.TrimEnd('?') + "?";
                if (paraList != null)
                {
                    foreach (KeyValuePair<string, string> kv in paraList)
                    {
                        //Jin：Uri.EscapeDataString是最完美URLENCODE方案
                        fullUrl += kv.Key + "=" + Uri.EscapeDataString(kv.Value) + "&";
                    }
                    fullUrl = fullUrl.TrimEnd('&');
                }

                System.Net.WebRequest wrq = System.Net.WebRequest.Create(fullUrl);
                wrq.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                System.Net.WebResponse response = wrq.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));

                strResult = sr.ReadToEnd();
                sr.Close();
                response.Close();
            }

            // POST方式
            if (method.ToUpper() == "POST")
            {
                url = url.TrimEnd('?');
                WebRequest wrq = WebRequest.Create(url);
                wrq.Method = "POST";
                wrq.ContentType = "application/x-www-form-urlencoded";

                StringBuilder sbPara = new StringBuilder();
                string paraString = string.Empty;
                if (paraList != null)
                {
                    foreach (KeyValuePair<string, string> kv in paraList)
                    {
                        //sbPara.Append(kv.Key + "=" + Uri.EscapeDataString(kv.Value) + "&");
                        sbPara.Append(kv.Key + "=" + kv.Value + "&");
                    }
                    paraString = sbPara.ToString().TrimEnd('&');

                    byte[] buf = System.Text.Encoding.GetEncoding("utf-8").GetBytes(paraString);
                    System.IO.Stream requestStream = wrq.GetRequestStream();
                    requestStream.Write(buf, 0, buf.Length);
                    requestStream.Close();
                }
                else
                {
                    wrq.ContentLength = 0;
                }

                HttpWebResponse response = null;
                StreamReader reader = null;
                try
                {
                    response = wrq.GetResponse() as HttpWebResponse;
                    Encoding htmlEncoding = Encoding.UTF8;
                    reader = new StreamReader(response.GetResponseStream(), htmlEncoding);
                    strResult = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                }
                catch (WebException e)
                {
                    throw new Exception(string.Format("调用第三方的翻译有问题: {0}", e.Message));
                    Logger.Error(e.ToString());
                }
                catch (Exception e)
                {
                    if (reader != null)
                        reader.Close();

                    if (response != null)
                        response.Close();

                    Logger.Error(e.ToString());
                }
            }
            return strResult;
        }
    }

