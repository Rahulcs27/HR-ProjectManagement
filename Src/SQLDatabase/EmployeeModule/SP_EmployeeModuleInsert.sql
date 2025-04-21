CREATE OR ALTER PROCEDURE sp_EmployeeModuleInsert
    @UserName VARCHAR(50),
    @Email VARCHAR(100),
    @Password VARCHAR(255),
    @Profile VARCHAR(100),
    @Name VARCHAR(100),
    @EmployeeCode VARCHAR(20),
    @Fk_DesignationId INT,
    @Fk_BranchId INT,
    @Fk_DivisionId INT,
    @Fk_EmployeeTypeId INT,
    @LoginStatus BIT,
    @CreatedBy INT
AS
BEGIN
    -- Insert into Tbl_EmployeeModuleMaster
    INSERT INTO Tbl_EmployeeModuleMaster (
        UserName, Email, Password, Profile, Name, EmployeeCode, 
        Fk_DesignationId, Fk_BranchId, Fk_DivisionId, Fk_EmployeeTypeId, 
        LoginStatus, CreatedBy, CreatedDate
    )
    VALUES (
        @UserName, @Email, @Password, @Profile, @Name, @EmployeeCode, 
        @Fk_DesignationId, @Fk_BranchId, @Fk_DivisionId, @Fk_EmployeeTypeId, 
        @LoginStatus, @CreatedBy, GETDATE()
    );
END;
