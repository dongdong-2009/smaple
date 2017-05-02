<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  CodeFile="TestEnablePageDataList.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DataBoundControls" Namespace="DataBoundControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:EnablePageDataList ID="EnablePageDataList1" runat="server" AllowPaging="True" DataKeyField="ProductID" DataSourceID="ObjectDataSource1" OnPreRender="EnablePageDataList1_PreRender">
            <ItemTemplate>
                ProductName:<asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label><br />
                UnitPrice:<asp:Label ID="Label2" runat="server" Text='<%# Eval("UnitPrice","{0:c}") %>'></asp:Label>
            </ItemTemplate>
        </cc1:EnablePageDataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetData" TypeName="NorthWindTableAdapters.ProductsTableAdapter"
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ProductID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="QuantityPerUnit" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
                <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
                <asp:Parameter Name="ReorderLevel" Type="Int16" />
                <asp:Parameter Name="Discontinued" Type="Boolean" />
                <asp:Parameter Name="Original_ProductID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="QuantityPerUnit" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
                <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
                <asp:Parameter Name="ReorderLevel" Type="Int16" />
                <asp:Parameter Name="Discontinued" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="btnFirst" runat="server" OnClick="btnFirst_Click" Text="<<First" Enabled="False" />
        <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text="<Prev" Enabled="False" />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next>" />
        <asp:Button ID="btnLast" runat="server" OnClick="btnLast_Click" Text="Last>>" /></div>
    </form>
</body>
</html>
