function DataTable(rows,cols,tableName)
{
	this.Columns=cols
	this.Rows=rows
	this.Name=tableName
}

function generateVarXML(val,extAttrs)
{
	var xml=''
	if(val==null)
	{
		xml='<NULL/>'
	}
	else if(val.constructor==Array)
	{
		xml+='<A'
		xml+=' L="'+val.length+'"'
		if(extAttrs) xml+=' '+extAttrs
		xml+='>'
		for(index in val)
		{
			xml+=generateVarXML(val[index],'')
		}
		xml+='</A>'
	}
	else if(val.constructor==Object)
	{
		xml+='<O'
		if(extAttrs) xml+=' '+extAttrs
		xml+='>'
		for(key in val)
		{
			xml+=generateVarXML(val[key],'K="'+key+'"')
		}
		xml+='</O>'
	}
	else if(val.constructor==Number)
	{
		xml+='<N'
		xml+=' V="'+val.toString()+'"'
		if(extAttrs) xml+=' '+extAttrs
		xml+='/>'
	}
	else if(val.constructor==String)
	{
		xml+='<S'
		xml+=' V="'+val.toString()+'"'
		if(extAttrs) xml+=' '+extAttrs
		xml+='/>'
	}
	else if(val.constructor==Date)
	{
		xml+='<D'
		xml+=' V="'+val.getFullYear()+'-'+(val.getMonth()+1)+'-'+val.getDate()+' '+val.getHours()+':'+val.getMinutes()+':'+val.getSeconds()+'"'
		if(extAttrs) xml+=' '+extAttrs
		xml+='/>'
	}
	else if(val.constructor==DataTable)
	{
		xml+='<T'
		xml+=' C="'
		for(i=0;i<val.Columns.length;i++)
		{
			if(i>0) xml+=","
			xml+=val.Columns[i]
		}
		xml+='"'
		xml+=' N="'+val.Name+'"'
		if(extAttrs) xml+=' '+extAttrs
		xml+='>'
		for(i in val.Rows)
		{
			xml+=generateVarXML(val.Rows[i],"")
		}
		xml+="</T>"
	}
	return xml
}

function AttachSubmitEvent(hiddenCtrId,func)
{
	var_from=document.getElementById(hiddenCtrId).form
	if(var_from.attachEvent)
	{
		var_from.attachEvent(
			"onsubmit",
			func
		)
	}
	else if(var_from.addEventListener)
	{
		var_from.addEventListener(
			"submit",
			func,
			false
		)
	}
}

function cloneVar(val)
{
	if(val==null)
	{
		return null
	}
	else if(val.constructor==Array)
	{
		var a=new Array()
		for(i in val)
		{
			a[i]=cloneVar(val[i])
		}
		return a
	}
	else if(val.constructor==Object)
	{
		var a=new Object()
		for(c in val)
		{
			a[c]=cloneVar(val[c])
		}
		return a
	}
	else if(val.constructor==Number)
	{
		return val
	}
	else if(val.constructor==String)
	{
		return val
	}
	else if(val.constructor==Date)
	{
		return val
	}
	else if(val.constructor==DataTable)
	{
		return new DataTable(cloneVar(val.Rows),cloneVar(val.Columns),val.Name)
	}
}

function refreshVariableXML(hidId,val)
{
	hid=document.getElementById(hidId).value=escape(generateVarXML(val))
}
