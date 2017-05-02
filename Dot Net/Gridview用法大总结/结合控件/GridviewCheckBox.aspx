<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewCheckBox.aspx.cs" Inherits="GridiewCheckBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview Checkbox</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="549px">
          <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpID" HeaderText="账号" />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名" />
            <asp:BoundField DataField="EmpAddress" HeaderText="住址" />
            <asp:BoundField DataField="EmpZipCode" HeaderText="邮编" />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged"
            Text="全选" AutoPostBack="True" />
        <asp:Button ID="Button1" runat="server" Height="20px" Text="删　除" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Height="20px" Text="取　消" OnClick="Button2_Click" /></div>
    </form>
</body>
</html>
