<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewEditUpdateDelete.aspx.cs" Inherits="EditUpdateDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview Edit Update Delete</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound" Width="561px"  Font-Size="12px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
          <Columns>
            <asp:BoundField DataField="EmpID" HeaderText="账号" />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名" />
            <asp:BoundField DataField="EmpSex" HeaderText="性别" />
            <asp:BoundField DataField="EmpAddress" HeaderText="住址" />
            <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            <asp:TemplateField HeaderText="订单编辑"> 
                <ItemTemplate> 
                   <asp:Button ID="btnEditOrder" runat="server" Text='编 辑' CommandName="EditOrder"/> 
                </ItemTemplate> 
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
