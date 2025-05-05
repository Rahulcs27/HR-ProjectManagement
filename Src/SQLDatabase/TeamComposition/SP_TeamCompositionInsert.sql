CREATE OR ALTER PROCEDURE dbo.SP_TeamCompositionInsert
    @TeamName NVARCHAR(100),
    @Fk_BranchId INT,
    @Fk_DivisionId INT,
    @Fk_TeamLeaderId INT,
    @CreatedBy INT
AS
BEGIN
    INSERT INTO Tbl_TeamComposition (TeamName, Fk_BranchId, Fk_DivisionId, Fk_TeamLeaderId, TeamStatus, CreatedBy, CreatedDate)
    VALUES (@TeamName, @Fk_BranchId, @Fk_DivisionId, @Fk_TeamLeaderId, 1, @CreatedBy, GETDATE());
END;
