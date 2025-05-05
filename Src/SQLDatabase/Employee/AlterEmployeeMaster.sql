ALTER TABLE [dbo].[Tbl_Employee_master]
ADD fk_RoleId INT;

-- Step 2: Add the foreign key constraint
ALTER TABLE [dbo].[Tbl_Employee_master]
ADD CONSTRAINT FK_Tbl_Employee_master_RoleId
FOREIGN KEY (fk_RoleId)
REFERENCES [dbo].[Tbl_RoleMaster] (RoleId);



ALTER TABLE Tbl_Employee_master
DROP CONSTRAINT FK_Tbl_Employee_master_RoleId;

ALTER TABLE Tbl_Employee_master
DROP column fk_RoleId;

