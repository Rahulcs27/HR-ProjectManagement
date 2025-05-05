create table [dbo].Tbl_RoleMaster(
RoleId int IDENTITY(1,1) not null,
RoleName NVarchar(50),
[CreatedBy] INT NULL,
[CreatedDate] DATETIME2(7) NULL,
[UpdatedBy] INT NULL,
[UpdatedDate] DATETIME2(7) NULL,
CONSTRAINT PK_Tbl_RoleMaster PRIMARY KEY (RoleId))


drop table dbo.Tbl_RoleMaster;
