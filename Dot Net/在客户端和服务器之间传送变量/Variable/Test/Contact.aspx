<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<%@ Register Assembly="Variable" Namespace="LUCC" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Variable示例：通讯录管理</title>

	<script type="text/javascript" language="javascript">
	</script>
	
	<style type="text/css">
	.tdcss
	{
		padding-right: 4px; 
		padding-left: 4px; 
		padding-bottom: 4px;
		padding-top: 4px;
		height:27px;
		border-right: #000000 1px solid; 
		border-bottom: #000000 1px solid
	}
	</style>

</head>
<body>
	<form id="form1" runat="server">
		<div name='div1' id='div1'>
			<table name="table1" id="table1" style="border-top: #000000 1px solid; border-left: #000000 1px solid; font-size: 12px; font-family: 宋体; width: 600px;" cellpadding="0" cellspacing="0">
				<tr>
					<td style="background-color: gainsboro; font-weight: bold; font-size: 16px;" class="tdcss">
						姓名</td>
					<td style="background-color: gainsboro; font-weight: bold; font-size: 16px;" class="tdcss">
						电话</td>
					<td style="background-color: gainsboro; font-weight: bold; font-size: 16px;" class="tdcss">
						E-mail</td>
					<td style="background-color: gainsboro; font-weight: bold; font-size: 16px;" class="tdcss">
					</td>
				</tr>
				<tr>
					<td style="background-color: gainsboro;" class="tdcss">
						<input id="txtColumn1" type="text" /></td>
					<td style="background-color: gainsboro;" class="tdcss">
						<input id="txtColumn2" type="text" /></td>
					<td style="background-color: gainsboro;" class="tdcss">
						<input id="txtColumn3" type="text" /></td>
					<td style="background-color: gainsboro" class="tdcss">
						<input id="Button2" style="width: 65px; height: 30px" type="button" value="添加" language="javascript" onclick="return addRow()" /></td>
				</tr>
			</table>
			<br />
			<div style="width: 600px; height: 22px;">
				挂起的操作：</div>
			<select id="list1" name="list1" size="16" style="width: 600px; font-size: 12px; font-family: 宋体; height: 183px;">
			</select>
			<br />
			<br />
			<input id="Button3" style="width: 194px; height: 29px" type="button" value="撤销到选中的操作" language="javascript" onclick="return btnUndo_onclick()" />&nbsp;
			<asp:Button ID="Button1" runat="server" Text="保存更新" OnClick="Button1_Click" Height="29px"
				Width="127px" />&nbsp;<br />
			<cc1:Variable ID="MyTable" runat="server">
			</cc1:Variable>
		</div>

		<script type="text/javascript" language="javascript">
		
		//在MyTable添加新记录
		function addRow() 
		{
			row={
					"Name":document.getElementById('txtColumn1').value,
					"Tel":document.getElementById('txtColumn2').value,
					"Mail":document.getElementById('txtColumn3').value
				}
			msg='新增行:('+row.Name+','+row.Tel+','+row.Mail+')'
			addHistory(msg,MyTable)
			MyTable.Rows.push(row)
			displayRows()
		}
		
		//删除记录
		function deleteRow(index) 
		{
			row=MyTable.Rows[index]
			msg='删除行:('+row.Name+','+row.Tel+','+row.Mail+')'
			addHistory(msg,MyTable)
			MyTable.Rows.splice(index,1)
			displayRows()
		}
		
		//显示MyTable中保存的记录
		function displayRows()
		{
			var_table1=document.getElementById('table1')
			while(var_table1.rows.length>2)
			{
				var_table1.deleteRow(1)
			}
			for(i in MyTable.Rows)
			{
				row=var_table1.insertRow(var_table1.rows.length-1)
				cell=row.insertCell(-1)
				cell.className='tdcss'
				cell.innerHTML=MyTable.Rows[i]["Name"]
				cell=row.insertCell(-1)
				cell.className='tdcss'
				cell.innerHTML=MyTable.Rows[i]["Tel"]
				cell=row.insertCell(-1)
				cell.className='tdcss'
				cell.innerHTML=MyTable.Rows[i]["Mail"]
				cell=row.insertCell(-1)
				cell.className='tdcss'
				cell.innerHTML='<input style="width: 65px; height: 30px" type="button" value="删除" onclick="return deleteRow('+i+')" />'
			}
		}
		
		displayRows()
		
		var MyTable_History=new Array()
		
		function btnUndo_onclick()
		{
			var_list1=document.getElementById('list1')
			if(var_list1.value!='')
			{
				index=parseInt(var_list1.value)
				MyTable=cloneVar(MyTable_History[index])
				MyTable_History.splice(index)
				var_list1.options.length=index
				displayRows()
			}
			else
			{
				alert('请在挂起操作中选择一个还原点！')
			}
		}
		
		function addHistory(msg,myTab)
		{
			var_list1=document.getElementById('list1')
			value=var_list1.options.length
			var_list1.options.add(new Option(msg,value))
			MyTable_History.push(cloneVar(myTab))
		}

		</script>

	</form>
</body>
</html>
