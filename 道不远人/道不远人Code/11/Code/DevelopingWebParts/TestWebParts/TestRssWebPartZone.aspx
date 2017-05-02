<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestRssWebPartZone.aspx.cs" Inherits="TestRssWebPartZone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
        </asp:Menu>
        <wpl:RssWebPartZone ID="RssWebPartZone1" runat="server">
            <ZoneTemplate>
            <wpl:RssWebPart runat="server" ID="cnblogs" RssUrl="http://weather.msn.com/RSS.aspx?wealocations=wc:CHXX0120&weadegreetype=C" MaxItems="5"/>
            <wpl:RssWebPart runat="server" ID="life" RssUrl="http://weather.msn.com/RSS.aspx?wealocations=wc:CHXX0008&weadegreetype=C" MaxItems="5"/>
            </ZoneTemplate>
        </wpl:RssWebPartZone>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ResetPersonalizationState" />
    </form>
</body>
</html>
