CREATE OR ALTER PROCEDURE SP_GetAllEmployeeSummary
AS
BEGIN
    SELECT 
        E.Image,
        E.Name,
        E.Code,
        D.DesignationName,
        B.BranchName,
        DV.DivisionName,
        UG.UserGroupName,
        E.LoginStatus,
        'Edit/Delete' AS Action
    FROM dbo.Tbl_Employee_master E
    INNER JOIN Tbl_DesignationMaster D ON E.Fk_DesignationId = D.DesignationId
    INNER JOIN Tbl_BranchMaster B ON E.Fk_BranchId = B.BranchId
    INNER JOIN Tbl_DivisionMaster DV ON E.Fk_DivisionId = DV.DivisionId
    LEFT JOIN Tbl_UserGroupMaster UG ON E.Fk_UserGroupId = UG.UserGroupId
END;


exec SP_GetAllEmployeeSummary;

select * from dbo.Tbl_Employee_master;