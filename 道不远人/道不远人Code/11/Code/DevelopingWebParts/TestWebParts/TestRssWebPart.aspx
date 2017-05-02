<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestRssWebPart.aspx.cs" Inherits="TestRssWebPart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        ul.RssWebPartList 
        {
            margin:2px;
            overflow:hidden;
        }
        .RssWebPartList li
        {
            height:1.3em;
            overflow:hidden;
            line-height:1.3em;
            list-style-type:none;
            list-style-position:outside;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:WebPartManager ID="WebPartManager1" runat="server">
            </asp:WebPartManager>
        </div>
        <asp:WebPartZone ID="WebPartZone1" runat="server" Width="314px">
            <ZoneTemplate>
                <wpl:RssWebPart runat="server" ID="cnblogs" RssUrl="http://www.cnblogs.com/rss" MaxItems="5" />
                <wpl:RssWebPart runat="server" ID="life" RssUrl="http://www.cnblogs.com/life/rss"
                    MaxItems="5" />
                <wpl:RssWebPart runat="server" ID="beginner" RssUrl="http://www.cnblogs.com/beginner/rss"
                    MaxItems="5" />
            </ZoneTemplate>
        </asp:WebPartZone>
    </form>
</body>
</html>
