<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewHtmlRadioButtom.aspx.cs" Inherits="结合控件_GridviewHtmlRadioButtom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Html Radio Buttom</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="549px">
          <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                   <input name="MyRadioButton" type="radio" value='<%# Eval("EmpID") %>' />
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
        <asp:Button ID="Button1" runat="server" Height="20px" Text="Show" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>
