using System;
using System.Configuration;
using System.Web;

namespace Cnblogs.DTC.THIN.RegexUrlMapping
{
    class RegexUrlMappingModule:IHttpModule 
    {
        static RegexUrlMappingsSection _settings = null;
        static bool _retrieved = false;

        RegexUrlMappingsSection Settings
        {
            get 
            {
                if (!_retrieved)
                {
                    _settings = ConfigurationManager.GetSection(RegexUrlMappingsSection.SectionName) as RegexUrlMappingsSection;;
                   
                    _retrieved = true;
                }
                return _settings;
            }
        }
        #region IHttpModule ≥…‘±

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            string currentPath = context.Request.Url.PathAndQuery;
            if (Settings != null)
            {
                if (Settings.IsEnabled)
                {
                    string modifiedPath = Settings.HttpResolveMapping(currentPath);
                    if (currentPath != modifiedPath)
                    {
                        context.RewritePath(modifiedPath,Settings.RebaseClientPath);
                    }
                }
            }

        }

        #endregion
    }
}
