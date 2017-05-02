<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPasswordStrenthValidator.aspx.cs" Inherits="PasswordStrenthValidator" %>
<%@ Register Assembly="CustomValidators" Namespace="CustomValidators" TagPrefix="cv" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
        //function 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <cv:PasswordStrenthValidator runat="Server" ID="psv1" ControlToValidate="TextBox1" ErrorMessage="密码过于简单，请尝试输入字母、数字、标点的组合" PassWordStrenth="30">*</cv:PasswordStrenthValidator>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    </form>
</body>
</html>
