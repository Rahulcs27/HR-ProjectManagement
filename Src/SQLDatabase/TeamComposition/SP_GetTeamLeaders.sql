CREATE OR ALTER PROCEDURE SP_GetTeamLeaders
AS
BEGIN
    SELECT E.Id, E.Name
    FROM Tbl_Employee_master E
    INNER JOIN Tbl_DesignationMaster D ON E.Fk_DesignationId = D.DesignationId
    WHERE D.DesignationName = 'Team Leader' AND E.LoginStatus = 1
END

