
CREATE OR ALTER PROCEDURE dbo.SP_DesignationDelete
    @DesignationId INT,
    @UpdatedBy INT
AS
BEGIN
    UPDATE Tbl_DesignationMaster
    SET 
        DesignationStatus = 0,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE DesignationId = @DesignationId;

    SELECT 'Division Deleted Successfully' AS Message;
END;
