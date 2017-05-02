/*Perform a 'USE <database name>' to select the database in which to run the script.*/ 
-- Declare variables 
SET NOCOUNT ON; 
DECLARE @tablename varchar(255); 
DECLARE @execstr varchar(400); 
DECLARE @objectid int; 
Declare @IndexName varchar(500); 
DECLARE @indexid int; 
DECLARE @frag decimal; 
DECLARE @maxfrag decimal; 
DECLARE @TmpName varchar(500); 

-- Declare @TmpName ='' 
set @TmpName = '' 

-- Decide on the maximum fragmentation to allow for. 
SELECT @maxfrag = 40.0; 

-- Declare a cursor. 
DECLARE tables CURSOR FOR 
SELECT TABLE_SCHEMA + '.' + TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'; 

-- Create the table. 
CREATE TABLE #fraglist ( 
ObjectName char(255), 
ObjectId int, 
IndexName char(255), 
IndexId int, 
Lvl int, 
CountPages int, 
CountRows int, 
MinRecSize int, 
MaxRecSize int, 
AvgRecSize int, 
ForRecCount int, 
Extents int, 
ExtentSwitches int, 
AvgFreeBytes int, 
AvgPageDensity int, 
ScanDensity decimal, 
BestCount int, 
ActualCount int, 
LogicalFrag decimal, 
ExtentFrag decimal); 

-- Open the cursor. 
OPEN tables; 

-- Loop through all the tables in the database. 
FETCH NEXT 
FROM tables 
INTO @tablename; 

WHILE @@FETCH_STATUS = 0 
BEGIN; 
-- Do the showcontig of all indexes of the table 
INSERT INTO #fraglist 
EXEC ('DBCC SHOWCONTIG (''' + @tablename + ''') 
WITH FAST, TABLERESULTS, ALL_INDEXES, NO_INFOMSGS'); 
FETCH NEXT 
FROM tables 
INTO @tablename; 
END; 

-- Close and deallocate the cursor. 
CLOSE tables; 
DEALLOCATE tables; 

-- Declare the cursor for the list of indexes to be defragged. 
DECLARE indexes CURSOR FOR 
SELECT ObjectName, ObjectId,IndexName,IndexId, LogicalFrag 
FROM #fraglist 
WHERE INDEXPROPERTY (ObjectId, IndexName, 'IndexDepth') > 0; 

-- Open the cursor. 
OPEN indexes; 

-- Loop through the indexes. 
FETCH NEXT 
FROM indexes 
INTO @tablename, @objectid, @IndexName,@indexid, @frag; 


WHILE @@FETCH_STATUS = 0 
BEGIN; 
if @frag < @maxfrag and @frag > 20
Begin 
print @frag
print @tablename
SELECT @execstr = 'ALTER INDEX [' + RTRIM(@IndexName) + '] ON [' + RTRIM(@tablename) + '] REORGANIZE WITH ( LOB_COMPACTION = ON ) ' 
EXEC (@execstr);
print @execstr
--更新统计信息 
IF @TmpName<>@tablename 
BEGIN 
SET @tmpName=@tableName 
EXEC ('UPDATE STATISTICS '+@TableName + ' WITH FULLSCAN ') 
END 
 
End 
else if @frag>=@maxfrag
Begin 
print @frag
print @tablename
SELECT @execstr = 'ALTER INDEX [' + RTRIM(@IndexName) + '] ON [' + RTRIM(@tablename) + '] REBUILD WITH ( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, SORT_IN_TEMPDB = OFF, ONLINE = OFF )' 
print @execstr
EXEC (@execstr); 
--更新统计信息 
IF @TmpName<>@tablename 
BEGIN 
SET @tmpName=@tableName 
print @tablename
EXEC ('UPDATE STATISTICS '+@TableName + ' WITH FULLSCAN ') 
END 
End 


FETCH NEXT 
FROM indexes 
INTO @tablename, @objectid, @IndexName,@indexid, @frag; 
END; 

-- Close and deallocate the cursor. 
CLOSE indexes; 
DEALLOCATE indexes; 

-- Delete the temporary table. 
DROP TABLE #fraglist; 
GO 