<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="PostBackControls" Namespace="PostBackControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:AutoFlexTextArea ID="AutoFlexTextArea1" runat="server" OnTextChanged="AutoFlexTextArea1_TextChanged">Hello world/,.&lt;&gt;</cc1:AutoFlexTextArea>
        <asp:Button ID="Button1" runat="server" Text="Button" /></div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;
        <br />
        <br />
        <cc1:NumericUpDown ID="NumericUpDown1" runat="server" OnClick="NumericUpDown1_Click" Step="10" Value="10" />
        &nbsp; &nbsp;<cc1:CompositeNumericUpDown ID="CompositeNumericUpDown1" runat="server" BorderColor="Red" OnClick="CompositeNumericUpDown1_Click" Step="10" Value="1000">
            <UpButtonStyle BorderColor="Peru" BorderStyle="Inset" BorderWidth="1px" Height="0.5em"
                Position="Absolute" />
            <DownButtonStyle BorderColor="Blue" BorderStyle="Outset" BorderWidth="1px" Height="0.5em"
                Position="Absolute" />
            <InputStyle BorderColor="White" BorderWidth="0px" Height="1em" Position="Absolute"
                Width="80px" />
        </cc1:CompositeNumericUpDown>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;<br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="更新"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
<table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse:collapse;">
	<tr>
		<th scope="col">&nbsp;</th><th scope="col">&nbsp;</th><th scope="col">Item</th>
	</tr><tr>
		<td>
                    <a id="GridView1_ctl02_LinkButton1" href="javascript:__doPostBack('GridView1$ctl02$LinkButton1','')">编辑</a>
                </td><td>
                    <a id="GridView1_ctl02_LinkButton2" href="javascript:__doPostBack('GridView1$ctl02$LinkButton2','')">删除</a>
                </td><td>1</td>
	</tr><tr>
		<td>
                    <a id="GridView1_ctl03_LinkButton1" href="javascript:__doPostBack('GridView1$ctl03$LinkButton1','')">编辑</a>
                </td><td>
                    <a id="GridView1_ctl03_LinkButton2" href="javascript:__doPostBack('GridView1$ctl03$LinkButton2','')">删除</a>
                </td><td>2</td>
	</tr><tr>
		<td>
                    <a id="GridView1_ctl04_LinkButton1" href="javascript:__doPostBack('GridView1$ctl04$LinkButton1','')">编辑</a>
                </td><td>
                    <a id="GridView1_ctl04_LinkButton2" href="javascript:__doPostBack('GridView1$ctl04$LinkButton2','')">删除</a>
                </td><td>3</td>
	</tr><tr>
		<td>
                    <a id="GridView1_ctl05_LinkButton1" href="javascript:__doPostBack('GridView1$ctl05$LinkButton1','')">编辑</a>
                </td><td>
                    <a id="GridView1_ctl05_LinkButton2" href="javascript:__doPostBack('GridView1$ctl05$LinkButton2','')">删除</a>
                </td><td>4</td>
	</tr>
</table>
    </form>
</body>
</html>
