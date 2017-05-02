<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowUc.aspx.cs" Inherits="ShowUc" %> 
<%@ Register TagPrefix ="my" TagName ="tab" Src ="~/uc1.ascx" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" > 
<head id="Head1" runat="server"> 
    <title>未命名頁面</title> 
</head> 
<body> 
    <form id="form1" runat="server"> 
    <div> 
    <my:tab ID="Mytab" runat="server" OnTabClick="Mytab_TabClick"  /> 
    <br /> 
        <asp:Label ID="lblshow" runat="server" Text="Label"></asp:Label> 
    </div> 
    </form> 
</body> 
</html> 
