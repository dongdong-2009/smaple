<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxCallBack.aspx.cs" Inherits="AjaxCallBack" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add a user using Web Services and Ajax</title>
    <script type="text/javascript">
    
        // Callback function 
        function SucceededCallback(CallBackResult, eventArgs)
        {
                //Inform the user
                document.getElementById("ResultsSpan").innerHTML = CallBackResult;
                //UserAdded
                window.opener.UserAddedEvent(CallBackResult);

        }
        
        //Adds the user
        function AddUser()
        {
            CallBacks.WSUsers.AddUser(document.getElementById("txtName").value,document.getElementById("txtAge").value,SucceededCallback);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        User Name
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        Age &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />
      <br />
      <button type="Button" onclick="AddUser();">Add</button>
      <br />
      <br />
      <span id="ResultsSpan" runat="server"></span>
    </div>
    </form>
</body>
</html>
