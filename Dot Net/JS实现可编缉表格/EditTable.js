var x_Size = 10;                    // �������
var y_Size = 5;                     // �������
var cell_Width = 135                // ��Ԫ����
var cell_Height = 20                // ��Ԫ��߶�
var cell_BackColor = "#FFFFFF"      // ��Ԫ�񱳾�ɫ
 var table_BackColor = "#000000"     // ��񱳾�ɫ

//�������
 
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
 
 
 //���� input ����
 var txt_input = document.createElement("input");
 
 // ���ı���ʧȥ����ʱ����last
 txt_input.onblur = last;
 txt_input.type = "text";
 
 // �õ����뵥Ԫ��
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
 
 // �õ�Ԫ���ֵ������ı����ֵ
 txt_input.value = currentCell.innerHTML;
 currentCell.innerHTML ="";
 // ���ı���ӵ���ǰ��Ԫ����
 currentCell.appendChild(txt_input);
 txt_input.focus();
 }
 
 
 function last()
 {
 // ���ı����ֵ����ǰ��Ԫ��
 currentCell.innerHTML = txt_input.value;
 }
 
 //Ϊ���󶨴�����
 document.getElementById("editTable").onclick = editCell;