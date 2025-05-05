CREATE OR ALTER PROCEDURE dbo.SP_TeamCompositionGetAll
AS
BEGIN
    SELECT 
        T.TeamId, T.TeamName, T.TeamStatus,
        B.BranchName, D.DivisionName, E.Name AS TeamLeader
    FROM Tbl_TeamComposition T
    INNER JOIN Tbl_BranchMaster B ON T.Fk_BranchId = B.BranchId
    INNER JOIN Tbl_DivisionMaster D ON T.Fk_DivisionId = D.DivisionId
    INNER JOIN Tbl_Employee_master E ON T.Fk_TeamLeaderId = E.Id
    WHERE T.TeamStatus = 1;
END;
