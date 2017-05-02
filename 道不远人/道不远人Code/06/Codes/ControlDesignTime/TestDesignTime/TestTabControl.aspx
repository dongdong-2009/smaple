<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestTabControl.aspx.cs" Inherits="TestTabControl" %>

<%@ Register Assembly="ControlDesignTimeLabrary" Namespace="ControlDesignTimeLabrary"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc1:TabControl ID="TabControl1" runat="server" Width="406px" SelectedTabIndex="1" Height="120px">
                <cc1:TabPage ID="tab1" runat="server" Title="Tab1">
                    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </cc1:TabPage>
                <cc1:TabPage ID="NewTab" runat="server" Title="New Tab">
                    <ul>
                        <li>Tab1</li>
                        <li>Tab2</li>
                    </ul>                
                </cc1:TabPage>
                <cc1:TabPage ID="Tab3" runat="server" Title="NewTab">
                </cc1:TabPage>
                <cc1:TabPage ID="Tab4" runat="server" Title="NewTab">
                </cc1:TabPage>
            </cc1:TabControl>&nbsp;<br />
            &nbsp;</div>
        <cc1:AutoFormatTextBox ID="AutoFormatTextBox1" runat="server" BorderStyle="Solid" BorderWidth="1px" ForeColor="Red" BorderColor="Red" Columns="20" Rows="20"></cc1:AutoFormatTextBox>
        <br />
        <br />
        <br />
        <br />
        <cc1:MyTemplateControl ID="MyTemplateControl1" runat="server">
            <Template1>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </Template1>
            <Template2>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </Template2>
            <Template4>
                <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
            </Template4>
            <Template3>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </Template3>
        </cc1:MyTemplateControl>
        <br />
        <br />
        <br />
        <br />
        <cc1:RotateImage ID="RotateImage1" runat="server" ImageUrl="~/Guest.bmp" />
        <cc1:RotateImage ID="RotateImage2" runat="server" ImageUrl="~/Guest.bmp" Rotation="1" /><br />
        <cc1:RotateImage ID="RotateImage3" runat="server" ImageUrl="~/Guest.bmp" Rotation="3" />
        <cc1:RotateImage ID="RotateImage4" runat="server" ImageUrl="~/Guest.bmp" Rotation="3" />
        
    </form>
</body>
</html>
