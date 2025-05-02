DROP PROCEDURE IF EXISTS [dbo].[SP_InsertRoles];
GO

CREATE PROCEDURE [dbo].[SP_InsertRoles]
    @RoleName NVARCHAR(50),
    @CreatedBy INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Tbl_RoleMaster] (
        RoleName,
        CreatedBy,
        CreatedDate
    )
    VALUES (
        @RoleName,
        @CreatedBy,
        GETDATE()
    );
END
GO

EXEC dbo.SP_InsertRoles @RoleName = 'User', @CreatedBy = 1;
select * from dbo.Tbl_RoleMaster;