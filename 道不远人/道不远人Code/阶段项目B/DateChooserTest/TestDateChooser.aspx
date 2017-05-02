<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDateChooser.aspx.cs" Inherits="TestDateChooser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        body{
            font-size:9px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <datechooser:DateChooser ID="DateChooser1" runat="server" AutoPostBack="true" OnSelectedDateChanged="DateChooser1_SelectedDateChanged"  >
        </datechooser:DateChooser>
        <br />
       </div> <datechooser:DateChooser ID="DateChooser2" runat="server" MaxDate="2010-12-31" MinDate="2007-05-17" DateFormat="yyyy-MM-dd" />
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
