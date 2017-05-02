<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="OptimisticConcurrency.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<lv:ListView ID="lvProducts" runat="Server" DataSourceID="sdsProducts" DataKeyNames="ProductID,ProductName,UnitPrice">
<EditTemplate>
        ProductID:
    <asp:Label ID="ProductIDLabel1" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
    ProductName:
    <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>'>
    </asp:TextBox><br />
    UnitPrice:
    <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>'>
    </asp:TextBox><br />
    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
        Text="更新">
    </asp:LinkButton>
    <asp:LinkButton ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
        Text="取消">
    </asp:LinkButton>
    </EditTemplate>
    
    <ItemTemplate>
        ProductID:
        <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
        ProductName:
        <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>'>
        </asp:Label><br />
        UnitPrice:
        <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label><br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="编辑">
        </asp:LinkButton>
    </ItemTemplate>
</lv:ListView>
<asp:SqlDataSource ID="sdsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" OldValuesParameterFormatString="original_{0}"
    SelectCommand="select ProductID,ProductName,UnitPrice from Products" UpdateCommand="Update Products set ProductName = @ProductName,UnitPrice = @UnitPrice where ProductID= @original_ProductID and ProductName = @original_Productname and UnitPrice = @original_Unitprice">
    <UpdateParameters>
        <asp:Parameter Name="ProductName" />
        <asp:Parameter Name="UnitPrice" />
        <asp:Parameter Name="ProductID" />
    </UpdateParameters>
</asp:SqlDataSource>
        &nbsp;
    </div>
    </form>
</body>
</html>
