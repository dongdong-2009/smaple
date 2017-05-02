<script language=javascript>


//选择专题的函数
function openTopic()
{
	window.open("admin_selTopic.aspx","topic","width=450,height=350,left=0,top=0,scrollbars=1,status=1,resizable=1");
}
// 设置专题
function setTopic(name, id)
{
	var objTopic=document.all.<%=Topic.ClientID%>;
	var objTopicID=document.all.<%=TopicID.ClientID%>;
	objTopic.value=name;
	objTopicID.value=id;
}

function SetTitleImg(str)
{
	var obj=document.<%=myForm.ClientID%>.<%=TitleImg.ClientID%>
	obj.value=str;
}

function OpenUpload()
{
	window.open("admin_upload.aspx","upload","width=450,height=350,left=0,top=0,scrollbars=1,status=1,resizable=1");
}

function AddUpload(str)
{
	var obj=document.<%=myForm.ClientID%>.<%=Upload.ClientID%>;
	if (obj.value=="")
	{
		obj.value=str;
	}else{
		obj.value+=","+str;
	}
}

// 反选checkbox

function checkAll(layer, bcheck)
{
	for(var i=0; i<layer.children.length; i++)
	{
		if (layer.children[i].children.length>0)
		{
			checkAll(layer.children[i],bcheck);
		}else{
			if (layer.children[i].type=="checkbox")
			{
					layer.children[i].checked = bcheck;
			}
		}
	}
}

</script>
