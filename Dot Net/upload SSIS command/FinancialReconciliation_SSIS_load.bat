del FinancialReconciliation.tmp
del FinancialReconciliation.bat 
dtutil /fcreate SQL;\;"Financial Reconciliation" /SourceServer %1 /SourceUser SSISuser /SourcePassword Pitoaadp!123

for %%f in (ALH*.dtsx) do echo dtutil /Quiet /FILE %%f /DestServer %1 /DestUser SSISuser /DestPassword Pitoaadp!123  /COPY SQL;"Financial Reconciliation"\%%~nf  >> FinancialReconciliation.tmp
for /F "eol=; tokens=1,2,3,4,5,6* delims=." %%i in (FinancialReconciliation.tmp) do @echo %%i.%%j.%%k.%%l.%%m.%%n%%o >> FinancialReconciliation".bat
del FinancialReconciliation.tmp 
call FinancialReconciliation.bat 2>&1 > FinancialReconciliation_load.log 
del FinancialReconciliation.bat 

echo Package load completed, check FinancialReconciliation_load.log for errors.

