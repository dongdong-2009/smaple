--1.create table 
CREATE TABLE Employee
(
EmployeeID INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(100),
LastName VARCHAR(100),
CurrentPayScale DECIMAL
)
GO
INSERT INTO Employee(FirstName, LastName, CurrentPayScale)
VALUES
('Steve', 'Savage', 10000),
('Ranjit', 'Srivastava', 12000),
('Akram', 'Haque', 12000)
GO

--2.
--Enabling Change Tracking at Database Level
ALTER DATABASE BOM
SET CHANGE_TRACKING = ON
(CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON)
--AUTO_CLEANUP -> With this option you can switch ON or OFF automatic 
--tracking table clean up process
--CHANGE_RETENTION -> With this option, you can specify the time frame 
--for which tracked information will be maintained
--Enabling Change Tracking at Table Level
ALTER TABLE Employee
ENABLE CHANGE_TRACKING
WITH (TRACK_COLUMNS_UPDATED = ON)
--TRACK_COLUMNS_UPDATED -> With this option, you can include columns 
--also whose values were changed

--3.
SELECT * FROM sys.change_tracking_databases 
SELECT * FROM sys.change_tracking_tables
SELECT * FROM sys.internal_tables
WHERE parent_object_id = OBJECT_ID('Employee')

--4.
SELECT CHANGE_TRACKING_CURRENT_VERSION ()
SELECT CHANGE_TRACKING_MIN_VALID_VERSION(OBJECT_ID('Employee'))
SELECT * FROM CHANGETABLE 
(CHANGES Employee,0) as CT ORDER BY SYS_CHANGE_VERSION

--5.
INSERT INTO Employee(FirstName, LastName, CurrentPayScale)
VALUES('a', 'b', 10000)
GO
DELETE FROM Employee
WHERE EmployeeID = 2
GO
UPDATE Employee
SET CurrentPayScale = 15000, FirstName = 'Akramul'
WHERE EmployeeID = 3
GO
SELECT CHANGE_TRACKING_CURRENT_VERSION ()
SELECT CHANGE_TRACKING_MIN_VALID_VERSION(OBJECT_ID('Employee'))
SELECT * FROM CHANGETABLE 
(CHANGES Employee,0) as CT ORDER BY SYS_CHANGE_VERSION

--6.
-- Get all DML changes (Inserts, Updates and Deletes) after the previous synchronized version 
DECLARE @PreviousVersion bigint
SET @PreviousVersion = 1
SELECT CTTable.EmployeeID, CTTable.SYS_CHANGE_OPERATION, 
Emp.FirstName, Emp.LastName, Emp.CurrentPayScale,
CTTable.SYS_CHANGE_VERSION, CTTable.SYS_CHANGE_COLUMNS, CTTable.SYS_CHANGE_CONTEXT 
FROM CHANGETABLE (CHANGES Employee, @PreviousVersion) AS CTTable
LEFT OUTER JOIN Employee AS Emp
ON emp.EmployeeID = CTTable.EmployeeID
GO

--7.
-- Get column information impacted during updates
DECLARE @PreviousVersion bigint
SET @PreviousVersion = 1
SELECT CTTable.EmployeeID, CTTable.SYS_CHANGE_OPERATION, 
Emp.FirstName, Emp.LastName, Emp.CurrentPayScale,
[FirstNameChanged?] = 
CHANGE_TRACKING_IS_COLUMN_IN_MASK(COLUMNPROPERTY(OBJECT_ID('Employee'), 
'FirstName', 'ColumnId'), SYS_CHANGE_COLUMNS),
[LastNameChanged?] = 
CHANGE_TRACKING_IS_COLUMN_IN_MASK(COLUMNPROPERTY(OBJECT_ID('Employee'), 
'LastName', 'ColumnId'), SYS_CHANGE_COLUMNS),
[CurrentPayScaleChanged?] = 
CHANGE_TRACKING_IS_COLUMN_IN_MASK(COLUMNPROPERTY(OBJECT_ID('Employee'), 
'CurrentPayScale', 'ColumnId'), SYS_CHANGE_COLUMNS)
FROM CHANGETABLE (CHANGES Employee, @PreviousVersion) AS CTTable
LEFT OUTER JOIN Employee AS Emp
ON emp.EmployeeID = CTTable.EmployeeID
WHERE CTTable.SYS_CHANGE_OPERATION = 'U'
GO

--8.
-- specifying a context while changing the records
DECLARE @RequesterAppID varbinary(128) = CAST('MyCachingAppID' AS varbinary(128));
WITH CHANGE_TRACKING_CONTEXT (@RequesterAppID)
UPDATE Employee
SET CurrentPayScale = 20000
WHERE EmployeeID = 1 
GO
--The internal tracking table will store, associted context as well
SELECT CTTable.EmployeeID, CTTable.SYS_CHANGE_VERSION, 
CAST(CTTable.SYS_CHANGE_CONTEXT AS VARCHAR(128)) AS RequesterAppID
FROM CHANGETABLE(CHANGES Employee, 1) AS CTTable;
GO