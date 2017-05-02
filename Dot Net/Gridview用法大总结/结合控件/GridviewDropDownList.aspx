<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewDropDownList.aspx.cs" Inherits="GridviewHtmlCheckBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview DropDownList</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False" EmptyDataText="NoDataToDisplay!" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing"  Font-Size="12px" Width="549px">
          <Columns>
            <asp:BoundField HeaderText="编号" DataField="ID" Visible="False" /> 
            <asp:TemplateField HeaderText="编号" FooterText="编号"> 
                <ItemTemplate> 
                <%# (Container.DataItemIndex+1).ToString()%> 
                </ItemTemplate> 
            </asp:TemplateField>          
            <asp:BoundField DataField="EmpID" HeaderText="账号" />
            <asp:BoundField DataField="EmpRealName" HeaderText="姓名" />
            <asp:TemplateField HeaderText="住址">
                <ItemTemplate>
                    <%# Eval("EmpAddress")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="HDFAddress" runat="server" Value='<%# Eval("EmpAddress") %>' />
                    <asp:DropDownList ID="DDLAddress" runat="server" Width="90px" />
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <%# Eval("EmpSex")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="HDFSex" runat="server" Value='<%# Eval("EmpSex") %>' />
                    <asp:DropDownList ID="DDLSex" runat="server" Width="90px" />
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
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
