--Finding Blocking Information
SELECT
R.session_id AS BlockedSessionID
,S.session_id AS BlockingSessionID
,Q1.text AS BlockedSession_TSQL
,Q2.text AS BlockingSession_TSQL
,C1.most_recent_sql_handle AS BlockedSession_SQLHandle
,C2.most_recent_sql_handle AS BlockingSession_SQLHandle
,S.original_login_name AS BlockingSession_LoginName
,S.program_name AS BlockingSession_ApplicationName
,S.host_name AS BlockingSession_HostName
FROM sys.dm_exec_requests AS R
INNER JOIN sys.dm_exec_sessions AS S
ON R.blocking_session_id = S.session_id
INNER JOIN sys.dm_exec_connections AS C1
ON R.session_id = C1.most_recent_session_id
INNER JOIN sys.dm_exec_connections AS C2
ON S.session_id = C2.most_recent_session_id
CROSS APPLY sys.dm_exec_sql_text (C1.most_recent_sql_handle) AS Q1
CROSS APPLY sys.dm_exec_sql_text (C2.most_recent_sql_handle) AS Q2

   use abmlighthouse
   select   request_session_id   spid,OBJECT_NAME(resource_associated_entity_id) tableName   
from   sys.dm_tran_locks where resource_type='OBJECT'