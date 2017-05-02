<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewInbuidDropDownList.aspx.cs" Inherits="GridviewInbuidDropDownList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Inbuid DropDownList</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False" EmptyDataText="NoDataToDisplay!"   Font-Size="12px" Width="549px">
          <Columns>
            <asp:BoundField DataField="CategoryID" HeaderText="分类编号" />
            <asp:BoundField DataField="CategoryName" HeaderText="分类名称" />
            <asp:TemplateField HeaderText="产品">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>           
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
          <RowStyle HorizontalAlign="Center" />
          <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
