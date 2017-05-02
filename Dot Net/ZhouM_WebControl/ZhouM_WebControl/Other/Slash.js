

function aline_laodongjie(x,y,color,border)
{
	document.write("<img border='"+ border +"' style='position:absolute; left: "+x +"; top:"+y +"; background-color:"+color+"' width=1 height=1 /> ")
}

function line_laodongjie(id,color,border)
{
	var td1 = document.getElementById(id);
	var x1 = getLeft_laodongjie(td1); 
	var y1  = getTop_laodongjie(td1);
	var x2 = getLeft_laodongjie(td1)+td1.offsetWidth;
	var y2 = getTop_laodongjie(td1)+td1.offsetHeight;

	var tmp;
	if(x1>=x2)
	{
		tmp = x1;
		x1=x2;
		x2=tmp;
		tmp=y1;
		y1=y2;
		y2=tmp;
	}
	for(var i = x1; i<=x2;)
	{
		var x=i;
		var y=((y2-y1)/(x2-x1)*(x-x1))+y1;
		aline_laodongjie(x,y,color,border);
		i = i+0.1
	}
}