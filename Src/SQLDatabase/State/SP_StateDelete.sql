CREATE PROCEDURE SP_StateDelete
    @StateId INT,
    @UpdatedBy NVARCHAR(50)
AS
BEGIN
    UPDATE Tbl_StateMaster
    SET 
        StateStatus = 0,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE StateId = @StateId;

    SELECT 'State Deleted Successfully' AS Message;
END;
