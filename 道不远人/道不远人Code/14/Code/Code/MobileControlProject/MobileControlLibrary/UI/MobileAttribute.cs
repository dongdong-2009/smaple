using System;
using System.Collections.Generic;
using System.Text;

namespace MobileControlLibrary.UI
{
    /// <summary>
    /// WML中可用的标签属性
    /// </summary>
    public enum MobileAttribute
    {
        ID,             Class,          OnEnterForward,         OnEnterBackward,
        OnTimer,        Title,          Type,                   Label,
        Name,           Optional,       Domain,                 Path,
        HttpEquiv,      Content,        Href,                   Method,
        EncType,        CacheControl,   AcceptCharset,          Value,
        Multiple,       TabIndex,       OnPick,                 Format,
        EmptyOk,        Size,           MaxLength,              AccessKey,
        Alt,            Src,            Align,                  Height,
        Width,          Columns,        Mode
    }
}
