with js as (
select 
j.job_id
, js.step_id 
, j.name as Job_Name
, js.step_name 
, js.command
, Cast(1 as Integer) as StartPos
, Cast(Case when CHARINDEX('/', js.command,2) = 0 
  then LEN(js.command) Else CHARINDEX('/', js.command,2) end
 As Integer)  as EndPos
, Cast(Case 
  when CHARINDEX(' ', js.command,2) = 0 then  
  Cast(Case when CHARINDEX('/', js.command,2) = 0 
	then LEN(js.command) Else CHARINDEX('/', js.command,2) end
		as Integer) Else CHARINDEX(' ', js.command,2) end
		as Integer)  as StartValue
 from 
 msdb.dbo.sysjobs j
 inner join 
 msdb.dbo.sysjobsteps js
 on j.job_id = js.job_id
 where js.subsystem = 'SSIS'
 union all
 SELECT
 js.job_id
 , js.step_id
 , js.job_name
 , js.step_name
 , js.command
 , EndPos as StartPos
, Cast(Case when 
  CHARINDEX('/', js.command,EndPos + 1) = 0 
  then LEN(js.command) 
  Else CHARINDEX('/', js.command,EndPos + 1) 
  end
		as Integer)  as EndPos
, Cast(Case 
  when CHARINDEX(' ', js.command,EndPos + 2) = 0 
  then  Cast(Case 
  when CHARINDEX(' ', js.command,EndPos + 2) = 0 
  then LEN(js.command) Else CHARINDEX('/', js.command,EndPos + 1) 
  end
		as Integer) Else CHARINDEX(' ', js.command,EndPos + 1) end
		as Integer)  as StartValue

 from js
 WHERE  CHARINDEX('/', js.command,EndPos + 1) > 0
 )
 select step_id,replace(Step_name,'ssis:','') 
 , SUBSTRING(command, StartPos, StartValue - StartPos) as ParameterName
 , SUBSTRING(command, StartValue, EndPos - StartValue  ) as ParameterValue
  from js
  where job_name = 'FinancialReconciliation_ALH_Reconciliation'
  and SUBSTRING(command, StartPos, StartValue - StartPos)   not like '%checkpoin%'
  and SUBSTRING(command, StartPos, StartValue - StartPos)   not like '%user%'
  and SUBSTRING(command, StartPos, StartValue - StartPos)   not like '%password%'
  and SUBSTRING(command, StartPos, StartValue - StartPos)   not like '%SQL%'
  and SUBSTRING(command, StartPos, StartValue - StartPos)   not like '%ALH_Reconcile_Repositories_ssis%'
  and SUBSTRING(command, StartPos, StartValue - StartPos)   not like '%Financial%'
  and SUBSTRING(command, StartValue, EndPos - StartValue) not like '%passworkd%'
  and SUBSTRING(command, StartValue, EndPos - StartValue) not like '%username%'
  order by step_id
