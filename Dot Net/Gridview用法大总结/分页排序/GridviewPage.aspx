<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewPage.aspx.cs" Inherits="GridviewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Page</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" ShowFooter="false" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="549px"  AllowPaging="True" >
          <Columns>
            <asp:BoundField DataField="ID" HeaderText="编号" />
            <asp:BoundField DataField="EmpID" HeaderText="账号" />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名" />
            <asp:BoundField DataField="EmpSex" HeaderText="性别" />
            <asp:BoundField DataField="EmpAddress" HeaderText="住址" />
            <asp:BoundField DataField="EmpZipCode" HeaderText="邮编" />
            <asp:BoundField DataField="EmpBirthday" HeaderText="生日" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" />
            <asp:BoundField DataField="EmpSalary" HeaderText="薪水" DataFormatString="{0:c}" HtmlEncode="False" />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
          <RowStyle HorizontalAlign="Center" />
          <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" BorderStyle="None" BorderWidth="0px" ForeColor="#330099" />
            <PagerSettings Visible="False" />
        </asp:GridView>
        <br />
        <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton> 
        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label> 
        <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton> 
跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> 
        </asp:DropDownList>页
    </div>
    </form>
</body>
</html>
