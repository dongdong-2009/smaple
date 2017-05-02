<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientCallBack.aspx.cs" Inherits="ClientCallBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>Add a user using CallBacks</title>
  <script type="text/javascript">
  
    //Makes a Callback to the server
    function AddUser()
    {
        //Construct the argument
        //The argument MUST be a string so if you need
        //to send more than one value use custom separators
        var argument = document.getElementById("txtName").value + "|" + document.getElementById("txtAge").value 
        
        //Make the callback to the server
        CallServer(argument, "");
    }
    
    //Receives the CallBack Result
    function ReceiveCallBackResult(result)
    {   
        //Inform the user
        document.getElementById("ResultsSpan").innerHTML = result;
        //UserAdded
        window.opener.UserAddedEvent(result);
    }
</script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
        User Name
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        Age &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />
      <br />
      <button type="Button" onclick="AddUser()">
          Add</button>
      <br />
      <br />
      <span id="ResultsSpan" runat="server"></span>
      <br />
    </div>
  </form>
</body>
</html>