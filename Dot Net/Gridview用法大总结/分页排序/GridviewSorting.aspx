<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewSorting.aspx.cs" Inherits="Sorting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview Sorting</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px" OnSorting="GridView1_Sorting" AllowSorting="True">
          <Columns>
            <asp:BoundField DataField="EmpID" HeaderText="账号" SortExpression="EmpID" />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名"  SortExpression="EmpRealName"/>
            <asp:BoundField DataField="EmpSex" HeaderText="性别"  SortExpression="EmpSex" />
            <asp:BoundField DataField="EmpAddress" HeaderText="住址" SortExpression="EmpAddress" />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
