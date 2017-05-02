<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComboBox.ascx.cs" Inherits="ComboBox" %>
<script language ="javascript" src ="AjaxCallBack.js" type ="text/javascript" ></script>
<script language ="javascript" type ="text/javascript" >
     function getValue(txtSearch)
    {
        var ddl=document.getElementById("<%=lstComboBox.ClientID%>");
       
        FillCombo(ddl,txtSearch);
    }

</script>

<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:TextBox ID="txtComboBox" Width="250px" onkeyup="getValue(this.value)"
                runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:ListBox ID="lstComboBox" style="display :none"   Width="254px" runat="server"></asp:ListBox>
        </td>
    </tr>
</table>
