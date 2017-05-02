<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestToolTipsControl.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AJAXControlLibrary" Namespace="AJAXControlLibrary" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .tooltips
        {
            max-width:150px;
            border:solid 1px blue;
            padding:4px;
            background-color:White;
            word-break:break-all;
        }
        span
        {
	        text-decoration: underline;
	        color: #000080;
	        cursor:hand;
        }
        
        #Monitor{
            position:absolute;
            top:150px;
            width:150px;
            height:30px;
            padding:6px;
            color:White;
            background-color:Blue;
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
            <a href="javascript:window.history.go(-1);" title="后退到前一页">Back</a>
            <cc1:ToolTips ID="ToolTips1" runat="server" Text="Microsoft" ClientShowHandler="onToolTipsShow">
                <PopupTemplate>
                    <div class="tooltips">
                        Please visite http://www.microsoft.com/china
                    </div>
                </PopupTemplate>
            </cc1:ToolTips>
            <div id="Monitor"></div>
        </div>
    </form>
</body>
</html>
