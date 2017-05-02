<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestHelpMode.aspx.cs" Inherits="TestHelpMode" %>

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
        .wideColumn
        {
            width:400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <wpl:HelpModeWebPartManager runat="server" ID="manager1" />
        <div>
            <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
            </asp:Menu>
            <div class="column">
                <wpl:RssWebPartZone ID="RssWebPartZone1" runat="server">
                </wpl:RssWebPartZone>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ResetPersonalizationState" />
            </div>
            <div class="column">
                <wpl:HelpZone runat="server" ID="hz1" HelpMessage="This is a custom webpart zone.">
                </wpl:HelpZone>
            </div>
            <div class="column wideColumn">
                <wpl:GridViewCatalogZone ID="catalogZone1" runat="server">
                    <ZoneTemplate>
                        <wpl:OPMLCatalogPart ID="opml1" runat="server" OPMLUrl="http://www.cnblogs.com/CatalogOpml.aspx" />
                        <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
                    </ZoneTemplate>
                </wpl:GridViewCatalogZone>
            </div>
        </div>
    </form>
</body>
</html>
