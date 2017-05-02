using System;
using System.Configuration;
using System.Web;
using System.Web.Util;
using System.Text.RegularExpressions;

namespace Cnblogs.DTC.THIN.RegexUrlMapping
{
    public class RegexUrlMapping : ConfigurationElement
    {
      
        /// <summary>
        /// Properties
        /// </summary>
        private static ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _propMappedUrl;
        private static readonly ConfigurationProperty _propUrl;

        private static readonly WhiteSpaceTrimStringConverter _trimConverter = new WhiteSpaceTrimStringConverter();
        private static readonly StringValidator _nonEmptyStringValidator = new StringValidator(1);
        


        static RegexUrlMapping()
        {
            _propUrl = new ConfigurationProperty("url", typeof(string), null, _trimConverter, _nonEmptyStringValidator, ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
            _propMappedUrl = new ConfigurationProperty("mappedUrl", typeof(string), string.Empty);
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propUrl);
            _properties.Add(_propMappedUrl);
        }

        public RegexUrlMapping()
        { 
        }

        public RegexUrlMapping(string url, string mappedUrl)
        {
            base[_propUrl] = url;
            base[_propMappedUrl] = mappedUrl;
        }




        [ConfigurationProperty("mappedUrl",DefaultValue="",IsRequired=false)]
        public string MappedUrl
        {
            get
            {
                object url = base[_propMappedUrl];
                if (url == null)
                {
                    url = string.Empty;
                }
                return (string)url;
            }
        }

        [ConfigurationProperty("url", IsRequired = true, IsKey = true)]
        public string Url
        {
            get
            {
                return (string)base[_propUrl];
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        public bool MatchAndModified(ref string path)
        {
            Regex reg = GetRegex();
            if (reg.IsMatch(path))
            {
                path = reg.Replace(path, MappedUrl);
                return true;
            }
            return false;
        }

        private Regex GetRegex()
        {
            return new Regex(Url, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }



        static bool IsAppRelativePath(string path)
        {
            if (path == null)
            {
                return false;
            }
            int num1 = path.Length;
            if (num1 == 0)
            {
                return false;
            }
            if (path[0] != '~')
            {
                return false;
            }
            if ((num1 != 1) && (path[1] != '\\'))
            {
                return (path[1] == '/');
            }
            return true;
        }
    }
}
