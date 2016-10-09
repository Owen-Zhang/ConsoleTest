using System;

namespace Model
{
    public class ExcelMapAttribute : Attribute
    {
        string m_Mapping;

        public ExcelMapAttribute(string mapping)
        {
            m_Mapping = mapping;
        }

        public string Mapping
        {
            get
            {
                return m_Mapping;
            }
        }

        public string xxxx
        {
            get;
            set;
        }
    }
}
