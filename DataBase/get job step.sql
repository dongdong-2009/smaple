select msdb.dbo.sysjobs.name, msdb.dbo.sysjobsteps.step_id, msdb.dbo.sysjobsteps.step_name, msdb.dbo.sysjobsteps.subsystem, msdb.dbo.sysjobsteps.command,   
CASE msdb.dbo.sysjobsteps.on_success_action  
WHEN 1 THEN 'Quit with Success'  
WHEN 2 THEN 'Quit with Failure'  
WHEN 3 THEN 'Go to Next Step'  
WHEN 4 THEN 'Go to Step ' + convert(varchar(2),msdb.dbo.sysjobsteps.on_success_step_id)  
END AS on_success_action,  
CASE msdb.dbo.sysjobsteps.on_fail_action  
WHEN 1 THEN 'Quit with Success'  
WHEN 2 THEN 'Quit with Failure'  
WHEN 3 THEN 'Go to Next Step'  
WHEN 4 THEN 'Go to Step ' + convert(varchar(2),msdb.dbo.sysjobsteps.on_fail_step_id)  
END AS on_fail_action,  
msdb.dbo.sysjobsteps.retry_attempts, msdb.dbo.sysjobsteps.retry_interval, msdb.dbo.sysjobsteps.output_file_name  
from msdb.dbo.sysjobsteps join msdb.dbo.sysjobs on msdb.dbo.sysjobsteps.job_id = msdb.dbo.sysjobs.job_id  
where msdb.dbo.sysjobs.name like 'FinancialReconciliation_AMER_PyramidAssetLoad'  
order by msdb.dbo.sysjobs.name, msdb.dbo.sysjobsteps.step_id  