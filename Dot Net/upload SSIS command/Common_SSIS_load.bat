del COMMON.tmp
del COMMON.bat 
dtutil /fcreate SQL;\;COMMON /SourceServer %1 /SourceUser SSISuser /SourcePassword Pitoaadp!123

for %%f in (COMMON*.dtsx) do echo dtutil /Quiet /FILE %%f /DestServer %1 /DestUser SSISuser /DestPassword Pitoaadp!123  /COPY SQL;COMMON\%%~nf  >> COMMON.tmp
for /F "eol=; tokens=1,2,3,4,5,6,7* delims=." %%i in (COMMON.tmp) do @echo %%i.%%j.%%k.%%l.%%m.%%n%%o >> COMMON.bat
del Common.tmp 
call Common.bat 2>&1 > Common_load.log 
del Common.bat 

echo Package load completed, check Common_load.log for errors.

