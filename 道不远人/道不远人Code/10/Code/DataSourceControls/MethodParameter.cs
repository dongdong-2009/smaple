using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Compilation;
using System.Reflection;
using System.ComponentModel;

namespace DataSourceControls
{
    public class MethodParameter:Parameter
    {
        public string TypeName
        {
            get
            {
                if (ViewState["TypeName"] == null)
                {
                    return string.Empty;
                }
                return (string)ViewState["TypeName"];
            }
            set { ViewState["TypeName"] = value; }
        }

        public string ParameterValues
        {
            get
            {
                if (ViewState["ParameterValues"] == null)
                {
                    return string.Empty;
                }
                return (string)ViewState["ParameterValues"];
            }
            set { ViewState["ParameterValues"] = value; }
        }

        public string MethodName
        {
            get
            {
                if (ViewState["MethodName"] == null)
                {
                    return string.Empty;
                }
                return (string)ViewState["MethodName"];
            }
            set { ViewState["MethodName"] = value; }
        }

        public MethodParameter()
        {
        }
        protected MethodParameter(MethodParameter original)
            : base(original)
        {
            this.TypeName = original.TypeName;
            this.MethodName = original.MethodName;
            this.ParameterValues = original.ParameterValues;
        }
        protected override Parameter Clone()
        {
            return new MethodParameter(this);
        }
        protected override object Evaluate(System.Web.HttpContext context, System.Web.UI.Control control)
        {
            string[] parameters = null;
            if(ParameterValues.Length > 0)
                parameters = ParameterValues.Split(',');
            return GetMethodReturnValue(TypeName, MethodName, parameters);
        }

        /// <summary>
        /// ִ��ĳ����ʽ��÷���ֵ
        /// </summary>
        /// <param name="typeName">�������ڵ��࣬���Ϊnull�����Ե�ǰҳ�����Ϊ����ִ��������</param>
        /// <param name="methodName">��ִ�з�����</param>
        /// <param name="parameterValues">���ݸ������Ĳ��������ַ���������</param>
        /// <returns></returns>
        private static object GetMethodReturnValue(string typeName, string methodName, params string[] parameterValues)
        {
            //Ĭ��ʹ�õ�ǰҳ��
            Type type = null;
            if (HttpContext.Current != null && HttpContext.Current.CurrentHandler != null)
            {
                type = HttpContext.Current.CurrentHandler.GetType();
            }
            bool isCurrentPage = true;
            if (!string.IsNullOrEmpty(typeName))
            {
                //ͨ������õ�������Ϣ
                type =  System.Type.GetType(typeName, false, true);
                if (type == null)
                {
                    //����ASP.NET����ʱ������
                    type = BuildManager.GetType(typeName, false, true);
                }
                isCurrentPage = false;
            }
            if (type != null)
            {
                object o = null;
                //��ú�����Ϣ
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
                    //��֯����
                    ParameterInfo[] paraInfos = method.GetParameters();
                    object[] paras = new object[paraInfos.Length];
                    for (int i = 0; i < paraInfos.Length; i++)
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
                                    //������ת����Ҫ������,����TypeDescriptor�Զ��������ת����
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
                    //ִ�з�������÷���ֵ
                    if (method.IsStatic)
                    {
                        o = method.Invoke(null, paras);
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
}
