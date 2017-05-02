USE [msdb]
GO

/****** Object:  Job [HPDBA_DatabaseBackup - System Databases - Full]    Script Date: 10/13/2014 3:04:47 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [Database Maintenance]    Script Date: 10/13/2014 3:04:48 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'HPDBA_DatabaseBackup - System Databases - Full', 
		@enabled=1, 
		@notify_level_eventlog=2, 
		@notify_level_email=2, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'Backup all System databases', 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'sa', 
		@notify_email_operator_name=N'SOESQL', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Check for backup directories]    Script Date: 10/13/2014 3:04:50 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Check for backup directories', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'
SET NOCOUNT ON
CREATE TABLE #SubDirs (
	Directory varchar(200)
	)
DECLARE  @BackupDirectory nvarchar(260) 
	,@GetSubDirectories varchar(255) 
	,@DatabaseName varchar(255)
	,@CreateSubDirsCmd VARCHAR(255)
	,@Database varchar(128)
--*** Set Backup Directory ***
SET @BackupDirectory = ''I:\SOEBackups''
SELECT @GetSubDirectories = ''xp_cmdshell ''''dir "'' + @BackupDirectory + ''" /AD /B''''''
INSERT #SubDirs Execute (@GetSubDirectories)
IF EXISTS (SELECT name from master.dbo.sysdatabases WHERE name NOT IN (SELECT Directory FROM #SubDirs WHERE Directory IS NOT NULL) AND name in (''master'', ''msdb'',  ''model'',''SYSAdmin''))
	BEGIN
	DECLARE CreateSubDirs CURSOR FOR SELECT name FROM master.dbo.sysdatabases WHERE name NOT IN (SELECT Directory FROM #SubDirs WHERE Directory IS NOT NULL) AND name in (''SYSAdmin'',''master'', ''model'', ''msdb'')
	OPEN  CreateSubDirs
	FETCH NEXT FROM CreateSubDirs INTO  @Database
	WHILE @@FETCH_STATUS = 0
		BEGIN
		SELECT @CreateSubDirsCmd = ''EXECUTE xp_cmdshell ''''md "'' + @BackupDirectory + ''\'' + @Database + ''"'''', no_output''
		PRINT @CreateSubDirsCmd
		EXECUTE (@CreateSubDirsCmd)
		PRINT ''FULL System database backup job created directory '' + @BackupDirectory + @Database
		FETCH NEXT FROM CreateSubDirs INTO  @Database
		END
	CLOSE CreateSubDirs
	DEALLOCATE CreateSubDirs
	END
DROP TABLE #SubDirs
', 
		@database_name=N'master', 
		@output_file_name=N'I:\SOEBackups\FULL_System_Backup_$(ESCAPE_SQUOTE(STRTDT))_$(ESCAPE_SQUOTE(STRTTM)).txt', 
		@flags=4
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Backup database]    Script Date: 10/13/2014 3:04:51 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Backup database', 
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
DECLARE  @BackupCommand VARCHAR (1000)
	,@TimeStamp VARCHAR(20)
	,@DBName VARCHAR (128)
        ,@status BIT
	,@BackupDirectory VARCHAR(200)
	,@dbid int
	,@Restart VARCHAR(50)
--*** Set Backup Directory ***
SET @BackupDirectory = ''I:\SOEBackups''
DECLARE DB_name_cursor CURSOR 
FOR SELECT name FROM master..sysdatabases 
WHERE name in (''master'', ''msdb'',''model'',''SYSAdmin'')  order by name
OPEN DB_name_cursor
FETCH NEXT FROM DB_name_cursor INTO @DBName
WHILE (@@Fetch_Status = 0)
BEGIN
	SET @TimeStamp =  convert( char (8), getdate(),112) + substring( convert( char (15), getdate(),113), 13, 2) + substring( convert( char (18), getdate(),113), 16, 2)
  	SET @BackupCommand = ''backup database '' + ''['' +  @DBName + '']''+ '' to disk = '''''' + @BackupDirectory + ''\'' + @DBName + ''\'' + @DBName + ''_FULL_'' + @TimeStamp + ''.bak''''''
	PRINT @BackupCommand
  	EXEC (@BackupCommand)
	PRINT '' -------------------------------------*** -------------------------------------''
	FETCH NEXT FROM DB_name_cursor INTO @DBName	                 
END
CLOSE DB_name_cursor
DEALLOCATE DB_name_cursor
', 
		@database_name=N'master', 
		@output_file_name=N'I:\SOEBackups\FULL_System_Backup_$(ESCAPE_SQUOTE(STRTDT))_$(ESCAPE_SQUOTE(STRTTM)).txt', 
		@flags=6
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'SystemFullBackup', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20050804, 
		@active_end_date=99991231, 
		@active_start_time=14500, 
		@active_end_time=235959, 
		@schedule_uid=N'c3742a89-07df-4b69-be0a-f12ac16a680f'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


