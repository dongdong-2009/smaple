using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// PageValidate 的摘要说明
/// </summary>
public class PageValidateList
{

         //public PageValidateList() 
         //{ 


         //}




 
 
    //验证用户名
    public static bool IsName(string input)
    {
        Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{3,19}$");
        return regex.IsMatch(input);

    }
    //验证密码
    public static bool IsWord(string input)
    {
        Regex regex = new Regex("^(?=.*?[0-9])(?=.*?[a-zA-Z])[0-9a-zA-Z]+$");
        return regex.IsMatch(input);
        //^(?![^A-Z]+$)(?![^0-9]+$)(?![^a-z]+$).{8,15}$
        //^(?=.*?[0-9])(?=.*?[a-zA-Z])[0-9a-zA-Z]+$
        //@\"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})
       // ^(?!(^[0-9]*$|^[a-zA-Z]*$))\w*$

    }
    //验证密码位数
    public static bool IsWord2(string input)
    {
        Regex regex = new Regex("^[a-zA-Z0-9][a-zA-Z0-9]{7,19}$");
        return regex.IsMatch(input);

    }
    //验证电话号码
    public static bool IsPhone(string input)
    {

        Regex regex = new Regex("^0\\d{2,3}-\\d{7,8}$");
        return regex.IsMatch(input);

    }

    //验证手机
    public static bool IsMobilePhone(string input)
    {
        Regex regex = new Regex("^(13|15)\\d{9}$");
        return regex.IsMatch(input);

    }
    //验证email
    public static bool IsEmail(string input)
    {
        Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        return regex.IsMatch(input);

    }
    //验证qq
    public static bool Isqq(string input)
    {
        Regex regex = new Regex("^[1-9][0-9]{4,8}$");
        return regex.IsMatch(input);

    }

    //验证网址
    public static bool Iswww(string input)
    {
        Regex regex = new Regex("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?");
        return regex.IsMatch(input);

    }
    //验证日期
    public static bool IsDate(string input)
    {
        Regex regex = new Regex("^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-8]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        return regex.IsMatch(input);

    }
    //验证hanzi
    public static bool IsHanzi(string input)
    {
        Regex regex = new Regex("^[\u4e00-\u9fa5]+$");
        return regex.IsMatch(input);

    }
    //验证商品数量
    public static bool Isshuliang(string input)
    {
        Regex regex = new Regex("^[1-9][0-9]{0,4}$");
        return regex.IsMatch(input);

    }
    //验证价钱
    public static bool IsMoney(string input)
    {
        Regex regex = new Regex("^\\d+(\\.\\d\\d)?$");
        return regex.IsMatch(input);

    }


    //验证URL
    public static bool IsUrl(string input)
    {
        Regex regex = new Regex("^(http|https|ftp)\\://[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\\-\\._\\?\\,\'/\\\\+&%\\$#\\=~])*$"
);
        return regex.IsMatch(input);

    }

  /// 
  /// 判断输入的字符串只包含数字
  /// 可以匹配整数和浮点数
  /// ^-?\d+$|^(-?\d+)(\.\d+)?$
  public static bool IsNumber(string input)
  {
   string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
   Regex regex = new Regex(pattern);
   return regex.IsMatch(input);
  }

  /// <summary>
  /// 检查是否是数字
  /// true表示是数字，false表示否
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>

  public static bool RteNum(string str)
  {
      if (str == "" || str == null)
      {

          return false;

      }
      else
      {

          System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");

          return reg1.IsMatch(str);
      }


  }
  /// <summary>
  /// 检查数字．没有返回值
  /// </summary>
  /// <param name="id"></param>
  public static void Check_num(string id)
  {
      if (!RteNum(id))
      {

          HttpContext.Current.Response.Write("<script>alert(\"非法操作！\");historyback()</script>");
          HttpContext.Current.Response.End();
      }


  }


} 

