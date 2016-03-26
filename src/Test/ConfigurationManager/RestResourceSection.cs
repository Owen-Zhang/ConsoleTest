using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    
    public class RestResourceSection : ConfigurationSection
    {
        [ConfigurationProperty("Resources", IsRequired = true)]
        public Resources Resources
        {
            get {
                return this["Resources"] as Resources;
            }
        }
        
        [ConfigurationProperty("LogSetting",  IsRequired = false)]
        public LogSetting LogSetting
        {
            get {
                return this["LogSetting"] as LogSetting;
            }
        }

        [ConfigurationProperty("APIName", IsRequired = false)]
        public string APIName
        {
            get {
                return this["APIName"] as string;
            }
        }

        [ConfigurationProperty("DebugMode", IsRequired = true)]
        public string DebugMode
        {
            get {
                return this["DebugMode"] as string;
            }
        }
    }

    [ConfigurationCollection(typeof(ResourceElement), AddItemName = "Resource",  CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class Resources : ConfigurationElementCollection
    {
        public ResourceElement this[int index]
        {
            get {
                return base.BaseGet(index) as ResourceElement;
            }
        }

        public ResourceElement this[string key]
        {
            get {
                return base.BaseGet(key) as ResourceElement;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
 	        return new ResourceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
 	        return (element as ResourceElement).AssemblyName;
        }

        public List<string> GetAllTypes()
        {
            return this.BaseGetAllKeys().Select(key => key.ToString()).ToList();
        }
    }

    public class ResourceElement : ConfigurationElement
    {
        [ConfigurationProperty("AssemblyName", IsRequired = true)]
        public string AssemblyName
        {
            get {
                return this["AssemblyName"] as string;
            }
        }
    }

    public class LogSetting : ConfigurationElement
    {
        [ConfigurationProperty("LogPath", IsRequired = false)]
        public string LogPath
        {
            get {
                return this["LogPath"] as string;
            }
        }

        [ConfigurationProperty("logSettingFirst", IsRequired = false)]
        public logSettingFirst logSettingFirst
        {
            get {
                return this["logSettingFirst"] as logSettingFirst;
            }
        }
    }

    public class logSettingFirst : ConfigurationElement
    {
        [ConfigurationProperty("FirstPath", IsRequired = false)]
        public string FirstPath
        {
            get
            {
                return this["FirstPath"] as string;
            }
        }

        [ConfigurationProperty("Mode", IsRequired = false)]
        public string Mode {
            get {
                return this["Mode"] as string;
            }
        }
    }
}
