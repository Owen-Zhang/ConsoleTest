using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Test
{
    public class RestResourceConfiguration
    {
        private static RestResourceSection restSection = 
            (RestResourceSection)ConfigurationManager.GetSection("RestResourceSection");

        public static string APIName
        {
            get {
                if (restSection != null)
                    return restSection.APIName;
                return string.Empty;
            }
        }

        public static string DebugMode
        {
            get
            {
                if (restSection != null)
                    return restSection.DebugMode;
                return string.Empty;
            }
        }
        
        public static List<string> GetAllTypes
        {
            get {
                if (restSection != null)
                    return restSection.Resources.GetAllTypes();
                return null;
            }
        }

        public static string LogPath
        {
            get {
                if (restSection != null)
                    return restSection.LogSetting.LogPath;
                return string.Empty;
            }
        }

        public static string FirstPath
        {
            get
            {
                if (restSection != null)
                    return restSection.LogSetting.logSettingFirst.FirstPath;
                return string.Empty;
            }
        }

        public static string Mode
        {
            get {
                if (restSection != null)
                    return restSection.LogSetting.logSettingFirst.Mode;
                return string.Empty;
            }
        }
    }
}
