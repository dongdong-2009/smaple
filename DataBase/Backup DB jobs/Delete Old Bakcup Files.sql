USE [msdb]
GO

/****** Object:  Job [HPDBA_DatabaseBackup - Delete Old Archived Files]    Script Date: 10/13/2014 3:02:51 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [Database Maintenance]    Script Date: 10/13/2014 3:02:52 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'HPDBA_DatabaseBackup - Delete Old Archived Files', 
		@enabled=1, 
		@notify_level_eventlog=2, 
		@notify_level_email=2, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'This job removes old backup files that have been archived.', 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'sa', 
		@notify_email_operator_name=N'SOESQL', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Tran Log backup files that have been archived]    Script Date: 10/13/2014 3:02:55 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Tran Log backup files that have been archived', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'ActiveScripting', 
		@command=N'
Set fso = CreateObject("Scripting.FileSystemObject")
BackupDirectory = "I:\SOEBackups"
Set BackupFolder = fso.GetFolder(backupdirectory)
Set files = BackupFolder.files
	For Each TranLog In files
			If lcase(fso.GetExtensionName(TranLog)) = "trn" And DateDiff("h", TranLog.DateLastModified, Now) > 48  then fso.DeleteFile(TranLog) End If
	Next
Set TranLogFolders = BackupFolder.SubFolders
For Each TLogFldr In TranLogFolders
	Set files = TLogFldr.files
		For Each TranLog In files
				If lcase(fso.GetExtensionName(TranLog)) = "trn" And DateDiff("h", TranLog.DateLastModified, Now) > 48  then fso.DeleteFile(TranLog) End If
		Next
Next
Set fso = Nothing
', 
		@database_name=N'VBScript', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Differential Backup files that have been archived]    Script Date: 10/13/2014 3:02:55 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Differential Backup files that have been archived', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'ActiveScripting', 
		@command=N'
Set fso = CreateObject("Scripting.FileSystemObject")
BackupDirectory = "I:\SOEBackups"
Set BackupFolder = fso.GetFolder(backupdirectory)
Set files = BackupFolder.files
	For Each DifferentialBK In files
			If lcase(fso.GetExtensionName(DifferentialBK)) = "diff" And DateDiff("d", DifferentialBK.DateLastModified, Now) > 6  then fso.DeleteFile(DifferentialBK) End If
	Next
Set DiffFolders = BackupFolder.SubFolders
For Each DiffFldr In DiffFolders
	Set files = DiffFldr.files
		For Each DifferentialBK In files
				If lcase(fso.GetExtensionName(DifferentialBK)) = "diff" And DateDiff("d", DifferentialBK.DateLastModified, Now) > 6  then fso.DeleteFile(DifferentialBK) End If
		Next
Next
Set fso = Nothing
', 
		@database_name=N'VBScript', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Full Backup files that have been archived]    Script Date: 10/13/2014 3:02:55 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Full Backup files that have been archived', 
		@step_id=3, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'ActiveScripting', 
		@command=N'
Set fso = CreateObject("Scripting.FileSystemObject")
BackupDirectory = "I:\SOEBackups"
Set BackupFolder = fso.GetFolder(backupdirectory)
Set files = BackupFolder.files
	For Each FULLBK In files
			If lcase(fso.GetExtensionName(FULLBK)) = "bak" And DateDiff("d", FULLBK.DateLastModified, Now) > 6  then fso.DeleteFile(FULLBK) End If
	Next
Set FULLFolders = BackupFolder.SubFolders
For Each FULLFldr In FULLFolders
	Set files = FULLFldr.files
		For Each FULLBK In files
				If lcase(fso.GetExtensionName(FULLBK)) = "bak" And DateDiff("d", FULLBK.DateLastModified, Now) > 6  then fso.DeleteFile(FULLBK) End If
		Next
Next
Set fso = Nothing
', 
		@database_name=N'VBScript', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Output Files]    Script Date: 10/13/2014 3:02:56 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Output Files', 
		@step_id=4, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=1, 
		@os_run_priority=0, @subsystem=N'ActiveScripting', 
		@command=N'
Set fso = CreateObject("Scripting.FileSystemObject")
BackupDirectory = "I:\SOEBackups"
Set BackupFolder = fso.GetFolder(backupdirectory)
Set Outputfiles = BackupFolder.files
For Each outputfile In Outputfiles
	If (lcase(fso.GetExtensionName(outputfile)) = "txt" Or lcase(fso.GetExtensionName(outputfile)) = "log") And DateDiff("d", outputfile.DateLastModified, Now) > 7  then fso.DeleteFile(outputfile) End If
Next
Set fso = Nothing
', 
		@database_name=N'VBScript', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Delete old backups Schedule', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=8, 
		@freq_subday_interval=1, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20090911, 
		@active_end_date=99991231, 
		@active_start_time=100, 
		@active_end_time=235959, 
		@schedule_uid=N'9ab6ea74-84f4-49cc-885b-08f5ac631236'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


