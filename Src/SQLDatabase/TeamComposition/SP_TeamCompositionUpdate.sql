CREATE OR ALTER PROCEDURE dbo.SP_TeamCompositionUpdate
    @TeamId INT,
    @TeamName NVARCHAR(100),
    @Fk_BranchId INT,
    @Fk_DivisionId INT,
    @Fk_TeamLeaderId INT,
    @TeamStatus BIT,
    @UpdatedBy INT
AS
BEGIN
    UPDATE Tbl_TeamComposition
    SET TeamName = @TeamName,
        Fk_BranchId = @Fk_BranchId,
        Fk_DivisionId = @Fk_DivisionId,
        Fk_TeamLeaderId = @Fk_TeamLeaderId,
        TeamStatus = @TeamStatus,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE TeamId = @TeamId;
END;
