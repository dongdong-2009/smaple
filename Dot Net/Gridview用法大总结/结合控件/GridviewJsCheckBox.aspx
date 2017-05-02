<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridviewJsCheckBox.aspx.cs" Inherits="结合控件_GridviewJsCheckBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gridview------Check Box</title>
    <script language="javascript" type="text/javascript">
    //先获取所有的Checkbox
    var chkList = document.getElementsByName("CheckBox1");
	window.onload = function()
	{
		//为所有checkbox添加onclick事件处理，以自动更新“已选择的项”
		for(var i=0; i<chkList.length; i++)
		{
			chkList[i].onclick = chkClick;
		}
	}
	//checkbox的onclick事件，用于更新“已选择的项”
	function chkClick(){
		var checkedList = "";
		//获取所有被选中的项
		for(var i=0; i<chkList.length; i++){
			if(chkList[i].checked)
				checkedList += chkList[i].value + ",";
		}
		//把选中项的列表显示到“已选择的项”中，substring在这里是为了去除最后一个逗号
		document.getElementById("HiddenField1").value = checkedList.substring(0,checkedList.length-1);
	}
    function checkAll()
    {
        var chkall=document.getElementById("CheckBoxAll");
        if(chkall.checked)
        {
            var checkedList = "";
            for(var i=0;i<chkList.length;i++)
            {
                  chkList[i].checked=true;
                  checkedList += chkList[i].value + ",";
            }
            document.getElementById("HiddenField1").value = checkedList.substring(0,checkedList.length-1);
        }
        else
        {
            for(var i=0;i<chkList.length;i++)
                  chkList[i].checked=false;
            document.getElementById("HiddenField1").value="";
        }
    }
    </script>
    <link href="~/CSS/Gridview.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div id="container">
        <asp:GridView ID="GridView1" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  AllowPaging="True" runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="549px" OnPageIndexChanging="GridView1_PageIndexChanging">
          <Columns>
              <asp:TemplateField HeaderText="编号">
                  <ItemTemplate>
                      <input name="CheckBox1" type="checkbox" value="<%#Eval("ID") %>"/>
                  </ItemTemplate>
              </asp:TemplateField>
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
        全选:<input id="CheckBoxAll"  type="checkbox" onclick="checkAll()"  />
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Height="20px" Text="删　除" OnClick="Button1_Click" Width="59px" />
    
    </div>
    </form>
</body>
</html>
