<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc1.ascx.cs" Inherits="uc1" %> 

<asp:DataList ID="dlshow" runat="server"  RepeatDirection ="Horizontal" OnSelectedIndexChanged="dlshow_SelectedIndexChanged">
  <ItemTemplate >
   <asp:LinkButton ID="linkbtn" runat="server" CommandName="Select"
   Text='<%#Container.DataItem %>'>
   </asp:LinkButton> 
 </ItemTemplate> 
</asp:DataList>