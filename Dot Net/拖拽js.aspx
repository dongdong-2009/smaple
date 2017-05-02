<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="javascript">
    //为Number增加一个属性,判断当前数据类型是否是数字
    Number.prototype.NaN0=function(){return isNaN(this)?0:this;}

    //全局变量
    var iMouseDown=false;
    var dragObject=null;

    //获得鼠标的偏移量(对象2-对象1)
    function getMouseOffset(target,ev)
    {
        ev=ev||window.event;
        var docPos=getPosition(target);
        var mousePos=mouseCoords(ev);
        return {x:mousePos.x-docPos.x,y:mousePos.y-docPos.y};
    }

    //获得事件发生的实际位置----------------------对象1
    function getPosition(e)
    {
        var left=0;
        var top=0;
        //相对位置累加得到实际位置
        while(e.offsetParent)
        {
            left+=e.offsetLeft+(e.currentStyle?(parseInt(e.currentStyle.borderLeftWidth)).NaN0():0);
            top+=e.offsetTop+(e.currentStyle?(parseInt(e.currentStyle.borderTopWidth)).NaN0():0);
            e=e.offsetParent;
        }
        left+=e.offsetLeft+(e.currentStyle?(parseInt(e.currentStyle.borderLeftWidth)).NaN0():0);
        top+=e.offsetTop+(e.currentStyle?(parseInt(e.currentStyle.borderTopWidth)).NaN0():0);
        return {x:left,y:top};
    }
    //获得发生事件鼠标的位置----------------------对象2
    function mouseCoords(ev)
    {
        if(ev.pageX||ev.pageY)
        {
            return {x:ev.pageX,y:ev.pageY};
        }
        return {x:ev.clientX+document.body.scrollLeft-document.body.clientLeft,y:ev.clientY+document.body.scrollTop-document.body.clientTop};
    }


    //定义可以拖拽的对象
    function makeDragable(item)
    {
        if(!item) return;
        //为可拖拽对象定义一个onmousedown事件的方法
        ev=window.event;
        item.onmousedown=function(ev)
        {
            dragObject=this;
            mouseOffset=getMouseOffset(this,ev);
            return false;
        }
    }

    //定义鼠标点下所调用的方法
    function mouseDown(ev)
    {
        ev=ev||window.event;
        
        var target=ev.target||ev.srcElement;
        if(target.onmousedown||target.getAttribute('DragObj'))
        {
            return false;
        }    
    }
    //鼠标抬起后释放对象
    function mouseUp(ev)
    {
        dragObject = null;
        //onmouseup事件触发时说明鼠标已经松开，所以设置down变量值为false 
        iMouseDown = false;
    }

    //鼠标移动
    function mouseMove(ev)
    {
        ev=ev||window.event;
        var target   = ev.target || ev.srcElement;
        var mousePos = mouseCoords(ev);
        if(dragObject)
        {
            if(dragObject.style)
            {
                //移动对象
                dragObject.style.left=mousePos.x - mouseOffset.x;
                dragObject.style.top= mousePos.y - mouseOffset.y;
            }
        }
        //lMouseState = iMouseDown;
        if(dragObject) return false;
    }
    document.onmousedown=mouseDown;
    document.onmousemove=mouseMove;
    document.onmouseup=mouseUp;


    function moveImg()
    {
        var img1=document.getElementById('img1');
        makeDragable(img1);
    }
    </script>
</head>
<body onload="moveImg()">
    <form id="form1" runat="server">
    <div>
    <img src="a.jpg" alt="" id="img1" style="position:absolute;left:0px;top:0px;" />
    </div>
    </form>
</body>
</html>
