<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="Transparent" BorderColor="Black" DataKeyNames="ID"
            DataSourceID="AccessDataSource1" OnRowDataBound="GridView1_RowDataBound" Width="682px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID">
                    <ItemStyle Width="30px" />
                    <ControlStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmpID" HeaderText="昵称" SortExpression="EmpID" ReadOnly="true">
                    <ItemStyle Width="50px" />
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmpRealName" HeaderText="姓名" SortExpression="EmpRealName">
                    <ItemStyle Width="50px" />
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmpSex" HeaderText="性别" SortExpression="EmpSex">
                    <ItemStyle Width="30px" />
                    <ControlStyle Width="30px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="住址" SortExpression="EmpAddress">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EmpAddress") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmpAddress").ToString().Length>4?Eval("EmpAddress").ToString().Substring(0,4)+"...":Eval("EmpAddress").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="70px" />
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:BoundField DataField="EmpZipCode" HeaderText="邮编" SortExpression="EmpZipCode" NullDisplayText="暂无资料">
                    <ItemStyle Width="60px" />
                    <ControlStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmpBirthday" HeaderText="生日" HtmlEncode="False" SortExpression="EmpBirthday" DataFormatString="{0:d}">
                    <ItemStyle Width="80px" />
                    <ControlStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmpSalary" DataFormatString="{0:c}" HeaderText="薪水" HtmlEncode="False"
                    SortExpression="EmpSalary">
                    <ItemStyle Width="80px" />
                    <ControlStyle Width="80px" />
                </asp:BoundField>
                <asp:CommandField HeaderText="编辑" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
                    <ItemStyle Width="80px" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="发送邮件">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "mailto:"+Eval("EmpEmail") %>' Text='<%# Eval("EmpEmail") %>' ImageUrl='<%# "~/Images/Email.gif" %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="详情">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "Details.aspx?ID="+Eval("ID") %>'
                            Text='<%# "Details" %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" Height="19px" />
            <PagerStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle Height="19px" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Example.mdb"
            DeleteCommand="DELETE FROM [Employee] WHERE [ID] = ?" InsertCommand="INSERT INTO [Employee] ([ID], [EmpID], [EmpPwd], [EmpEmail], [EmpRealName], [EmpSex], [EmpAddress], [EmpZipCode], [EmpBirthday], [EmpSalary]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            SelectCommand="SELECT * FROM [Employee]" UpdateCommand="UPDATE [Employee] SET [EmpID] = ?, [EmpPwd] = ?, [EmpEmail] = ?, [EmpRealName] = ?, [EmpSex] = ?, [EmpAddress] = ?, [EmpZipCode] = ?, [EmpBirthday] = ?, [EmpSalary] = ? WHERE [ID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="EmpID" Type="String" />
                <asp:Parameter Name="EmpPwd" Type="String" />
                <asp:Parameter Name="EmpEmail" Type="String" />
                <asp:Parameter Name="EmpRealName" Type="String" />
                <asp:Parameter Name="EmpSex" Type="String" />
                <asp:Parameter Name="EmpAddress" Type="String" />
                <asp:Parameter Name="EmpZipCode" Type="String" />
                <asp:Parameter Name="EmpBirthday" Type="DateTime" />
                <asp:Parameter Name="EmpSalary" Type="Decimal" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="EmpID" Type="String" />
                <asp:Parameter Name="EmpPwd" Type="String" />
                <asp:Parameter Name="EmpEmail" Type="String" />
                <asp:Parameter Name="EmpRealName" Type="String" />
                <asp:Parameter Name="EmpSex" Type="String" />
                <asp:Parameter Name="EmpAddress" Type="String" />
                <asp:Parameter Name="EmpZipCode" Type="String" />
                <asp:Parameter Name="EmpBirthday" Type="DateTime" />
                <asp:Parameter Name="EmpSalary" Type="Decimal" />
            </InsertParameters>
        </asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
