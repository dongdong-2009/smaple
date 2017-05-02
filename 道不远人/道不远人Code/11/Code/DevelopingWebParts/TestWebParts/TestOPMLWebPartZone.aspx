<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestOPMLWebPartZone.aspx.cs" Inherits="TestOPMLWebPartZone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:WebPartManager ID="WebPartManager1" runat="server" Personalization-Enabled="true" Personalization-InitialScope="user">
        </asp:WebPartManager>
        <asp:Menu id="Menu1" runat="server" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick">
        </asp:Menu>
    <div>    
        <wpl:OPMLWebPartZone ID="OPMLWebPartZone1" RepeatColumns="4" runat="server" OPMLUrl="http://www.cnblogs.com/CatalogOpml.aspx" LayoutOrientation="Horizontal">
        </wpl:OPMLWebPartZone>
    </div>
    </form>
</body>
</html>
