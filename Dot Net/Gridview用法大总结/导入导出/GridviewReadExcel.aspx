<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewReadExcel.aspx.cs" Inherits="GridviewReadExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview Excel</title>
    <link href="~/CSS/Gridview.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px" AllowSorting="True">
          <Columns>
            <asp:BoundField DataField="编号" HeaderText="编号"  />
            <asp:BoundField DataField="姓名" HeaderText="姓名"  />
            <asp:BoundField DataField="性别" HeaderText="性别"  />
            <asp:BoundField DataField="住址" HeaderText="住址"  />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="从 EXCEL 中 导 入 数 据" Height="34px" OnClick="Button1_Click" Width="326px" />
    </div>
    </form>
</body>
</html>
