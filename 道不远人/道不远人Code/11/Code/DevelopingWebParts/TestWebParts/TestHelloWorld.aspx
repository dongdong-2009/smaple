<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TestHelloWorld.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:WebPartManager ID="WebPartManager1" runat="server" >
</asp:WebPartManager>
<br />
<asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
</asp:Menu>
<asp:WebPartZone ID="WebPartZone1" runat="server">
<ZoneTemplate>
    <wpl:HelloWorldPart runat="server" ID="hwp1" TitleIconImageUrl="testpart.ico" AuthorizationFilter="Administrators" Title="This is a test Part" UserName="Bill"  />
    <wpl:HelloWorldPart runat="server" ID="HelloWorldPart1" TitleIconImageUrl="testpart.ico" AuthorizationFilter="Administrators" Title="This is a test Part" UserName="Robert"  />
</ZoneTemplate>
</asp:WebPartZone>
<asp:CatalogZone ID="CatalogZone1" runat="server">
    <ZoneTemplate>
        <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
    </ZoneTemplate>
</asp:CatalogZone>
    </div>
    </form>
</body>
</html>
