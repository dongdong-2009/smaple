using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace ControlProperties
{
//���ݽ���ΪText����
[ParseChildren(true,"Text"),PersistChildren(false)]
public class SourceView:Control
{
    //���Դ����ǰ����Ļ��з����õ�������ʽ
    static Regex _regTrimBeginCarriageReturn = new Regex(@"^(\r\n)+", RegexOptions.Compiled|RegexOptions.Multiline);
    //���Դ��������Ļ��з����õ�������ʽ
    static Regex _regTrimEndCarriageReturn = new Regex(@"(\r\n)+$", RegexOptions.Compiled);
    
    //�ؼ����ݽ���ΪText���ԣ����Ҳ��Ա�ǩ��ʽ���ı��ٽ��н���
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
        //Text���Ե�ֵ�ڷ����ͻ���ǰ��Ҫ����HTML����
        
        source = HttpUtility.HtmlEncode(source);
        source =  source.Replace(" ", "&nbsp;").Replace("\r\n", "<br/>");
        writer.Write(source);
    }
}
}
