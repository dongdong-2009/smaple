using System;
using System.Configuration;
using System.Reflection;
using System.Web.Util;


namespace Cnblogs.DTC.THIN.RegexUrlMapping
{
    [ConfigurationCollection(typeof(RegexUrlMapping))]
    public class RegexUrlMappingCollection : ConfigurationElementCollection
    {

        private static readonly ConfigurationPropertyCollection _properties;


        static RegexUrlMappingCollection()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        public RegexUrlMappingCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public void Add(RegexUrlMapping urlMapping)
        {
            this.BaseAdd(urlMapping);
        }

        public void Clear()
        {
            base.BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RegexUrlMapping();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RegexUrlMapping)element).Url;
        }

        public string GetKey(int index)
        {
            return (string)base.BaseGetKey(index);
        }

        public void Remove(string name)
        {
            base.BaseRemove(name);
        }

        public void Remove(RegexUrlMapping urlMapping)
        {
            base.BaseRemove(this.GetElementKey(urlMapping));
        }

        public void RemoveAt(int index)
        {
            base.BaseRemoveAt(index);
        }


        public string[] AllKeys
        {
            get
            {
                return ObjectArrayToStringArray(base.BaseGetAllKeys());
            }
        }

        public RegexUrlMapping this[int index]
        {
            get
            {
                return (RegexUrlMapping)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new RegexUrlMapping this[string name]
        {
            get
            {
                return (RegexUrlMapping)base.BaseGet(name);
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        static string[] ObjectArrayToStringArray(object[] objectArray)
        {
            string[] textArray1 = new string[objectArray.Length];
            objectArray.CopyTo(textArray1, 0);
            return textArray1;
        }


    }
}
