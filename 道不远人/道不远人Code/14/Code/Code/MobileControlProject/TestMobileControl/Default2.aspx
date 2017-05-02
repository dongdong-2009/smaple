<%@ Page Language="C#" AutoEventWireup="true"%>
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE wml PUBLIC "-//WAPFORUM//DTD WML 1.3//EN" "http://www.wapforum.org/DTD/wml13.dtd">
<script runat="server"> 
    protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
    {
        base.RaisePostBackEvent(sourceControl, eventArgument);
    }   
    protected void btnHello_Click(object sender, EventArgs e)
    {
        lblHello.Text = txtName.Text + ",Welcome to WAP!";
    }
</script>
<wml>
    <head>
        <title>Test Mobile</title>
        <meta content='no-cache' http-equiv='Cache-Control'/>
    </head>

    <mb:Card id="Main" runat="server">
        <mb:Panel runat="server" id="pnlMain">
            请输入姓名：<mb:Input title="支持中文" id="txtName" runat="server">中文字</mb:Input>
            <mb:Button id="btnHello" runat="server" OnClick="btnHello_Click" text="Say Hello"></mb:Button>
            <mb:MobileLiteral id="lblHello" runat="server"></mb:MobileLiteral>
            <mb:Button id="Button1" runat="server" text="Other button"></mb:Button>
        </mb:Panel>
    </mb:Card>
</wml>