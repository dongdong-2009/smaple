--Child proc
CREATE PROCEDURE myproc
AS

SELECT OBJECT_NAME(@@PROCID)
GO

EXEC myproc


  