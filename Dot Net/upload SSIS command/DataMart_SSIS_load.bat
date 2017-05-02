del DataMart.tmp
del DataMart.bat 
dtutil /fcreate SQL;\;DataMart /SourceServer %1 /SourceUser SSISuser /SourcePassword Pitoaadp!123
for %%f in (DataMart_*.dtsx) do echo dtutil /Quiet /FILE %%f /DestServer %1 /DestUser SSISuser /DestPassword Pitoaadp!123  /COPY SQL;DataMart\%%~nf  >> DataMart.tmp
for /F "eol=; tokens=1,2,3,4,5,6* delims=." %%i in (DataMart.tmp) do @echo %%i.%%j.%%k.%%l.%%m%%n >> DataMart.bat
del DataMart.tmp 
call DataMart.bat 2>&1 > DataMart_Load.log 
del DataMart.bat  
echo Package load completed, check DataMart_load.log for errors.
