Create PROCEDURE SP_InsertLoginForEmployee
    @EmpId INT,
    @Password VARCHAR(20),
    @CreatedBy INT,
    @Email VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserName VARCHAR(20);
    DECLARE @RoleName NVARCHAR(50);

    -- Get employee details including role
    SELECT 
        @UserName = E.Code,
        @Email = E.Email,
        @RoleName = U.UserGroupName
    FROM [dbo].[Tbl_Employee_master] E
    LEFT JOIN [dbo].[Tbl_UserGroupMaster] U ON E.Fk_UserGroupId = U.UserGroupId
    WHERE E.Id = @EmpId;

    -- Insert into LoginMaster
    INSERT INTO [dbo].[Tbl_LoginMaster] (
        fk_EmpId,
        UserName,
        Password,
        pk_LoginId,
        CreatedBy,
        CreatedDate,
        Email,
        FirstLogin,
        RoleName
    )
    VALUES (
        @EmpId,
        @UserName,
        @Password,
        (SELECT ISNULL(MAX(pk_LoginId), 0) + 1 FROM Tbl_LoginMaster),
        @CreatedBy,
        GETDATE(),
        @Email,
        1,
        @RoleName
    );
END



EXEC SP_InsertLoginForEmployee
    @EmpId = 9,
    @Password = 'Sumit@123',
    @CreatedBy = 1,
    @Email = NULL;  -- Will be overridden by employee's email in the procedure

  


select * from dbo.Tbl_LoginMaster;


Alter table dbo.Tbl_LoginMaster 
drop column RoleName ;

drop procedure  SP_InsertLoginForEmployee;