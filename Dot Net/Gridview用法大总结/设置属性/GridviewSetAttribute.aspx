<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewSetAttribute.aspx.cs" Inherits="Attribute" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview------Set Attribute</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  AllowPaging="True" runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="549px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
          <Columns>
            <asp:BoundField DataField="ID" HeaderText="编号" />
            <asp:BoundField DataField="EmpID" HeaderText="账号" />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名" />
            <asp:BoundField DataField="EmpSex" HeaderText="性别" />
            <asp:BoundField DataField="EmpAddress" HeaderText="住址" />
            <asp:BoundField DataField="EmpZipCode" HeaderText="邮编" />
            <asp:BoundField DataField="EmpBirthday" HeaderText="生日" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" />
            <asp:BoundField DataField="EmpSalary" HeaderText="薪水" DataFormatString="{0:c}" HtmlEncode="False" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
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
