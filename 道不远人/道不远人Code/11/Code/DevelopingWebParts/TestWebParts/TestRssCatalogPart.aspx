<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestRssCatalogPart.aspx.cs"
    Inherits="TestRssCatalogPart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
        </asp:Menu>
        <div>
            <wpl:RssWebPartZone ID="RssWebPartZone1" runat="server">
            </wpl:RssWebPartZone>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ResetPersonalizationState" />
            <asp:CatalogZone ID="CatalogZone1" runat="server">
                <ZoneTemplate>
                    <wpl:OPMLCatalogPart runat="server" OPMLUrl="http://www.cnblogs.com/CatalogOpml.aspx"
                        ID="opml1" />
                </ZoneTemplate>
            </asp:CatalogZone>
        </div>
    </form>
</body>
</html>
