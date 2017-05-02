<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDragDropCatalogZone.aspx.cs"
    Inherits="TestDragDropCatalogZone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .column
        {
            width:320px;
            border:solid 1px black;
            float:left;
            padding:2px;
            margin-right:3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
        </asp:Menu>
        <div class="column">
            <wpl:RssWebPartZone ID="RssWebPartZone1" runat="server">
            </wpl:RssWebPartZone>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ResetPersonalizationState" />
        </div>
        <div class="column">
            <wpl:DragDropCatalogZone ID="catalogZone1" runat="server">
                <ZoneTemplate>
                    <wpl:OPMLCatalogPart runat="server" OPMLUrl="http://www.cnblogs.com/CatalogOpml.aspx"
                        ID="opml1" />
                </ZoneTemplate>
            </wpl:DragDropCatalogZone>
        </div>
    </form>
</body>
</html>
