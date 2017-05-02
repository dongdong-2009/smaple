
function getLeft_laodongjie(root)
{
    var left = 0;
    while(root != null)
    {
        left += root.offsetLeft;
        root = root.offsetParent; 
    }      
    return left; 
}

function getTop_laodongjie(root)
{
    var Top = 0;
    while(root != null)
    {
        Top += root.offsetTop;
        root = root.offsetParent; 
    }      
    return Top; 
}
