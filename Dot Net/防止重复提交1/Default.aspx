<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">

    
    <script type="text/javascript">
function check()
{
    try
    {     
        if (window.document.readyState)
        {//IE 
            if(window.document.readyState != 'complete')
            {   
                alert('正在处理，请稍候...');
                return false;
            }            
        }   
        else
        {//Firefox 

            window.addEventListener("load",function(){alert('正在处理，请稍候...'); return false;},false); 
        }
    }
    catch(ex){ } 
}

</script>


    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" 
        OnClientClick="check();" Text="Button" 
        onclick="Button1_Click" />
    
    </form>
</body>
</html>
