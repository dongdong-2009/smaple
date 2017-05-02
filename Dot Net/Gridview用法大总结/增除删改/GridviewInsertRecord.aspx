<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewInsertRecord.aspx.cs" Inherits="增除删改_GridviewInsertRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Insert Record</title>
    <link rel="stylesheet" href="~/CSS/Gridview.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" ShowFooter="true" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px" AllowSorting="True">
          <Columns>
              <asp:TemplateField HeaderText="账号">
                  <ControlStyle Width="100px" />
                  <ItemTemplate>
                      <asp:Label ID="lbID" runat="server" Text='<%# Bind("EmpID") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                      <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                  </FooterTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="姓名">
                  <ControlStyle Width="100px" />
                  <ItemTemplate>
                      <asp:Label ID="lbRealName" runat="server" Text='<%# Bind("EmpRealName") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                      <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
                  </FooterTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="性别">
                  <ItemTemplate>
                      <asp:Label ID="lbSex" runat="server" Text='<%# Bind("EmpSex") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                      <asp:DropDownList ID="ddlSex" runat="server">
                         <asp:ListItem Value="男">男</asp:ListItem>
                         <asp:ListItem Value="女">女</asp:ListItem>
                      </asp:DropDownList>
                  </FooterTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="住址">
                  <ControlStyle Width="200px" />
                  <ItemTemplate>
                      <asp:Label ID="lbAddress" runat="server" Text='<%# Bind("EmpAddress") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                      <asp:TextBox ID="txtAddress" runat="server" Width="80px"></asp:TextBox>
                      <asp:Button ID="btnAdd" runat="server" Text="添 加" OnClick="btnAdd_Click" />
                      <asp:Button ID="btnCancel" runat="server" Text="取 消" OnClick="btnCancel_Click" />
                  </FooterTemplate>
              </asp:TemplateField>
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        &nbsp;<asp:Button ID="showAdd" runat="server" Text="添 加 记 录" Width="367px" OnClick="showAdd_Click" /></div>
    </form>
</body>
</html>
