<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestToolTipsBehavior.aspx.cs"
    Inherits="TestToolTipsBehavior" %>

<%@ Register Assembly="System.Web.Extensions"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AJAXControlLibrary" Namespace="AJAXControlLibrary" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">  
        #Monitor{
            position:absolute;
            top:150px;
            width:150px;
            height:30px;
            padding:6px;
            color:White;
            background-color:Blue;
            left:10px;
        }
    </style>
    <script type="text/javascript">
        function onToolTipsShow(){
            var content;
            if(event.srcElement){
                content = event.srcElement.firstChild.nodeValue;
            }
            else if(event.target){
                content = event.target.firstNode.innerText;
            }
            $get('Monitor').innerText = content + ' has overed';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Microsoft"></asp:Label>
            is not only a software corporation.
            <cc1:ToolTipsExtender ID="ToolTipsExtender1" runat="server" TargetControlID="Label1"
                ToolTipsContent="Windows,Office,VS,Games,Hardwares" ClientShowHandler="onToolTipsShow">
            </cc1:ToolTipsExtender>
            <div id="Monitor"></div>
        </div>
    </form>
</body>
</html>
