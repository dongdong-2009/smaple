<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewBackgroundColor.aspx.cs" Inherits="设置属性_GridviewBackgroundColor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview------Set BackgroundColor</title>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
		//把事件放在onload里，
		//使用&lt;%=%>方式输出GridView的ID是因为某些情况下（如使用了MasterPage）会造成HTML中ID的变化
		//颜色值推荐使用Hex，如 #f00 或 #ff0000
		window.onload = function(){
			GridViewColor("<%=GridView1.ClientID%>","#fff","#eee","#6df","#fd6");
		}
		
		//参数依次为（后两个如果指定为空值，则不会发生相应的事件）：
		//GridView ID, 正常行背景色,交替行背景色,鼠标指向行背景色,鼠标点击后背景色
		function GridViewColor(GridViewId, NormalColor, AlterColor, HoverColor, SelectColor){
			//获取所有要控制的行
			var AllRows = document.getElementById(GridViewId).getElementsByTagName("tr");
			
			//设置每一行的背景色和事件，循环从1开始而非0，可以避开表头那一行
			for(var i=1; i<AllRows.length; i++){
				//设定本行默认的背景色
				AllRows[i].style.background = i%2==0?NormalColor:AlterColor;
				
				//如果指定了鼠标指向的背景色，则添加onmouseover/onmouseout事件
				//处于选中状态的行发生这两个事件时不改变颜色
				if(HoverColor != ""){
					AllRows[i].onmouseover = function(){if(!this.selected)this.style.background = HoverColor;}
					if(i%2 == 0){
						AllRows[i].onmouseout = function(){if(!this.selected)this.style.background = NormalColor;}
					}
					else{
						AllRows[i].onmouseout = function(){if(!this.selected)this.style.background = AlterColor;}
					}
				}
				
				//如果指定了鼠标点击的背景色，则添加onclick事件
				//在事件响应中修改被点击行的选中状态
				if(SelectColor != ""){
					AllRows[i].onclick = function(){
						this.style.background = this.style.background==SelectColor?HoverColor:SelectColor;
						this.selected = !this.selected;
					}
				}
			}
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  AllowPaging="True" runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="549px" OnPageIndexChanging="GridView1_PageIndexChanging">
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
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
