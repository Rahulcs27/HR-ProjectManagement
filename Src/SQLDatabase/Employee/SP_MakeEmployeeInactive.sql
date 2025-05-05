

DROP PROCEDURE IF EXISTS dbo.SP_MakeEmployeeInactive;
GO

CREATE PROCEDURE dbo.SP_MakeEmployeeInactive
    @Code VARCHAR(20)
AS
BEGIN
    UPDATE dbo.Tbl_Employee_master
    SET LoginStatus = 0
    WHERE Code = @Code;

    SELECT 'Employee is inactive Successfully' AS Message;
END;


exec dbo.SP_MakeEmployeeInactive @Code='EMP1234';

select * from dbo.Tbl_Employee_master