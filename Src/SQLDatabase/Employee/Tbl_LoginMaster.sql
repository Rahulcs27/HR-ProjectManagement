CREATE TABLE [dbo].[Tbl_LoginMaster] (
    [fk_EmpId]        INT NULL,
    [UserName]        VARCHAR(20) NULL,
    [Password]        VARCHAR(20) NULL,
    [pk_LoginId]      INT NOT NULL,
    [CreatedBy]       INT NULL,
    [CreatedDate]     DATETIME2(7) NULL,
    [UpdatedBy]       INT NULL,
    [UpdatedDate]     DATETIME2(7) NULL,
    [Email]           VARCHAR(100) NULL,
    
    
    CONSTRAINT [PK_Tbl_LoginMaster] PRIMARY KEY CLUSTERED ([pk_LoginId] ASC),
    
    CONSTRAINT [FK_Tbl_LoginMaster_fk_EmpId]
        FOREIGN KEY ([fk_EmpId])
        REFERENCES [dbo].[Tbl_Employee_master] ([Id])
) ON [PRIMARY];


alter table dbo.Tbl_LoginMaster
add FirstLogin BIT DEFAULT 1;

alter table dbo.Tbl_LoginMaster
add RoleName nvarchar(50);