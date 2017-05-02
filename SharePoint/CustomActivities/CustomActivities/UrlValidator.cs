using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel.Compiler;
using System.Text.RegularExpressions;
using CustomActivities.Workflow1;

namespace CustomActivities
{
    public class UrlValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
           CreateSubSite createSubSite = obj as CreateSubSite;
           ValidationErrorCollection errCol = new ValidationErrorCollection();
           if (createSubSite != null)
           {
               string url = createSubSite.SiteUrl;
               if (url != null && url.Trim() != string.Empty)
               {
                   Regex noSpecialChars = new Regex(@"\W");
                   if (noSpecialChars.IsMatch(url))
                   {
                       errCol.Add(new ValidationError("The URL should be relative to the site, " + "with no slashes, spaces, or special symbols.", 0001));
                   }
               }
               if (url == string.Empty)
               {
                   errCol.Add(new ValidationError("The SiteUrl property cannot be null", 0002));
               }
               if (createSubSite.SiteName == string.Empty)
               {
                   errCol.Add(new ValidationError("The SiteName property cannot be null", 0003));
               }
           }
           return errCol;
        }
    }
}
