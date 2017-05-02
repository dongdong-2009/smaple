<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewDataKeys.aspx.cs" Inherits="Keys" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DataKeys</title>
    <link href="~/CSS/Gridview.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="591px" OnRowCommand="GridView1_RowCommand" >
          <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Mobile" HeaderText="电话号码" />
            <asp:BoundField DataField="SendTime" HeaderText="发送时间" DataFormatString="{0:d}" HtmlEncode="False" />
            <asp:BoundField DataField="Title" HeaderText="标题" />
            <asp:BoundField DataField="Content" HeaderText="内容" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
              <asp:TemplateField HeaderText="删除" ShowHeader="False">
                  <ItemTemplate>
                      <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandArgument ="<%# GridView1.Rows.Count %>"  CommandName="DeleteRecord" Text="DELETE" />
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:ButtonField HeaderText="删除" Text="Del" CommandName="Del" />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged"
            Text="全选" AutoPostBack="True" />
        <asp:Button ID="Button1" runat="server" Height="20px" Text="删　除" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Height="20px" Text="取　消" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
