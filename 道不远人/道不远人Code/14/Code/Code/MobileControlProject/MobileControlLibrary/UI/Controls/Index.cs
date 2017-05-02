using System;
using System.Collections.Generic;
using System.Text;

namespace MobileControlLibrary.UI.Controls
{
    //各种接口，体现WML DTD中的结构
    //用于控制控件的相互嵌套关系

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
