<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Variable_Test.aspx.cs" Inherits="Variable_Test" %>

<%@ Register Assembly="Variable" Namespace="LUCC" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>无标题页</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
			<cc1:Variable ID="MyVariable" runat="server">
			</cc1:Variable>

			<script type="text/javascript" language="javascript">
			
			//将MyVariable的值修改为数组
			MyVariable=new Array('Hello','World')
			
			</script>

		</div>
	</form>
</body>
</html>
