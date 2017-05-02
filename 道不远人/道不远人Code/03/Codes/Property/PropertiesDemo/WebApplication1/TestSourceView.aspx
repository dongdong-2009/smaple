<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TestSourceView.aspx.cs"
    Inherits="WebApplication1.TestSourceView" %>

<%@ Register Assembly="ControlProperties" Namespace="ControlProperties" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
                <cc1:SourceView ID="SourceView1" runat="server">
<script type="text/javascript">
    function pageLoad(sender,args){
        var pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
        pageRequestManager.add_beginRequest(pageRequestManager_onBeginRequest);
    }
</script>
                </cc1:SourceView>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></div>
        &nbsp;

    </form>
</body>
</html>
