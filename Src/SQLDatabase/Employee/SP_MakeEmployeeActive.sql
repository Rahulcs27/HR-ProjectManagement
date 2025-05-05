
DROP PROCEDURE IF EXISTS [dbo].SP_MakeEmployeeActive;
GO

CREATE PROCEDURE dbo.SP_MakeEmployeeActive
    @Code VARCHAR(20)
AS
BEGIN
    UPDATE dbo.Tbl_Employee_master
    SET LoginStatus = 1
    
    WHERE Code = @Code;

    SELECT 'Employee is Actived  Successfully' AS Message;
END;
exec dbo.SP_MakeEmployeeActive @Code=EMP001;
select * from dbo.Tbl_EmployeeMaster;