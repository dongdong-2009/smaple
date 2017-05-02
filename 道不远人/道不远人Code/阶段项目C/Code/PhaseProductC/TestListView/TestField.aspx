<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestField.aspx.cs" Inherits="TestField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <lv:RequiredBoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName">
                </lv:RequiredBoundField>
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT ProductID, ProductName, UnitPrice FROM Products" UpdateCommand="update Products set ProductName = @ProductName,UnitPrice = @UnitPrice where ProductID = @ProductID">
            <UpdateParameters>
                <asp:Parameter Name="ProductName" />
                <asp:Parameter Name="UnitPrice" />
                <asp:Parameter Name="original_ProductID" />
            </UpdateParameters>
        </asp:SqlDataSource>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
