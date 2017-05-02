del amer.tmp
del amer.bat 

dtutil /fcreate SQL;\;AMER /SourceServer %1 /SourceUser SSISuser /SourcePassword Pitoaadp!123
for %%f in (AMER*.dtsx) do echo dtutil /Quiet /FILE %%f /DestServer %1 /DestUser SSISuser /DestPassword Pitoaadp!123  /COPY SQL;AMER\%%~nf  >> AMER.tmp
for /F "eol=; tokens=1,2,3,4,5,6,7* delims=." %%i in (AMER.tmp) do @echo %%i.%%j.%%k.%%l.%%m.%%n%%o >> AMER.bat
del AMER.tmp 
call AMER.bat 2>&1 > AMER_Load.log 
del AMER.bat 
echo Package load completed, check AMER_load.log for errors.