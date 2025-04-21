EXEC sp_EmployeeModuleInsert
    @UserName = 'johndoe',
    @Email = 'johndoe@example.com',
    @Password = 'password123',
    @Profile = 'Software Engineer',
    @Name = 'John Doe',
    @EmployeeCode = 'EMP001',
    @Fk_DesignationId = 1,      -- Assuming Designation ID 1
    @Fk_BranchId = 1,          -- Assuming Branch ID 1
    @Fk_DivisionId = 1,        -- Assuming Division ID 1
    @Fk_EmployeeTypeId = 1,    -- Assuming Employee Type ID 1
    @LoginStatus = 1,          -- '1' for active login
    @CreatedBy = 1;            -- Assuming the creator's ID is 1

	Select * from Tbl_EmployeeModuleMaster;