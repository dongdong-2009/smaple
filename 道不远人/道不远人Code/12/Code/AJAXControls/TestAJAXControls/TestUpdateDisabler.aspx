<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestUpdateDisabler.aspx.cs"
    Inherits="TestUpdateDisabler" %>

<%@ Register Assembly="AJAXControlLibrary" Namespace="AJAXControlLibrary" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text="本来没被禁止的输入框"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Text="本来就被禁止的输入框"></asp:TextBox>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <cc1:UpdateDisabler ID="ud1" runat="server" OnlyDisableTrigger="False" />
    </form>
</body>
</html>
