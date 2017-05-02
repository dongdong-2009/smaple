using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Web.Compilation;
using System.ComponentModel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        object o = GetMethodReturnValue("_Default", "HelloWorld","THIN","25");
        if (o != null)
        {
            Literal ltl = new Literal();
            ltl.Text = o.ToString();
            Controls.Add(ltl);
        }
    }

    public string HelloWorld(string name,int age)
    {
        return string.Format("Hello world,{0},your age is {1}? " , name,age) ;
    }

    /// <summary>
    /// 执行某个方式获得返回值
    /// </summary>
    /// <param name="typeName">方法所在的类，如果为null，则以当前页面对象为方法执行上下文</param>
    /// <param name="methodName">被执行方法名</param>
    /// <param name="parameterValues">传递给方法的参数，用字符串数组表达</param>
    /// <returns></returns>
    public static object GetMethodReturnValue(string typeName, string methodName,params string[] parameterValues)
    {
        //默认使用当前页面
        Type type = null;
        if (HttpContext.Current != null && HttpContext.Current.CurrentHandler != null)
        {
            type = HttpContext.Current.CurrentHandler.GetType();
        }
        bool isCurrentPage = true;
        if (!string.IsNullOrEmpty(typeName))
        {
            //通过反射得到类型信息
            type = Type.GetType(typeName, false, true);
            if (type == null)
            {
                //处理ASP.NET的临时生成类
                type = BuildManager.GetType(typeName, false, true);
            }
            isCurrentPage = false;
        }
        if (type != null)
        {
            object o = null;
            //获得函数信息
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.FlattenHierarchy | BindingFlags.Public |
                BindingFlags.Static | BindingFlags.Instance |
                BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo m in methods)
            {
                if (string.Equals(m.Name, methodName, StringComparison.OrdinalIgnoreCase) && !m.IsGenericMethodDefinition)
                {
                    method = m;
                    break;
                }
            }
            if (method != null)
            {
                //组织参数
                ParameterInfo[] paraInfos = method.GetParameters();
                object[] paras = new object[paraInfos.Length];
                for(int i = 0; i < paraInfos.Length ; i++)
                {
                    if (parameterValues.Length > i)
                    {
                        if (string.IsNullOrEmpty(parameterValues[i]))
                        {
                            paras[i] = null;
                        }
                        else
                        {
                            try
                            {
                                //将参数转成需要的类型
                                paras[i] = TypeDescriptor.GetConverter(paraInfos[i].ParameterType).ConvertFromString(parameterValues[i]);
                            }
                            catch (FormatException)
                            {
                                paras[i] = null;
                            }
                        }
                    }
                    else
                    {
                        paras[i] = null;
                    }
                }
                //执行方法，获得返回值
                if (method.IsStatic)
                {
                    o = method.Invoke(null,paras);
                }
                else
                {
                    if (isCurrentPage)
                    {
                        o = method.Invoke(HttpContext.Current.CurrentHandler, paras);
                    }
                    else
                    {
                        object tempInstance = Activator.CreateInstance(type);
                        o = method.Invoke(tempInstance, paras);                        
                    }
                }
            }
            return o;
        }
        return null;
    }

}
