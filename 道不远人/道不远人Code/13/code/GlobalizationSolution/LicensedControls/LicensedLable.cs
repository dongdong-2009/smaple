using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace LicensedControls
{
    [LicenseProvider(typeof(ExpirePolicyLicenseProvider))]
    public class LicensedLable:Label
    {
        License _license;
        public LicensedLable()
        {
            //验证许可
            _license = LicenseManager.Validate(typeof(LicensedLable), this);
        }

        public override void Dispose()
        {
            base.Dispose();
            if (_license != null)
            {
                _license.Dispose();
            }
        }
    }
}
