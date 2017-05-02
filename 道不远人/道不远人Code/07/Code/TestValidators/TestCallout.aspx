<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCallout.aspx.cs" Inherits="TestCallout" %>

<%@ Register Assembly="CustomValidators" Namespace="CustomValidators" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>

</head>
<body >
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <cc1:calloutrequiredfieldvalidator id="CalloutRequiredFieldValidator1" runat="server"
            controltovalidate="TextBox1" errormessage="Must input a Name">*</cc1:calloutrequiredfieldvalidator><br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <cc1:calloutrequiredfieldvalidator id="CalloutRequiredFieldValidator2" runat="server"
            controltovalidate="TextBox2" errormessage="Must input a Password">*</cc1:calloutrequiredfieldvalidator><br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    
    </form>
</body>
</html>
