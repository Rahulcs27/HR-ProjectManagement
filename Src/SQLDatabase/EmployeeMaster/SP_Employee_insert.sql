USE [HrModule]
GO
/****** Object:  StoredProcedure [dbo].[SP_Employee_insert]    Script Date: 4/24/2025 5:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[SP_Employee_insert]
    @Name VARCHAR(20),
    @Code VARCHAR(20),
	@Address varchar(250) null,
	@MobileNo varchar(20),
	@SkypeId varchar(20) null,
	@JoinDate DateTime2 ,
	@Email varchar(50),
	@BccEmail varchar(50) null,
	@PanNumber varchar(20),
	@BirthDate dateTime null,
	@Image varbinary(max) null,
	@Signature varbinary(max) null,
	@LoginStatus bit ,
	@leftCompany bit null,
	@leftDate datetime2,
	@Fk_LocationId int,
	@Fk_DesignationId int,
	@Fk_ShiftId int ,
	@Fk_EmployeeTypeId int ,
	@Fk_UserGroupId int ,
	@Fk_BranchId int,
	@Fk_DivisionId int
AS
BEGIN
    INSERT INTO Tbl_Employee_master (Name, Code, Address, MobileNo, SkypeId, JoinDate, Email, BccEmail, PanNumber,Birthdate,Image,
	Signature,LoginStatus,LeftCompany, leftdate, Fk_LocationId, Fk_DesignationId, Fk_ShiftId,
	Fk_EmployeeTypeId, Fk_UserGroupId, Fk_DivisionId, Fk_BranchId )

    VALUES (@Name, @Code, @Address, @MobileNo, @SkypeId, @JoinDate, @Email, @BccEmail, 
	@PanNumber, @Birthdate,@Image,@Signature,@LoginStatus, @LeftCompany, @leftdate, @fk_LocationId, 
	@Fk_DesignationId, @Fk_ShiftId, @Fk_EmployeeTypeId, @Fk_UserGroupId, @Fk_BranchId, @Fk_DivisionId );
END;

select * from Tbl_Employee_master