<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="GridviewNested.aspx.cs" Inherits="多层嵌套_GridviewNested" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Nested</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="ParentGridView" BorderColor="Black" OnRowDataBound="ParentGridView_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px" AllowSorting="True" OnRowEditing="ParentGridView_RowEditing" OnRowCancelingEdit="ParentGridView_RowCancelingEdit">
          <Columns>
              <asp:BoundField DataField="CategoryID" HeaderText="编号"  ReadOnly="True"/>
              <asp:BoundField DataField="CategoryName" HeaderText="类别" ReadOnly="True" />
              <asp:TemplateField HeaderText="查看详情">
                <ItemTemplate>
                    <asp:Button ID="ViewChild_Button" runat="server" Text="Details" CommandName="Edit"  />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="CancelChild_Button" runat="server" Text="Cancel" CommandName="Cancel" />
                    <asp:GridView ID="ChildGridView" runat="server"   AllowPaging="True" PageSize="3" AutoGenerateColumns="False" OnRowEditing= "ChildGridView_OnRowEditing" BorderColor="Black" OnRowDataBound="ChildGridView_RowDataBound" DataKeyNames="ProductID" DataSourceID="AccessDataSource1" Width="241px" >
                        <Columns>
                            <asp:BoundField DataField="ProductName" HeaderText="名称" ReadOnly="True" SortExpression="ProductName" />
                            <asp:TemplateField HeaderText="查看详情">
                                <ItemTemplate>
                                    <asp:Button ID="ViewGrantChild_Button" runat="server" Text="Details" CommandName="Edit"  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="CancelGrantChild_Button" runat="server" Text="Cancel" CommandName="Cancel" />
                                    <asp:GridView ID="GrantChildGridView" runat="server"   AllowPaging="True" PageSize="3" AutoGenerateColumns="False"  BorderColor="Black" OnRowDataBound="ChildGridView_RowDataBound" DataKeyNames="ID" Width="331px" DataSourceID="AccessDataSource1" >
                                        <Columns>
                                            <asp:BoundField DataField="OrderID" HeaderText="订单号" ReadOnly="true" SortExpression="OrderID" ItemStyle-Width="100px" />
                                            <asp:BoundField DataField="OrderMoney" HeaderText="金额" ReadOnly="true" SortExpression="OrderMoney" ItemStyle-Width="80px"/>
                                            <asp:BoundField DataField="OrderState" HeaderText="状态" ReadOnly="true" SortExpression="OrderState" ItemStyle-Width="80px"/>
                                        </Columns>  
                                        <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <PagerStyle HorizontalAlign="Center" />
                                    </asp:GridView>
                                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Example.mdb"
                                        SelectCommand="SELECT * FROM [Orders] WHERE ([ProductID] = ?)">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="ProductID" SessionField="sProductID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:AccessDataSource>  
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>  
                        <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Example.mdb"
                        SelectCommand="SELECT * FROM [Products] WHERE ([CategoryID] = ?)">
                        <SelectParameters>
                            <asp:SessionParameter Name="CategoryID" SessionField="sCategoryID" Type="String" />
                        </SelectParameters>
                    </asp:AccessDataSource>  
                </EditItemTemplate>
            </asp:TemplateField>
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
          <RowStyle HorizontalAlign="Center" />
          <PagerStyle HorizontalAlign="Center" />
        </asp:GridView> 
    </div>
    </form>
</body>
</html>
