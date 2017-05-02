<%@Page Language="C#" Inherits="Article.Admin.ArticleEdit" %>
<%@Register TagPrefix="WbControls" Namespace="WbControls" Assembly="WbControls" %>
<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
<!--#include file=inc/js_code.aspx -->
</head>
<body>

<form id="myForm" runat=server>


<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_news_modify"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width="100%"  id="myLabel" Visible="false" runat="server"/> 
	<asp:Panel id="mainPanel" runat=server>
	 <table cellpadding=0 cellspacing=0 width="100%" border="0">
	  <tr height=120> 
	   <td class="tdbg">
		<table align=center width=90% >
		<tr><td width=60>
			<%=lang["news_class"]%>
		</td><td>
			<asp:DropDownList id="ClassID"
				runat=server/>
			<asp:RequiredFieldValidator
				ControlToValidate="ClassID"
				ErrorMessage="*"
				Display="Dynamic"
				runat=server/>
			<script>
			function setOptionColor()
			{
				var obj=document.all.<%=ClassID.ClientID%>;
				for (var i=0;i<obj.options.length;i++)
				{
					if (obj.options[i].value=="")
					{
						obj.options[i].style.color="gray";
					}else{
						obj.options[i].style.color="black";
					}
				}
			}
			setOptionColor();
			</script>
		</td></tr>
		<tr><td>
			<%=lang["news_title"]%>
		</td><td>
			<asp:TextBox id="Title"
				MaxLength=100
				Size=90
				runat=server/>
			<asp:RequiredFieldValidator
				ControlToValidate="Title"
				ErrorMessage="*"
				Display="Dynamic"
				runat=server/>
		</td></tr>
		<tr><td>
			<%=lang["news_title_img"]%>
		</td><td>
			<asp:TextBox id="TitleImg"
				MaxLength=100
				Size=30
				runat=server/>
			<%=lang["news_title_img_note"]%>
			<input type="hidden" id="Upload" runat=server/>
		</td></tr>
		<tr><td>
			<%=lang["news_topic"]%>
		</td><td>
			<asp:TextBox id="Topic" Size=50 Readonly="true" runat=server/>
			<input type="hidden" id="TopicID" value="0" runat=server/>
			<a href="#" onclick="openTopic()"><u><%=lang["select_topic"]%></u></a>
			&nbsp; <a href=# onclick="document.all.<%=Topic.ClientID%>.value='';document.all.<%=TopicID.ClientID%>.value=0"><u><%=lang["no_topic"]%></u></a><br>
		</td></tr>
		<tr><td>
			<%=lang["news_property"]%>
		</td><td>
			<asp:CheckBox id="Headline" runat=server/><label for=<%=Headline.ClientID%> ><%=lang["news_headline"]%></label>&nbsp;
			<asp:CheckBox id="HighLight" runat=server/><label for=<%=HighLight.ClientID%> ><%=lang["news_highlight"]%></label>
		</td></tr>
		<tr><td>
			<%=lang["news_url"]%>
		</td><td>
			<asp:TextBox id="Url"
				MaxLength=200
				Size=30
				runat=server/>
		</td></tr>
		<tr><td valign=top>
			<%=lang["news_content"]%>
		</td><td>
			<WbControls:WBTB id="Body" NewsButton="true" UploadScript="OpenUpload();" runat="server" />
		
			<script language="javascript">
			<!--
			function ClientValidate(source, arguments)
			{
				if (arguments.Value.length>250)
					arguments.IsValid=false;
				else
					arguments.IsValid=true;
			}
			-->
			</script>
		</td></tr>
		<tr><td vlaign=top>
			<%=lang["news_summary"]%><br>
			(HTML)
		</td><td>
			<asp:CustomValidator
				ControlToValidate="Summary"
				ClientValidationFunction="ClientValidate"
				OnServerValidate="Summary_validation"
				ErrorMessage="*At most 250 letters"
				Display="Dynamic"
				runat=server />
			<br>
			<asp:TextBox id="Summary"
				TextMode="MultiLine"
				Columns=75
				Rows=3
				runat=server />
		</td></tr>
		<tr><td>
			<%=lang["news_related"]%>
		</td><td>
			<asp:TextBox id="Key"
				MaxLength=5
				Size=60
				runat=server/>
		</td></tr>
		<tr><td>
			<%=lang["news_author"]%>
		</td><td>
			<asp:TextBox id="Author"
				MaxLength=50
				Size=60
				runat=server/>
			<script>
			function setAuthor(str)
			{
				var obj=document.<%=myForm.ClientID%>.<%=Author.ClientID%>;
				obj.value=str;
			}
			</script>
			&larr; 
			<%
			foreach(string s in lang["unknown_author"].ToString().Split(new Char[]{','}) )
			{
				Response.Write("<a href=\"javascript:setAuthor('");
				Response.Write(s);
				Response.Write("')\">");
				Response.Write(s);
				Response.Write("</a>&nbsp; ");
			}
			%>
		</td></tr>
		<tr><td>
			<%=lang["news_source"]%>
		</td><td>
			<asp:TextBox id="Source"
				MaxLength=50
				Size=60
				runat=server/>
		</td></tr>
		<tr><td colspan=2>
			   <%=lang["news_permit_groups"]%>
			  <input type="checkbox" id="check_groups" onclick="checkAll(document.all.<%=PermitGroups.ClientID%>,this.checked);"><label for="check_groups"><%=lang["check_all"]%></label>
			   <asp:CheckBoxList ID="PermitGroups" runat="server"
			   	Width="90%"
			   	RepeatDirection="Horizontal"
			   	RepeatColumns="5"
			   	CellPadding="1"
			   	RepeatLayout="Table"
			   	CssClass="bg2"
			   	/>
		</td></tr>
		<tr><td>
			<%=lang["news_add_user"]%>
		</td><td>
			<asp:Label ID="Username" runat="server" />
		<tr><td colspan=2>
			<%
			Submit.Text=lang["submit_text"].ToString();
			%>
			<asp:Button id="Submit" text="ÐÞ ¸Ä" onclick="Submit_OnClick" runat=server/>
		</td></tr>
		</table>
	   </td>
	  </tr>
	 </table>
	 
	</asp:Panel>

</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>




</form>

</body>
</html>