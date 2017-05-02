<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        CheckOnline online = new CheckOnline();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //得到在线用户列表
        User newuser = new User();
        newuser.name = Session.SessionID;
        newuser.sessionid = Session.SessionID;
        newuser.lasttime = newuser.curtime = DateTime.Now;

        OnLineUser alluser = new OnLineUser();
        if (alluser.AddUserToOnLine(newuser))
        {
            Response.Write("用户添加成功<br>");
        }
        else
        {
            Response.Write("用户添加失败<br>");
        }

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
