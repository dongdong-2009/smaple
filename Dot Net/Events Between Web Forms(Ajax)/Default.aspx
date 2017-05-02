<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Untitled Page</title>
     <script type="text/javascript">
     
     
       //Open the add new user window
        function AddNewUser()
        {
            window.open("ClientCallback.aspx","New","width=600,height=110");
        }
        
        
        //Open the add new user window
        function AddNewUserAjax()
        {
            window.open("AjaxCallBack.aspx","New","width=600,height=110");
        }
        
        
        //Receive some data from the child window
        function UserAddedEvent(result)
        {
            //Message about the Last User Added
            document.getElementById("UserAdded").innerHTML = result;
        
             //Reload the user list
             ReloadUserList();
            
        }
        
    
        //Reloads the User list with a callback
        function ReloadUserList()
        {
            //Make the callback to the server
            CallServer("", "");
        }    
        
        //Receives the CallBack Result
        function ReceiveCallBackResult(result)
        {   
            //Inform the user
            document.getElementById("UsersTable").innerHTML = result;
        }
    
</script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div id="UsersTable">
        <% = ShowTheData()%></div>
        <br/>
        <input id="Add_New_User" type="button" value="Add User"  onclick ="AddNewUser();"/>
        <input id="Add_New_User_Ajax" type="button" value="Add User Ajax"  onclick ="AddNewUserAjax();"/>
        <br />
        <span id="UserAdded" runat="server"></span>
    </form>
</body>
</html>
