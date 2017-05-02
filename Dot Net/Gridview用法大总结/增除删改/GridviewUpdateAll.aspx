<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewUpdateAll.aspx.cs" Inherits="增除删改_GridviewUpdateAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview update all</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1"  BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px" AllowSorting="True">
          <Columns>
              <asp:TemplateField HeaderText="账号">
                  <ControlStyle Width="100px" />
                  <ItemTemplate>
                      <asp:TextBox ID="txtID" runat="server" Text='<%#Eval("EmpID") %>' ></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="姓名">
                  <ControlStyle Width="100px" />
                  <ItemTemplate>
                      <asp:TextBox ID="txtRealName" runat="server" Text='<%#Eval("EmpRealName") %>'></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="性别">
                  <ItemTemplate>
                      <asp:DropDownList ID="ddlSex" runat="server" />
                      <asp:HiddenField ID="hdfSex" runat="server" Value='<%# Eval("EmpSex") %>' />
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="住址">
                  <ControlStyle Width="200px" />
                  <ItemTemplate>
                      <asp:TextBox ID="txtAddress" runat="server" Width="80px" Text='<%#Bind("EmpAddress") %>'></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        &nbsp;<asp:Button ID="update" runat="server" Text="Update all records" Width="367px" OnClick="update_Click"  /></div>
    </form>
</body>
</html>
