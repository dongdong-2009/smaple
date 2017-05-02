<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewFrezingHeader.aspx.cs" Inherits="GridviewHeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gridview Header</title>
    <script language="javascript" type="text/javascript">
    function init()
    {
        var bodyGridView=document.getElementById("<%=GridView1.ClientID%>");
        var headGridView=bodyGridView.cloneNode(true);
        for(i=headGridView.rows.length-1;i>0;i--)
          headGridView.deleteRow(i);
        bodyGridView.deleteRow(0);//删掉数据行
        headdiv.appendChild(headGridView);//删掉表头行
    }
    window.onload=init;
    </script>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="headdiv" style="top: 16px; text-align:center; left: 152px; position: absolute; width: 629px;height: 21px;word-wrap:break-word; overflow:hidden;"><!--不需要显示表头水平滚动条-->
    </div>
    <div id="bodydiv" style="top: 33px; left: 152px; position: absolute; width: 647px;height: 300px; overflow: auto" onscroll="headdiv.scrollLeft=scrollLeft"><!--表体的水平滚动条拖动触发表头的水平滚动事件-->
        <!--Gridview中必须定义表头和表体相同的宽度-->
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" width="629px">
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
        </asp:GridView>
    </div>
    </form>
</body>
</html>
