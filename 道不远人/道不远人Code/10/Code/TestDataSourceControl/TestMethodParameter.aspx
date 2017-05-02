<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestMethodParameter.aspx.cs" Inherits="TestMethodParameter" %>
<%--<%@ Import Namespace="DataSourceControls" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" ReadOnly="True"
            SortExpression="CategoryName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
    SelectCommand="select ProductName, (select CategoryName from Categories where CategoryID = Products.CategoryID) as CategoryName, UnitPrice from Products where CategoryID = @CategoryID">
    <SelectParameters>
        <ds:MethodParameter Name="CategoryID" MethodName="GetCategoryID" />
    </SelectParameters>
</asp:SqlDataSource>
        
    </div>
    </form>
</body>
</html>
