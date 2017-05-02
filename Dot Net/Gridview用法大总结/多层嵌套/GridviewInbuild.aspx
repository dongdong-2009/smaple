<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewInbuild.aspx.cs" Inherits="多层嵌套_GridviewInbuild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview Inbuild</title>
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
                    <asp:GridView ID="ChildGridView" runat="server"   AllowPaging="True" PageSize="3" AutoGenerateColumns="False"  BorderColor="Black" OnRowDataBound="ChildGridView_RowDataBound"  Width="241px" >
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="编号"  ReadOnly="True"/>
                            <asp:BoundField DataField="ProductName" HeaderText="名称" ReadOnly="True" SortExpression="ProductName" />
                        </Columns>  
                        <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
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
