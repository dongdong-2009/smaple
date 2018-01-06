SELECT  j.name                        AS Job_Name        ,
        h.step_id                     AS Step_Id         ,
        h.step_name                   AS Step_Name       ,
        h.message                     AS Message         ,
        h.run_date                    AS Run_Date        ,
        msdb.dbo.agent_datetime(h.run_date, h.run_time) 
                                    AS 'RunDateTime' ,
        CAST(run_duration / 10000 AS VARCHAR(2)) + N' hour'
        + CAST(( run_duration - run_duration / 10000 * 10000 ) / 100 AS VARCHAR(2)) + N' min'
        + SUBSTRING(CAST(run_duration AS VARCHAR(10)),
                            LEN(CAST(run_duration AS VARCHAR(10))) - 1, 2)  + N' second'
        AS run_duration
FROM    msdb.dbo.sysjobhistory h
        LEFT JOIN msdb.dbo.sysjobs j ON h.job_id = j.job_id
		where j.name like '%FinancialReconciliation_ALH_Reconciliation%' and h.run_date = '20180106' and h.step_id > 0
ORDER BY Job_Name, h.Step_Id