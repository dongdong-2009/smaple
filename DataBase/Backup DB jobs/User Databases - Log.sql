USE [msdb]
GO

/****** Object:  Job [HPDBA_DatabaseBackup - User Databases - Log]    Script Date: 10/13/2014 3:06:15 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [Database Maintenance]    Script Date: 10/13/2014 3:06:17 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'HPDBA_DatabaseBackup - User Databases - Log', 
		@enabled=1, 
		@notify_level_eventlog=2, 
		@notify_level_email=2, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'This job runs the Transaction Log Backups for all Online databases in the Full Recovery model.', 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'sa', 
		@notify_email_operator_name=N'SOESQL', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Check for log backup directories]    Script Date: 10/13/2014 3:06:19 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Check for log backup directories', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=3, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'
SET NOCOUNT ON
CREATE TABLE #SubDirs (
	Directory varchar(100)
	)
DECLARE  @BackupDirectory nvarchar(500) 
	,@GetSubDirectories varchar(500) 
	,@DatabaseName varchar(255) 
	,@CreateSubDirsCmd VARCHAR(500) 
	,@Database varchar(250)
--*** Set root backup path ***	
SET @BackupDirectory = ''I:\SOEBackups''
SELECT @GetSubDirectories = ''xp_cmdshell ''''dir "'' + @BackupDirectory + ''" /AD /B''''''
INSERT #SubDirs Execute (@GetSubDirectories)
IF EXISTS (SELECT name from master.dbo.sysdatabases WHERE name NOT IN (SELECT Directory FROM #SubDirs WHERE Directory IS NOT NULL) AND name NOT IN (''Northwind'', ''pubs'',''SYSAdmin''))
	BEGIN
	DECLARE CreateSubDirs CURSOR FOR SELECT name FROM master.dbo.sysdatabases WHERE dbid > 4 AND name NOT IN (SELECT Directory FROM #SubDirs WHERE Directory IS NOT NULL) AND name NOT IN (''Northwind'', ''pubs'',''SYSAdmin'')
	OPEN  CreateSubDirs
	FETCH NEXT FROM CreateSubDirs INTO  @Database
	WHILE @@FETCH_STATUS = 0
		BEGIN
		SELECT @CreateSubDirsCmd = ''EXECUTE xp_cmdshell ''''md "'' + @BackupDirectory + ''\'' + @Database + ''"'''', no_output''
		PRINT @CreateSubDirsCmd
		EXECUTE (@CreateSubDirsCmd)
		PRINT ''Transaction log backup job created directory ''  + @BackupDirectory  + @Database
		FETCH NEXT FROM CreateSubDirs INTO  @Database
		END
	CLOSE CreateSubDirs
	DEALLOCATE CreateSubDirs
	END
DROP TABLE #SubDirs
', 
		@database_name=N'master', 
		@output_file_name=N'I:\SOEBackups\TRAN_User_Backup_$(ESCAPE_SQUOTE(STRTDT))_$(ESCAPE_SQUOTE(STRTTM)).txt', 
		@flags=4
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Backup log]    Script Date: 10/13/2014 3:06:19 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Backup log', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'
SET NOCOUNT ON
--********************************************************************************************
-- FOR RESTART SET THE @RESTART to the database name that had the backup succesfully complete 
-- 
-- OTHERWISE @RESTART SHOULD BE = '' '' to a blank
--********************************************************************************************
CREATE TABLE #ExcludeDBs (
	dbname sysname
	)
INSERT #ExcludeDBs SELECT ''Northwind, pubs,sql_dba''
DECLARE  @BackupCommand VARCHAR (1000)
	,@TimeStamp VARCHAR(20)
	,@DBName VARCHAR (128)
        ,@status BIT
	,@BackupDirectory VARCHAR(500)
	,@Restart VARCHAR(128)
	,@dbid int
--********************************************************************************************
-- FOR RESTART SET THE @RESTART to the database name that had the backup succesfully complete 
-- 
-- OTHERWISE @RESTART SHOULD BE = '' '' to a blank
--********************************************************************************************
SET @Restart = '' '' 
IF @Restart <> '' '' 
   BEGIN
	SELECT @dbid = dbid FROM master..sysdatabases where name = @Restart
   END
ELSE
   BEGIN
	SET @dbid = 4	
   END
PRINT @dbid
--*** Set root backup path. ***
SET @BackupDirectory = ''I:\SOEBackups''
DECLARE DB_name_cursor CURSOR 
FOR SELECT name  FROM master..sysdatabases 
WHERE dbid > @dbid and name not in (''Northwind'', ''pubs'',''SYSAdmin'') and DATABASEPROPERTYEX(name, ''STATUS'') = ''ONLINE'' and DATABASEPROPERTYEX(name, ''Recovery'') <> ''SIMPLE'' and DATABASEPROPERTY(name,''IsReadOnly'') = 0 
ORDER BY name
OPEN DB_name_cursor
FETCH NEXT FROM DB_name_cursor INTO @DBName
WHILE (@@Fetch_Status = 0)
BEGIN
SELECT @status = DATABASEPROPERTY(@DBName, ''IsTruncLog'')
If @DBName NOT IN (SELECT dbname FROM #ExcludeDBs) 
  BEGIN
    IF @status = 0
      BEGIN
        SET @TimeStamp =  convert( char (8), getdate(),112) + substring( convert( char (15), getdate(),113), 13, 2) + substring( convert( char (18), getdate(),113), 16, 2)
        If @DBName IN 
          (SELECT Distinct a.name FROM master.dbo.sysdatabases a LEFT JOIN  msdb.dbo.backupset b ON
          a.name = b.database_name WHERE b.database_name is null AND a.name = @DBName)  

        		  SET @BackupCommand = ''backup database '' +  ''['' +  @DBName + '']''+ '' to disk = '''''' + @BackupDirectory + ''\'' + @DBName + ''\'' + @DBName + ''_FULL_'' + @TimeStamp + ''.bak''''''
	ELSE
          SET @BackupCommand = ''backup log '' + ''['' +  @DBName + '']''+ '' to disk = '''''' + @BackupDirectory + ''\'' + @DBName + ''\'' + @DBName + ''_TRAN_'' + @TimeStamp + ''.trn''''''
        PRINT @BackupCommand
        EXEC (@BackupCommand)
	PRINT '' -------------------------------------*** -------------------------------------''
      END
    ELSE
      BEGIN
        PRINT ''The transaction log for database '' + @DBName + '' was not backed up because the database is in truncate log mode.''
      END
    END
  FETCH NEXT FROM DB_name_cursor INTO @DBName	                 
END
CLOSE DB_name_cursor
DEALLOCATE DB_name_cursor
DROP TABLE #ExcludeDBs', 
		@database_name=N'master', 
		@output_file_name=N'I:\SOEBackups\TRAN_User_Backup_$(ESCAPE_SQUOTE(STRTDT))_$(ESCAPE_SQUOTE(STRTTM)).txt', 
		@flags=6
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Tran Log Backup Schedule', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=8, 
		@freq_subday_interval=1, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20020314, 
		@active_end_date=99991231, 
		@active_start_time=40000, 
		@active_end_time=235959, 
		@schedule_uid=N'49178ae0-b691-44c6-a6c2-853fc7f80c98'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


