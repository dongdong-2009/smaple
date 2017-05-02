<%@ Page Language="C#" AutoEventWireup="false" CodeFile="TestValidator.aspx.cs" Inherits="TestValidator" %>

<%@ Register Assembly="CustomValidators" Namespace="CustomValidators" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
//        function showPosition(){
//            var position = WebForm_GetElementPosition(document.getElementById("txtBirthday"));
//            alert(position.x);
//            alert(position.y);
//        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:textbox ID="txtName" runat="server"></asp:textbox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
            ErrorMessage="请输入用户名" ValidationGroup="Register">*</asp:RequiredFieldValidator><br />
        <asp:TextBox ID="txtPassword" TextMode="password" runat="Server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
            ErrorMessage="RequiredFieldValidator" ValidationGroup="Register">*</asp:RequiredFieldValidator><br />
        <asp:TextBox ID="txtComfirm" TextMode="password" runat="Server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComfirm"
            ErrorMessage="RequiredFieldValidator" ValidationGroup="Register">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPassword"
            ControlToValidate="txtComfirm" ErrorMessage="CompareValidator" ValidationGroup="Register">*</asp:CompareValidator><br />
        <asp:TextBox ID="txtBirthday" runat="Server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtBirthday"
            ErrorMessage="CompareValidator" Operator="DataTypeCheck" Type="Date" ValueToCompare="Register">*</asp:CompareValidator><br />
        &nbsp;<asp:Button ID="btnRegister" runat="server" Text="注册" ValidationGroup="Register" /></div>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server">
        </cc1:ValidatorCalloutExtender>
        <br />
        5
    </form>
</body>
</html>
