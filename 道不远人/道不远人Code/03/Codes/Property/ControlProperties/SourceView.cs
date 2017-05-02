using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace ControlProperties
{
//内容解析为Text属性
[ParseChildren(true,"Text"),PersistChildren(false)]
public class SourceView:Control
{
    //清除源代码前多余的换行符所用的正则表达式
    static Regex _regTrimBeginCarriageReturn = new Regex(@"^(\r\n)+", RegexOptions.Compiled|RegexOptions.Multiline);
    //清除源代码后多余的换行符所用的正则表达式
    static Regex _regTrimEndCarriageReturn = new Regex(@"(\r\n)+$", RegexOptions.Compiled);
    
    //控件内容解析为Text属性，并且不对标签样式的文本再进行解析
    [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
    public string Text
    {
        get
        {
            if (ViewState["Text"] == null)
            {
                return string.Empty;
            }
            return (string)ViewState["Text"];
        }
        set
        {
            ViewState["Text"] = value ;
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string source = _regTrimBeginCarriageReturn.Replace(Text, "");
        source = _regTrimEndCarriageReturn.Replace(source, "");
        //Text属性的值在发到客户端前先要进行HTML编码
        
        source = HttpUtility.HtmlEncode(source);
        source =  source.Replace(" ", "&nbsp;").Replace("\r\n", "<br/>");
        writer.Write(source);
    }
}
}
