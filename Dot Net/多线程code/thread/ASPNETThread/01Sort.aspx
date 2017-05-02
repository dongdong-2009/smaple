<%@ Page language="c#" Codebehind="01Sort.aspx.cs" AutoEventWireup="false" Inherits="ASPNETThread.SortPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Sort</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Sort" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 119px; POSITION: absolute; TOP: 38px" runat="server">数组大小</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 324px; POSITION: absolute; TOP: 40px" runat="server">线程个数</asp:Label>
			<asp:DropDownList id="ddlNum" style="Z-INDEX: 103; LEFT: 123px; POSITION: absolute; TOP: 84px" runat="server" Width="115px">
				<asp:ListItem Value="500">500</asp:ListItem>
				<asp:ListItem Value="700">700</asp:ListItem>
				<asp:ListItem Value="800">800</asp:ListItem>
				<asp:ListItem Value="1000">1000</asp:ListItem>
				<asp:ListItem Value="1500">1500</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList id="ddlThreadNum" style="Z-INDEX: 104; LEFT: 275px; POSITION: absolute; TOP: 82px" runat="server" Width="141px">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
			</asp:DropDownList>
			<asp:TextBox id="tbOut" style="Z-INDEX: 105; LEFT: 117px; POSITION: absolute; TOP: 137px" runat="server" TextMode="MultiLine" Width="410px" Height="189px" BackColor="DeepSkyBlue"></asp:TextBox>
			<asp:TextBox id="tbResult" style="Z-INDEX: 106; LEFT: 119px; POSITION: absolute; TOP: 372px" runat="server" TextMode="MultiLine" Width="333px" Height="126px" BackColor="#80FF80"></asp:TextBox>
			<asp:Label id="lbMsg" style="Z-INDEX: 107; LEFT: 122px; POSITION: absolute; TOP: 518px" runat="server" Width="113px"></asp:Label>
			<asp:Button id="btnSort" style="Z-INDEX: 108; LEFT: 461px; POSITION: absolute; TOP: 83px" runat="server" Text="排序" Width="62px"></asp:Button>
			<asp:Button id="btnClearOut" style="Z-INDEX: 109; LEFT: 471px; POSITION: absolute; TOP: 379px" runat="server" Text="清空" Width="60px" BackColor="DeepSkyBlue"></asp:Button>
			<asp:Button id="btnClearTime" style="Z-INDEX: 110; LEFT: 473px; POSITION: absolute; TOP: 455px" runat="server" Text="清空" Width="60px" BackColor="#80FF80"></asp:Button></form>
	</body>
</HTML>
