<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="true" EnableEventValidation="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello world</title>

    <script type="text/javascript">
        function AutoFlex(id,maxHeight){
            this._id = id;
            this.maxHeight = maxHeight;
        }
        AutoFlex.prototype._onPropertyChange = function(){
            if(this.maxHeight){
                this._element.style.height =
                 ( this._element.scrollHeight > this.maxHeight ) ? this.maxHeight : 
                    this._element.scrollHeight + ( this._element.offsetHeight - this._element.clientHeight );          
            }
            else{
                this._element.style.height = this._element.scrollHeight 
                    + ( this._element.offsetHeight - this._element.clientHeight );
            }  
        }
        AutoFlex.prototype._getPropertyChangeHandler = function(){
            var obj = this;
            return function (){
                obj._onPropertyChange.call(obj);
            }
        }
        AutoFlex.prototype.initiate = function(){
            this._element = document.getElementById(this._id);
            if(this._element){
                this._element.onpropertychange = this._getPropertyChangeHandler();
            }
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <textarea id="txt1" rows="5" cols="5"></textarea>
            <textarea id="txt2" rows="5" cols="5"></textarea>
        </div>

        <script type="text/javascript">
        new AutoFlex('txt1').initiate();
        new AutoFlex('txt2',200).initiate();
        </script>

    </form>
</body>
</html>
