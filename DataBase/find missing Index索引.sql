--finding missing Index
SELECT
avg_total_user_cost * avg_user_impact * (user_seeks + user_scans)
AS PossibleImprovement
,last_user_seek
,last_user_scan
,statement AS Object
,'CREATE INDEX [IDX_' + CONVERT(VARCHAR,GS.Group_Handle) + '_' +
CONVERT(VARCHAR,D.Index_Handle) + '_'
+ REPLACE(REPLACE(REPLACE([statement],']',''),'[',''),'.','') +
']'
+' ON '
+ [statement]
+ ' (' + ISNULL (equality_columns,'')
+ CASE WHEN equality_columns IS NOT NULL AND inequality_columns IS
NOT NULL THEN ',' ELSE '' END
+ ISNULL (inequality_columns, '')
+ ')'
+ ISNULL (' INCLUDE (' + included_columns + ')', '')
AS Create_Index_Syntax
FROM
sys.dm_db_missing_index_groups AS G
INNER JOIN
sys.dm_db_missing_index_group_stats AS GS
ON
GS.group_handle = G.index_group_handle
INNER JOIN
sys.dm_db_missing_index_details AS D
ON
G.index_handle = D.index_handle
--where statement like '%shift%'
Order By PossibleImprovement DESC