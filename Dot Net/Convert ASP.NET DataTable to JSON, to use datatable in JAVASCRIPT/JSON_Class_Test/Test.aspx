<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
    <script type="text/javascript">
    
    function OnPageLoad()
    {
            
            CreateHTMLTableUsingJSONDataTable();
            
            CreateHTMLTableUsingJSONParameters();
    }
    
    
        function CreateHTMLTableUsingJSONDataTable()
        {
            //var oJSON_Parameter_DataHolder=document.getElementById("JSON_Parameter_DataHolder");
            var oJSON_DataTable_DataHolder=document.getElementById("JSON_DataTable_DataHolder");
            
            var oJSON=eval("("+oJSON_DataTable_DataHolder.value+")");
            
            var oHTMLTABLE=document.createElement("table");
            
            
            oHTMLTABLE.border=1;
            
            for(var i=0;i<oJSON.TABLE[0].ROW.length;i++)
            {
                    var oTR=oHTMLTABLE.insertRow(i);
                    
                for(var j=0;j<oJSON.TABLE[0].ROW[i].COL.length;j++)
                {
                    var oTD=oTR.insertCell(j);
                    
                    oTD.innerHTML=oJSON.TABLE[0].ROW[i].COL[j].DATA;
                }   
            }
                
                var oDIV=document.createElement("div");
                
                oDIV.innerHTML="<b><i><u>Table By JSON DATATABLE</u></i></b>";
                
                document.body.appendChild(oDIV);            
                
                document.body.appendChild(oHTMLTABLE);            
        }
    
    
    
        function CreateHTMLTableUsingJSONParameters()
        {
            //var oJSON_Parameter_DataHolder=document.getElementById("JSON_Parameter_DataHolder");
            var oJSON_DataTable_DataHolder=document.getElementById("JSON_Parameter_DataHolder");
            
            var oJSON=eval("("+oJSON_DataTable_DataHolder.value+")");
            
            var oHTMLTABLE=document.createElement("table");
            
            oHTMLTABLE.border=1;
            
            for(var i=0;i<oJSON.Head.length;i++)
            {
                    var oTR=oHTMLTABLE.insertRow(i);
                    
                    var oTD0=oTR.insertCell(0);
                    
                        oTD0.innerHTML=oJSON.Head[i].Name;
                        
                    var oTD1=oTR.insertCell(1);
                    
                        oTD1.innerHTML=oJSON.Head[i].Age;
                        
                    var oTD2=oTR.insertCell(2);
                    
                        oTD2.innerHTML=oJSON.Head[i].Address;
                   
            }
            
                var oDIV=document.createElement("div");
                
               oDIV.innerHTML="<b><i><u>Table By JSON Parameters</u></i></b>";
               
               document.body.appendChild(oDIV);            
               
               document.body.appendChild(oHTMLTABLE);            
        }
    
    </script>
    
    
    
    
    
</head>
<body onload="OnPageLoad()">
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="JSON_Parameter_DataHolder" runat="server" />
        <asp:HiddenField ID="JSON_DataTable_DataHolder" runat="server" />
    
    </div>
    </form>
</body>
</html>



