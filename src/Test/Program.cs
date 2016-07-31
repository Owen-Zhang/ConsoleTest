using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Test.Common;
using System.Xml;
using System.Xml.Serialization;
using Test.Interface;
using Test.FileManager;
using Test.IOC;
using IService;
using RedisManager;
using System.Globalization;
using Model;
using System.Xml.Linq;
using Test.Model;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Linq.Expressions;
using Test.ZIP;
using System.Threading;
using System.Reflection;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetInventoryList("", "", "", ""); 

            /*bool? a = false;

            Console.WriteLine((a.HasValue && a.Value)? "+": "-");
            */

            #region

            /*string a = null;
            string d = "sdfasfdas";



            //var f = d.Equals(a, StringComparison.CurrentCultureIgnoreCase);
            var f = String.Equals(a, d, StringComparison.CurrentCultureIgnoreCase);

            Console.WriteLine(f);*/
            #endregion

            List<Person> pList = new List<Person>() { 
                new Person(){ Id = 1, IsEnabled = true, Name = "1", ParentId = 1},
                new Person(){ Id = 2, IsEnabled = true, Name = "2aaaa", ParentId = 2},
                new Person(){ Id = 3, IsEnabled = true, Name = "3", ParentId = 2},
                new Person(){ Id = 4, IsEnabled = true, Name = "4", ParentId = 2},
                new Person(){ Id = 5, IsEnabled = true, Name = "5", ParentId = 2},
                new Person(){ Id = 6, IsEnabled = true, Name = "6", ParentId = 2},
            };

            List<Person> p2 = new List<Person>();
            p2.Add(pList.Find(item => item.Id == 2));
            var pTemp = p2.Find(item => item.Id == 2);
            pTemp.IsEnabled = false;

            //Console.WriteLine("aaa");

            new TestStatic().TestStatic2();

            var rawUrl = "http://www.baidu.com?keyword=dsdd&from=china";

            var pathInfo = rawUrl.IndexOf("?") != -1
                ? rawUrl.Substring(0, rawUrl.IndexOf("?"))
                : rawUrl;

            Console.WriteLine(pathInfo);

            pathInfo = pathInfo.Substring(pathInfo.LastIndexOf("/"));

            Console.WriteLine(pathInfo);


            Console.WriteLine("-------------------------------");

            //xmlns=""http://soa.newegg.com/SOA/USA/InfrastructureService/V30/PubSubService""
            string xml = @"<Publish >
                              <FromService>http://soa.newegg.com/SOA/USA/CrossApplication/V30/NEGDCDB003/SellerPortal_ItemActiveService</FromService>
                              <ToService>http://soa.newegg.com/SOA/USA/InfrastructureService/V30/PubSubService</ToService>
                              <RouteTable>
                                <Article>
                                  <ArticleCategory>SellerPortal</ArticleCategory>
                                  <ArticleType1>InvUpdate</ArticleType1>
                                  <ArticleType2>*</ArticleType2>
                                </Article>
                                <Article>
                                  <ArticleCategory>SellerPortal</ArticleCategory>
                                  <ArticleType1>PriceUpdate</ArticleType1>
                                  <ArticleType2>*</ArticleType2>
                                </Article>
                              </RouteTable>
                              <Node>
                                <MessageHead>
                                  <Namespace>http://soa.newegg.com/ContentManagement/MarketingPlace/UpdateSellerItemPriceInfo/V20/</Namespace>
                                  <Version>1.0</Version>
                                  <Sender>EDI</Sender>
                                  <FromSystem>Portal2.0</FromSystem>
                                  <GlobalBusinessType>VF</GlobalBusinessType>
                                  <TransactionCode>09-832-0-905</TransactionCode>
                                </MessageHead>
                                <Body>
                                  <UpdateSellerItemPriceInfo>
                                    <RequestMaster>
                                      <Action>UpdateSellerItemPriceInfo</Action>
                                      <ActionUserId>22939163</ActionUserId>
                                      <ActionUserName>22939163</ActionUserName>
                                      <ActionDate>2014-11-28T21:42:18.6447765-08:00</ActionDate>
                                      <CompanyCode>1003</CompanyCode>
                                      <LanguageCode>en-us</LanguageCode>
                                      <CountryCode>USA</CountryCode>
                                      <SellerID>AWE3</SellerID>
                                      <ItemList>
                                        <Item>
                                          <TransactionNumber>0</TransactionNumber>
                                          <SellerItemNumber>9SIAWE30384873</SellerItemNumber>
                                          <SellerPartNumber>SO0120130222792752431</SellerPartNumber>
                                          
                                          <ShippingType>0</ShippingType>
                                          <InstantRebate>0</InstantRebate>
                                          <ItemActiveMark />
                                          <MAPPriceMark />
                                          <MAPPrice />
                                          <Inventory>30</Inventory>
                                          <WarehouseNumber />
                                          <CurrencyCode>USD</CurrencyCode>
                                        </Item>
                                        <Item>
                                          <TransactionNumber>1</TransactionNumber>
                                          <SellerItemNumber>9SIAWE30384872</SellerItemNumber>
                                          <SellerPartNumber>SO0120130222541245068</SellerPartNumber>
                                          
                                          <ShippingType>0</ShippingType>
                                          <InstantRebate>0</InstantRebate>
                                          <ItemActiveMark />
                                          <MAPPriceMark />
                                          <MAPPrice />
                                          <Inventory>20</Inventory>
                                          <WarehouseNumber />
                                          <CurrencyCode>USD</CurrencyCode>
                                        </Item>
                                      </ItemList>
                                    </RequestMaster>
                                  </UpdateSellerItemPriceInfo>
                                </Body>
                              </Node>
                            </Publish>";

            XmlDocument xmldocument = new XmlDocument();
            xmldocument.LoadXml(xml);
            XmlNode node = xmldocument.SelectSingleNode("Publish/Node/Body/UpdateSellerItemPriceInfo");

            var body = node.InnerXml;

            StringReader reader = new StringReader(body);
            var serializer = new XmlSerializer(typeof(SSBCate0Model));
            SSBCate0Model rss = (SSBCate0Model)serializer.Deserialize(reader);

            string body2 = @"
                <UPS>
                  <ShippingMethodList>
                    <ShippingMethod>
                      <Code>03</Code>
                      <MappingName>UPS Ground</MappingName>
                      <Days>5</Days>
                      <TimeInTransitCode>GND</TimeInTransitCode>
                    </ShippingMethod>
                    <ShippingMethod>
                      <Code>12</Code>
                      <MappingName>UPS 3 Day Select</MappingName>
                      <Days>3</Days>
                      <TimeInTransitCode>3DS</TimeInTransitCode>
                    </ShippingMethod>
                    <ShippingMethod>
                      <Code>02</Code>
                      <MappingName>UPS 2nd Day Air</MappingName>
                      <Days>2</Days>
                      <TimeInTransitCode>2DA</TimeInTransitCode>
                    </ShippingMethod>
                    <ShippingMethod>
                      <Code>13</Code>
                      <MappingName>UPS Next Day Air Saver</MappingName>
                      <Days>1</Days>
                      <TimeInTransitCode>1DP</TimeInTransitCode>
                    </ShippingMethod>
                  </ShippingMethodList>
                </UPS>
            ";

            StringReader reader2 = new StringReader(body2);
            var serializer2 = new XmlSerializer(typeof(UPSShipMethod));
            var rss2 = (UPSShipMethod)serializer2.Deserialize(reader2);

            //Console.WriteLine(body);

            Console.WriteLine("---------------------------------");

            var json = SerializeManager.Serialize(pList, "application/json");
            Console.WriteLine(json);

            Console.WriteLine("------------------------------------");
            var xm2 = @"<Person><Person1><Person2></Person2></Person1></Person>";
            XmlDocument xmldocument2 = new XmlDocument();
            xmldocument.LoadXml(xm2);
            XmlNode node2 = xmldocument.SelectSingleNode("Person1/Person2");

            //Console.WriteLine(node2.InnerXml);


            Console.WriteLine("------------------------------------");

            Implement implement = new Implement();
            Person p = (Person)implement.TestObject();

            Console.WriteLine(p.Id + "," + p.IsEnabled + "," + p.Name + "," + p.ParentId);

            Console.WriteLine("------------------------------------");

            var itemList = new List<item>();
            var pTemp2 = new Person() { 
                 Id = 11,
                 ItemList = null,
                  Name = "adasd"
            };

            Console.WriteLine("------------------------------------");

            //Console.WriteLine(pTemp2.ItemList.Count);

            /*foreach (var item in pTemp2.ItemList)
            {
                Console.WriteLine(item);
            }*/
            //Console.WriteLine(pTemp2.ItemList[0].Name);

            Console.WriteLine("------------------------------------");

            Func<int, int, bool> Eque = (a, b) => a > b ? true : false;

            var temp = Eque.Invoke(9, 5);

            Console.WriteLine(temp);

            Console.WriteLine("------------------------------------");

            string outStr = string.Empty;

            try
            {
                ThrowExceptionAndOutStr(out outStr);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(outStr);

            Console.WriteLine("------------------------------------");

            int d = GetSoleInt(4120);
            Console.WriteLine(d);


            Console.WriteLine("------------------------------------");

            List<Person> pList2 = new List<Person>() { 
                new Person(){ Id = 1, IsEnabled = true, Name = "1", ParentId = null},
                new Person(){ Id = 7, IsEnabled = true, Name = "7", ParentId = null},
                new Person(){ Id = 8, IsEnabled = true, Name = "8", ParentId = 2},
                new Person(){ Id = 9, IsEnabled = true, Name = "9", ParentId = 2},
                new Person(){ Id = 10, IsEnabled = true, Name = "10", ParentId = 2},
                new Person(){ Id = 11, IsEnabled = true, Name = "11", ParentId = 2},
                new Person(){ Id = 12, IsEnabled = true, Name = "12", ParentId = 2},
            };

            List<Person> result = new List<Person>();
            result.AddRange(pList);
            result.AddRange(pList2);

            Console.WriteLine(result.Count);

            Console.WriteLine("------------------------------------");

            /*
            string dTempStr = "04/09/2015";
            DateTime? d = Convert.ToDateTime(dTempStr);

            string sResult = d.Value.ToString("yyyyMMdd");
            Console.WriteLine(sResult);
            
            int intResult = 0;

            int.TryParse(sResult, out intResult);
            Console.WriteLine(intResult);
            
            DateTime date;
            //date = DateTime.Parse(intResult.ToString());
            //DateTime.TryParse(intResult.ToString(), out date);
            //Console.WriteLine(intResult.ToString());
            //Console.WriteLine(date);
            //Console.WriteLine(date.ToString("MM/dd/yyyy"));

            //DateTime orderDate = DateTime.Parse("20150204");

            string result2 = intResult.ToString("0000/00/00");
            DateTime.TryParse(result2, out date);
            Console.WriteLine(date.ToString("MM/dd/yyyy"));

            Console.WriteLine("-----------------------------");
            */
            object obj = new Person();
            Console.WriteLine(obj.GetType().Name);

            Console.WriteLine("-----------------------------");

            Person p7 = new Person() { Id = 1, IsEnabled = true, Name = "1", ParentId = 0 };
            Person p8 = new Person();

            p8 = p7;
            p8.ParentId = 2;
            Console.WriteLine(p7.ParentId);

            Console.WriteLine("-----------------------------------");

            Console.WriteLine(RestResourceConfiguration.APIName);

            Console.WriteLine("-----------------------------------");

            var filecontent = GetLargeStr();
            //Console.WriteLine(filecontent);

            var gzipstr = StreamZip.GZip(filecontent);
            Console.WriteLine(gzipstr.Length);
            //Console.WriteLine(gzipstr);

            var ord = StreamZip.Gunzip(gzipstr);
            //Console.WriteLine(ord);
            Console.WriteLine(ord.Length);

            Console.WriteLine("----------------------------------");
            decimal demax = 12;

            Console.WriteLine(demax.ToString("F2"));

            Console.WriteLine("---------------------------------");
            Base imp = new Implement();
            Base base1 = new Base();
            var ht = base1 as Implement;
            Console.WriteLine(ht != null);
            Console.WriteLine("-------------------------------");

            Type impType = typeof(Implement);
            var impOther = Activator.CreateInstance(impType);
            Console.WriteLine(impOther.GetType());
            Console.WriteLine("-------------------------------");
            Console.WriteLine(GetTypeName(typeof(Base)));

            Console.WriteLine("--------------------------------");
            FilterSome(typeof(Base));
            Console.WriteLine("-------------------------------");

            var ptemp = pList2.FirstOrDefault(item => item.Id == 15);
            Console.WriteLine(ptemp == null);
            Console.WriteLine("--------------------------------");
            //WriteFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"));
            Console.WriteLine("---------------------------------------");

            //ILog log = new Log();
            //log.WriteLog("\n\ttest comming from log 123456789 \t\n");

            Console.WriteLine("------------------------------------------");
            int? j = null;
            Console.WriteLine(j.GetValueOrDefault());
            Console.WriteLine("-------------------------------------------");

            //var taskResult1 = Task.Factory.StartNew(() => Task1("123456"));
            //var taskResult2 = Task.Factory.StartNew(() => Task2("123456"));
            var taskResult3 = Task.Factory.StartNew(() => Task3());

            Task.WaitAll(/*taskResult1, taskResult2,*/ taskResult3);
            Console.WriteLine("1111");
           // Console.WriteLine("{0},{1},{2}", taskResult1.Result, taskResult2.Result, taskResult3.Result);
            Console.WriteLine("-------------------------------------------");

            Dictionary<string, string> sSortField = new Dictionary<string, string>()
            {
                {"aaa", "ddd"},
                {"bbb", "ccc"}
            };

            Console.WriteLine(sSortField["aaa"]);
            string outStrOther = "gggg";
            sSortField.TryGetValue("aaf", out outStrOther);
            Console.WriteLine(outStrOther);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("使用byte进行文件读取保存");
            var bytes = FileReadOrWrite.ReadFile(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Picture","635761076339268887.jpg"));
            Console.WriteLine(bytes.Length);
            FileReadOrWrite.WriteFileFromBytes(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Picture", DateTime.Now.Ticks.ToString()),
                bytes);
            Console.WriteLine("------------------------------");
            var sex = Enum.Parse(typeof(PersonEnum.PersonSex), "1");
            Console.WriteLine(sex.ToString());

            Console.WriteLine("------------------------------------- 测试注入");
            ResgisterManager.InitStructureMap();
            var order = ResgisterManager.ServiceContainer.GetInstance<IOrder>();
            var person = ResgisterManager.ServiceContainer.GetInstance<IPerson>();
            var orderService = Task.Factory.StartNew(() => order.ConsoleSomething("order"));
            var personService = Task.Factory.StartNew(() => person.ConsolePeson("person"));

            Task.WaitAll(orderService, personService);

            var resultOrder = orderService.Result;
            var resultPerson = personService.Result;
            
            order.UsePersonInfo("person");

            Console.WriteLine("-----------------------------------------使用Redis");
            //var cacheStr = new PersonCashManager().GetSetCachThing("a", "测试测试redis");
            //Console.WriteLine(cacheStr);

            Console.WriteLine("---------------------------------------Delete file from date");
            DeleteFileFromDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Picture"));
            //DeleteFileFromDirectory(String.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "\\Picture"));
            Console.WriteLine("Delete file Success");

            Console.WriteLine("--------------------------------------------Yield");
            var listp2 = UseYield(pList).ToList();

            Console.WriteLine(DateTime.Now.ToString(CultureInfo.GetCultureInfo("zh-cn")));

            Console.WriteLine("-----------------------------------------");

            XElement root = new XElement("LogList");
            foreach (var item in pList2)
            {
                root.Add(new XElement("Log",
                    new XElement("LogID", item.Id),
                    new XElement("IsProcessSuccess", item.Name),
                    new XElement("RequestBody", item.ParentId)
                ));
            }
            Console.WriteLine(root.ToString());

            Console.WriteLine("-----------------------------------------");

            var customer1 = new Customer(1, "111");
            var customer2 = new Customer(1, "111");
            Console.WriteLine(customer1.GetHashCode());
            Console.WriteLine(customer2.GetHashCode());

            Console.WriteLine("-----------------------------------------");

            pList[0].Name = null;
            Console.WriteLine(ServiceStack.Text.JsonSerializer.SerializeToString(pList));
            Console.WriteLine();

            var propertyList = typeof(Person).GetProperties();

            foreach (var pFirst in pList)
            {
                foreach (var item in propertyList)
                {
                    Console.WriteLine(string.Format("{0}:{1}", item.Name, item.GetValue(pFirst)));
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Expression<Func<int, int, int>> expr = (x, y) => (x + y);
            Console.WriteLine(expr.Compile()(1, 2));
            Console.WriteLine();

            ParameterExpression para1 = Expression.Parameter(typeof(int), "x");
            ParameterExpression para2 = Expression.Parameter(typeof(int), "y");
            var bodyExpression = Expression.Add(para1, para2);
            var resultExpression = Expression.Lambda<Func<int, int, int>>(bodyExpression,
                new ParameterExpression[] { para1, para2 });

            Console.WriteLine(resultExpression.Compile()(2, 4));
            Console.WriteLine();

            ParameterExpression pe = Expression.Parameter(typeof(Person), "s");
            var propertyExp = Expression.Property(pe, typeof(Person).GetProperty("Id"));
            var express = Expression.Lambda<Func<Person, int>>(propertyExp, pe);

            Console.WriteLine(express.Compile()(pList[0]));
            Console.WriteLine();

            var pSencond = pList[1];
            //ValidateParameters<Person, string>(ConstructExpression<Person>("Name"), pSencond);

            //Expression<Func<Person, string>> sumExpression = pTest10 => pTest10.Name;
            ValidateParameters<Person, string>(pTest10 => pTest10.Name, pSencond);

            Dictionary<string, string> sortDic = new Dictionary<string, string> 
            { 
                {"ItemNumber", "ItemNumber"},
                {"SellerPartNumber", "SellerPartNumber"}
            };

            string aabbb;
            Console.WriteLine(sortDic.TryGetValue("ItemNumber1", out aabbb));
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine(DateTime.Now.Date.ToString());

            var path = string.Format(@"{0}{1}\awfo", AppDomain.CurrentDomain.BaseDirectory, "UPS");
            if (Directory.Exists(path))
                Console.WriteLine(path);
            else
                Directory.CreateDirectory(path);

            var filePath = string.Format(@"{0}\{1}.txt", path, "qw");
            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, "dafdsafasdasdfasdfasdfasdfasfdasfasdfasdf\r\n1232212");

            var path2 = string.Format(@"{0}{1}\awfo.txt", AppDomain.CurrentDomain.BaseDirectory, "abs");
            if (File.Exists(path2))
                File.Delete(path2);

            var zipPathSource = string.Format(@"{0}UPS\awfo", AppDomain.CurrentDomain.BaseDirectory);
            var zipPath = string.Format(@"{0}UPS\123.zip", AppDomain.CurrentDomain.BaseDirectory);

            ZIPManager.ZipDirectory(zipPathSource, zipPath, 9);

            string copyPath = string.Format(@"{0}UPS\456.png", AppDomain.CurrentDomain.BaseDirectory);
            ZIPManager.CopyHttpFile("http://img1.bdstatic.com/static/home/widget/search_box_home/logo/home_white_logo_0ddf152.png", copyPath);
            string UrlPath = "http://img1.bdstatic.com/static/home/widget/search_box_home/logo/home_white_logo_0ddf152.png";
            Console.WriteLine(Path.GetFileName(UrlPath));

            Directory.Delete(zipPathSource, true);

            List<Person> pp = new List<Person>();
            var h = pp.Find(item => item.Id == 2);

            Console.WriteLine(20 * (1.0 + 5 / 100.00));

            Console.WriteLine(20 * (1 + 0.05));

            Console.WriteLine((5 / 100.00));

            var filePath2 = string.Format(@"{0}123456789\4566.pdf", AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                File.Delete(filePath2);
            }
            catch (Exception e)
            {
                var message = string.Format("Message: {0}, StackTrace:{1}", e.Message, e.StackTrace);
                Console.WriteLine(message);
            }

            var shippingResponse = new GetShippingLabelResponse()
            {
                RequestID = "11111",
                OrderNumber = "22222",
                PdfFileList = new List<string> { "http://www.baidu.com", "http://www.ups.com"}
            };

            Console.WriteLine(ServiceStack.Text.XmlSerializer.SerializeToString(shippingResponse));

            //DisplayValue();

            Console.WriteLine("End");

            int refInt = 0;
            int.TryParse("5965415214", out refInt);

            Dictionary<string, string> countryDic = new Dictionary<string, string>() 
            {
                {"US", "USA"}
            };

            var address = "PR";
            string country = address;
            countryDic.TryGetValue(address, out country);
            Console.WriteLine(string.IsNullOrEmpty(country) ? address : country);

            string premierCarrier = "";
            var carrierList = premierCarrier.Split(new char[] { ','});

            var propertyInfo = typeof(GetShippingLabelResponse).GetProperty("OrderNumber");
            Console.WriteLine(propertyInfo.Name);
            Console.WriteLine(propertyInfo.PropertyType);

            Console.WriteLine(Math.Round(12.66));

            Console.WriteLine("123456789".Substring(0, 5));

            var tttt = typeof(ServiceProvider).GetMethods().FirstOrDefault().GetCustomAttributes(inherit: false);
            //System.Reflection.TypeInfo ttt = typeof(GetShippingLabelResponse).GetTypeInfo().GetCustomAttributes().OfType<>();

            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "456789.txt"), "12238787");

            List<string> aaaaabb = new List<string> { "aaa", "bbb", "cccc"};
            var ccc = aaaaabb.Take(2).ToList();
            var dddd = aaaaabb.Last();

            var dddresult = aaaaabb.Find(item => item == "ddd");

            var testdefault = default(Person);

            //var ftpService = new FTPManager("oz3t", "mygod518$", "10.1.24.178");
            //ftpService.UpLoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UPS", "635761076339268887.jpg"), "635761076339268887.jpg");

            //var nLogger = NLog.LogManager.GetCurrentClassLogger();
            var nlogger = NLog.LogManager.GetLogger("info");
            nlogger.Info("sdfasdfasdfasfdasdfasdfads");
            //nLogger.Debug("debug 11111");

            Console.WriteLine("Test V1 again");

            HttpRestClient client = new HttpRestClient(
                new WebHeaderCollection {
                     //{"Accept", ContentFormat.Json},
                     //{"AuthorizationToken", "SKxNqrhhmgfgo/lr6uhZbk1/quEMbYoOgTg1ZO4glUaBvEc1MeYiDAk9/lR+YSw67miD02eExn2gEdGm02+xxouv1+XGna4DDdVYCbF8MhZH5G7uRfQjtF448ny5j24Id9yjd8RbcVHnMIFmxUrph6LW4L32WWxv0vJpCLTFEOeQo0cSXt+LjK2Z5yOHTt9oGAu5Is1qYellKBjrHcOx0jt6SQpH/Kz0MpPLJenwIfdL7UhFypCrXjjoZsWD/Gmku4tq0sanEir4tRGGBp5ORYJB7mfqC26lAxt1a27HSGE="}
                });
            /*
            var resultRest = 
            client.PostByStrService<string>(
                    @"http://10.1.24.188:8009/Sandbox/V2.0.33.0/shippingsetting/fulfillmentcenterlist?buts=1460532268380&SellerID=AWFO",
                    "Get");
            */
            var picbyte = client.GetByteService(@"http://img1.bdstatic.com/static/home/widget/search_box_home/logo/home_white_logo_0ddf152.png", "Get");

            Console.WriteLine("hotfix bug");
            Console.WriteLine("Test V1");

            
            Console.ReadLine();
        }

        public static Task<double> GetValueAsync(double num1, double num2)  
        {  
            return Task.Run(() =>  
            {
                Thread.Sleep(4000);
                return num1/0;  
            });  
        }  

        public static async void DisplayValue()  
        {
            double result = 0;
            try
            {
                result = await GetValueAsync(1234.5, 1.01);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("catch error");
            }
            Console.WriteLine("Value is : " + result);  
        }  


        private static Expression<Func<T,string>> ConstructExpression<T>(string propertyName)
        {
            ParameterExpression validateExpression = Expression.Parameter(typeof(T), "S2");
            var propertyExp = Expression.Property(validateExpression, propertyName);
            return Expression.Lambda<Func<T, string>>(propertyExp, validateExpression);
        }

        private static void ValidateParameters<T, TProperty>(Expression<Func<T, TProperty>> expr, T p)
        {
            Console.WriteLine(expr.Compile()(p));
            Console.WriteLine(expr.Body);
            //Console.WriteLine(expr.Body.ToString());
        }

        private static void ThrowExceptionAndOutStr(out string resp)
        {
            resp = "11111";

            throw new Exception("aaaaaa");

            resp = "22222";
        }

        private static int GetSoleInt(int a)
        {
            string baseString = Convert.ToString(a, 2);
            int value = 0;

            char[] bitArray = baseString.ToCharArray();
            for (int i = bitArray.Count() - 1; i >= 0; i--)
            {
                if (bitArray[i].CompareTo('1') == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < bitArray.Count(); j++)
                    {
                        if (j == i)
                        {
                            sb.Append(bitArray[j]);
                        }
                        else
                        {
                            sb.Append(0);
                        }
                    }
                    string interfaceBaseString = sb.ToString();
                    value = Convert.ToInt32(interfaceBaseString, 2);
                }
            }

            return value;
        }

        private static string GetLargeStr()
        {
            return File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"File\LargeFile.txt"),
                Encoding.GetEncoding("gb2312"));
        }

        private static string GetTypeName(Type type)
        {
            var impOther = Activator.CreateInstance(type);
            return impOther.GetType().ToString();
        }

        private static void FilterSome(Type type)
        {
            var impOther = Activator.CreateInstance(type) as IFilter;
            if (impOther == null)
                Console.WriteLine("not implement class");
            else
                impOther.FilteRequest();
        }

        private static void WriteFile(string fileName)
        {
            byte[] text = Encoding.UTF8.GetBytes("asdasfd5454\tasfdasdfasdfasdf\tasdfas87878\tasdfsfd");
            using (FileStream logStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                logStream.Write(text, 0, text.Length);
            }
        }

        private static string Task1(string content)
        {
            System.Threading.Thread.Sleep(1000);
            return null;
        }

        private static string Task2(string content)
        {
            System.Threading.Thread.Sleep(1000);
            return content;
        }

        private static string Task3()
        {
            System.Threading.Thread.Sleep(1000);
            return "Task3";
        }

        private static void DeleteFileFromDirectory(string directory)
        {
            if (!Directory.Exists(directory)) return;

            var fileInfoLists = new DirectoryInfo(directory).GetFiles();

            var deleteDate = Convert.ToDateTime("2015-8-25");
            foreach (var file in fileInfoLists)
            {
                if (file.LastWriteTime <= deleteDate)
                    file.Delete();
            }
        }

        private static IEnumerable<Person> UseYield(List<Person> list)
        {
            foreach (var item in list)
            {
                if (item.Id > 3)
                    yield return item;
                else
                    yield return new Person() { Id = 1, IsEnabled = false, Name = "1"};
            }
        }
    }
}
