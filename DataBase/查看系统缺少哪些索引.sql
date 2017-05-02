--查看系统缺少哪些索引
SELECT migs.group_handle, mid.* 
FROM sys.dm_db_missing_index_group_stats AS migs 
INNER JOIN sys.dm_db_missing_index_groups AS mig 
ON (migs.group_handle = mig.index_group_handle) 
INNER JOIN sys.dm_db_missing_index_details AS mid 
ON (mig.index_handle = mid.index_handle) 
WHERE migs.group_handle = 2
--提示：但是，这里的DMV信息只是记录自上次SQL Server启动以后的信息项，
--也就是说每次重启之后这部分信息就丢失了，所以对于生产系统，建议确保运行了一段周期之后再进行查看。
--sys.dm_db_missing_index_details

--sys.dm_db_missing_index_groups

--sys.dm_db_missing_index_group_stats

--sys.dm_db_missing_index_columns(index_handle)

--sys.dm_db_missing_index_details