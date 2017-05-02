

select distinct name 
from sysobjects o, syscomments s 
where o.id = s.id 
and text like '%Duplicate%Serial_Number_Found%'
and o.xtype = 'P' 
union
SELECT distinct ROUTINE_NAME 
FROM INFORMATION_SCHEMA.ROUTINES 
WHERE  
ROUTINE_DEFINITION like '%Serial_Number_Found%' AND ROUTINE_TYPE='PROCEDURE' 