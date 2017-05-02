@echo off 
Set serverIP=
:Getip
set /p ServerIP=Enter Database Server IP address or 'end' to quit [130.175.21.100] :
if "%serverIP%" == "end" GOTO END
if "%serverIP%" == "" set serverIP="130.175.21.100"
pause
echo Pinging Server at IP %serverIP% 
PING -n 1   %serverIP% | FIND "TTL=" >NUL
IF ERRORLEVEL 1 GOTO Badip 
GOTO Goodip
:Badip 
ECHO Error pinging server IP %serverIP%
GOTO Getip
:Goodip
ECHO Ping Successful, Beginning load of SSIS packages to Database Server %serverIP% 
echo Loading APJ SSIS packages
@echo on 
echo Loading DataMart SSIS packages
Call DataMart_SSIS_load %serverIP% 
echo Loading Common SSIS packages 
Call Common_SSIS_load %serverIP%
echo Loading FinancialReconciliation SSIS packages 
Call FinancialReconciliation_SSIS_load %serverIP% 
echo Load AMER SSIS packages
call AMER_SSIS_load %serverIP%
@echo off
goto Done
:END
echo SSIS Package load aborted, no Packages loaded.
GOTO Lastline
:DONE
type DatMart_load.log > All_load.log
type Common_load.log >> All_load.log
echo Package load completed, check All_load.log for errors.
:Lastline