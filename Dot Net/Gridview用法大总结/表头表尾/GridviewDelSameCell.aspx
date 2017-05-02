<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewDelSameCell.aspx.cs" Inherits="表头表尾_GridviewDelSameCell" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview Del same cells</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" width="629px" OnRowCreated="GridView1_RowCreated" ShowFooter="True">
          <Columns>
            <asp:BoundField DataField="ID" HeaderText="编号" >
                <HeaderStyle Width="40px" />
                <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpID" HeaderText="账号" >
                <HeaderStyle Width="70px" />
                <ItemStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名" >
                <HeaderStyle Width="60px" />
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpSex" HeaderText="性别" >
                <HeaderStyle Width="40px" />
                <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpAddress" HeaderText="住址" >
                <HeaderStyle Width="140px" />
                <ItemStyle Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpZipCode" HeaderText="邮编" >
                <HeaderStyle Width="40px" />
                <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpBirthday" HeaderText="生日" DataFormatString="{0:d}" HtmlEncode="False" >
                <HeaderStyle Width="120px" />
                <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmpSalary" HeaderText="月薪" >
                <HeaderStyle Width="40px" />
                <ItemStyle Width="40px" />
            </asp:BoundField>
          </Columns>
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
            <HeaderStyle BackColor="Azure" Font-Bold="True" ForeColor="Black" CssClass="Freezing" Font-Size="12px" HorizontalAlign="Center"/>
            <FooterStyle BackColor="WhiteSmoke" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
