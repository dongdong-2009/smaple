var x_Size = 10;                    // 表格行数
var y_Size = 5;                     // 表格列数
var cell_Width = 135                // 单元格宽度
var cell_Height = 20                // 单元格高度
var cell_BackColor = "#FFFFFF"      // 单元格背景色
 var table_BackColor = "#000000"     // 表格背景色

//创建表格
 
 table_str = "<table id='editTable' style='background-color:"+table_BackColor+";'cellspacing='1' cellpadding='1'>  ";
 
 for(var i=0; i<x_Size; i++)
 {
     table_str += "<tr>";
     for(var j=0; j<y_Size; j++)
     {
         table_str += "<td style='width:"+cell_Width+"px;height:"+cell_Height+"px;background-color:"+cell_BackColor+";'>";
         table_str += "</td>";
     }
     table_str += "</tr>";
 }
 table_str += "</table>";
 document.write(table_str);
 
 
 //创建 input 对象
 var txt_input = document.createElement("input");
 
 // 当文本框失去焦点时调用last
 txt_input.onblur = last;
 txt_input.type = "text";
 
 // 得到当半单元格
 var currentCell;

  function editCell(event)
 {    
     if(currentCell != null)
 {
 currentCell.innerHTML =txt_input.value;  
 }   
 if(event==null)
 {    
 
 if(window.event.srcElement==txt_input)
 {
 return;
 }
 currentCell = window.event.srcElement;
 }
 else
 {
 currentCell = event.target;
 }
 
 // 用单元格的值来填充文本框的值
 txt_input.value = currentCell.innerHTML;
 currentCell.innerHTML ="";
 // 把文本框加到法前单元格上
 currentCell.appendChild(txt_input);
 txt_input.focus();
 }
 
 
 function last()
 {
 // 充文本框的值给当前单元格
 currentCell.innerHTML = txt_input.value;
 }
 
 //为表格绑定处理方法
 document.getElementById("editTable").onclick = editCell;