<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yilin.Preresearch.CSharpActiveX.WebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <object id="csharpActiveX" classid="clsid:E5E0446C-8680-4444-9FC2-F837BC617ED9"></object>
        <input type="button" onclick="alert(csharpActiveX.SayHello());" value="显示当前时间" />
    </div>
    </form>
</body>
</html>
