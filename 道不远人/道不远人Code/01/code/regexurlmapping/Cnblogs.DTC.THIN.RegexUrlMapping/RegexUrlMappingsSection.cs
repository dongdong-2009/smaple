using System;
using System.Configuration;
using System.Web.Util;
using System.Text.RegularExpressions;

namespace Cnblogs.DTC.THIN.RegexUrlMapping
{
    public class RegexUrlMappingsSection:ConfigurationSection
    {
        /// <summary>
        /// Properites
        /// </summary>
        private static readonly ConfigurationProperty _propEnabled;
        private static readonly ConfigurationProperty _propRebaseClientPath;
        private static ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _propMappings;

        public const string SectionName = "RegexUrlMappings";


        static RegexUrlMappingsSection()
        {
            _propEnabled = new ConfigurationProperty("enabled", typeof(bool), true, ConfigurationPropertyOptions.None);
            _propRebaseClientPath = new ConfigurationProperty("rebaseClientPath", typeof(bool), true, ConfigurationPropertyOptions.None);
            _propMappings = new ConfigurationProperty(null, typeof(RegexUrlMappingCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propMappings);
            _properties.Add(_propEnabled);
            _properties.Add(_propRebaseClientPath);

        }

        public string HttpResolveMapping(string path)
        {
            foreach (RegexUrlMapping mapper in UrlMappings)
            {
                if (mapper.MatchAndModified(ref path))
                    break;
            }
            return path;
        }


        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool IsEnabled
        {
            get
            {
                return (bool)base[_propEnabled];
            }
            set
            {
                base[_propEnabled] = value;
            }
        }

        [ConfigurationProperty("rebaseClientPath", DefaultValue = true)]
        public bool RebaseClientPath
        {
            get
            {
                return (bool)base[_propRebaseClientPath];
            }
            set
            {
                base[_propRebaseClientPath] = value;
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public RegexUrlMappingCollection UrlMappings
        {
            get
            {
                return (RegexUrlMappingCollection)base[_propMappings];
            }
        }
    }
}
