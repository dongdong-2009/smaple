<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestField.aspx.cs" Inherits="TestField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
                <dc:RequiredBoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName">
                </dc:RequiredBoundField>
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <dc:TowStateField DataField="Discontinued" TrueText="无货" FalseText="有货" HeaderText="货存情况" /> 
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT ProductID, ProductName, UnitPrice,Discontinued FROM Products" UpdateCommand="update Products set ProductName = @ProductName,UnitPrice = @UnitPrice,Discontinued = @Discontinued where ProductID = @ProductID">
            <UpdateParameters>
                <asp:Parameter Name="ProductName" />
                <asp:Parameter Name="UnitPrice" />
                <asp:Parameter Name="original_ProductID" />
                <asp:Parameter Name="Discontinued" />
            </UpdateParameters>
        </asp:SqlDataSource>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
