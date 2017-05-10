--By the way, if you are curious to know how much space is consumed by ad hoc queries in a
--procedure cache that has been run only once, you can run following query:
SELECT
 sum(cast(size_in_bytes as bigint)) as TotalByteConsumedByAdHoc
FROM
sys.dm_exec_cached_plans
WHERE
objtype = 'Adhoc'
AND usecounts = 1


EXEC sp_configure 'optimize for ad hoc workloads',1
RECONFIGURE
GO

SELECT
CP.usecounts AS CountOfQueryExecution
,CP.cacheobjtype AS CacheObjectType
,CP.objtype AS ObjectType
,ST.text AS QueryText
FROM
sys.dm_exec_cached_plans AS CP
CROSS APPLY
sys.dm_exec_sql_text(plan_handle) AS ST
 WHERE
CP.usecounts > 0
AND CP.cacheobjtype='Compiled Plan'
AND ST.text LIKE 'SELECT * FROM Sales.SalesOrderDetail WHERE
SalesOrderID=43659%'
GO