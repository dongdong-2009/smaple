using System;
using System.Collections.Generic;
using System.Text;

namespace MobileControlLibrary.UI.Controls
{
    //���ֽӿڣ�����WML DTD�еĽṹ
    //���ڿ��ƿؼ����໥Ƕ�׹�ϵ

    interface IEmph : IText
    {
    }

    public interface IFields
    {
    }

    public interface IFlow : IFields
    {
    }

    interface ILayout : IFlow
    {
    }

    interface IText : IFlow
    {
    }

    interface INavElmts
    {
    }
}
