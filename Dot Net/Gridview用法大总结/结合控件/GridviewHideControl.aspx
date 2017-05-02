<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewHideControl.aspx.cs" Inherits="GridviewHideControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Hide Control</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function ddlChanged()
    {
       var e=event.srcElement;//获取鼠标点击的元素
       var r=e.parentElement.parentElement.rowIndex+1;//获取元素所在的行的行号
       var id='GridView1$ctl0'+r+'$txtNote';//获取TextBox的ID，由于TextBox是在Gridview里面的，所以他的
       //ID会变成这样的格式，GridView的ID加上控件所在的行号加上TextBox的ID
       var obj=document.getElementById(id);
       var index=e.selectedIndex;
       if(index==2)//如果选择的是第三项，即备注，则显示TextBox
       {
          obj.style.display='block';
          obj.select();
       }
       else //如果选择的是其他的项，即备注，则隐藏TextBox
       {
          obj.style.display='none';
       }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" AutoGenerateColumns="false"  BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server"  Font-Size="12px" width="697px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
          <Columns>
            <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="true">
                <HeaderStyle Width="40px" />
                <ItemStyle Width="40px" />
                <ControlStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="OrderID" HeaderText="订单号" ReadOnly="true" >
                <HeaderStyle Width="70px" />
                <ItemStyle Width="70px" />
                <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="CustomerName" HeaderText="客户名称" ReadOnly="true">
                <HeaderStyle Width="60px" />
                <ItemStyle Width="60px" />
                <ControlStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="OrderTime" HeaderText="下单时间" DataFormatString="{0:d}" HtmlEncode="False" ReadOnly="true">
                <HeaderStyle Width="60px" />
                <ItemStyle Width="60px" />
                <ControlStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="OrderMoney" HeaderText="金额" DataFormatString="{0:c}" HtmlEncode="False" ReadOnly="true">
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
                <ControlStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="PayType" HeaderText="付款方式" ReadOnly="true">
                <HeaderStyle Width="80px" />
                <ItemStyle Width="80px" />
                <ControlStyle Width="80px" />
            </asp:BoundField>
           
            <asp:TemplateField  HeaderText="订单状态">
                <HeaderStyle Width="80px" />
                <ItemStyle Width="80px" />
                <ControlStyle Width="80px" />
                <ItemTemplate>
                   <asp:Label ID="Lable1" runat="server" Text='<%#Bind("OrderState") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                   <asp:DropDownList ID="DDLOrderState" runat="server">
                      <asp:ListItem Value="未付款">未付款</asp:ListItem>
                      <asp:ListItem Value="已付款">已付款</asp:ListItem>
                   </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="处理状态">
                <HeaderStyle Width="80px" />
                <ItemStyle Width="80px" />
                <ControlStyle Width="80px" />
                <EditItemTemplate>
                    <asp:DropDownList ID="DDLHandled" runat="server" onchange="ddlChanged()">
                       <asp:ListItem Value="未处理">未处理</asp:ListItem>
                       <asp:ListItem Value="已处理">已处理</asp:ListItem>
                       <asp:ListItem Value="备注">备注</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtNote" runat="server" style="display:none;width:80px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblHandled" runat="server" Text='<%# Bind("HandleState") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
          </Columns>
          <RowStyle HorizontalAlign="Center" />
          <PagerStyle HorizontalAlign="Center" />
          <HeaderStyle BackColor="Azure" Font-Bold="True" ForeColor="Black" CssClass="Freezing" Font-Size="12px" HorizontalAlign="Center"/>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
