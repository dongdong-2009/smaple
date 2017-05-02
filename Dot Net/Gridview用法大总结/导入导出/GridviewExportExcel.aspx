<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewExportExcel.aspx.cs" Inherits="GridviewExcel" EnableEventValidation="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Excel</title>
    <link href="~/CSS/Gridview.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px" AllowSorting="True">
          <Columns>
            <asp:BoundField DataField="EmpID" HeaderText="编号"  />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名"  />
            <asp:BoundField DataField="EmpSex" HeaderText="性别"  />
            <asp:BoundField DataField="EmpAddress" HeaderText="住址"  />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="导 出 EXCEL 表 格" Height="34px" OnClick="Button1_Click" Width="263px" />
        <asp:Button ID="Button2" runat="server" Text="导 出 Word 文 档" Height="34px" OnClick="Button2_Click" Width="263px" /></div>
    </form>
</body>
</html>
