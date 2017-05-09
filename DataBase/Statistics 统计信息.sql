--the Auto_Create_Statistics option is enabled for databases or not:
SELECT
CASE
WHEN
DATABASEPROPERTYEX('Master','IsAutoCreateStatistics')=1
THEN
'Yes'
ELSE
'No'
END as 'IsAutoCreateStatisticsOn?',
CASE
WHEN
DATABASEPROPERTYEX('Master','IsAutoUpdateStatistics')=1
THEN
'Yes'
ELSE
'No'
END as 'IsAutoUpdateStatisticsOn?',
CASE
WHEN
DATABASEPROPERTYEX('Master','is_auto_update_stats_async_
on')=1
THEN
'Yes'
ELSE
'No'
END as 'isAutoUpdateStatsAsyncOn?'
GO


SELECT
object_id
,OBJECT_NAME(object_id) AS TableName
,name AS StatisticsName
,auto_created
FROM
sys.stats
where object_id=OBJECT_ID('MES_Shift_AttendanceALL')
Order by object_id desc
GO