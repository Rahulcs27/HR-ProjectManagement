CREATE PROCEDURE DeleteState_
    @StateId INT,
    @WhoDeleted NVARCHAR(50)
AS
BEGIN
    UPDATE State_
    SET 
        WhoDeleted = @WhoDeleted,
        WhenDeleted = GETDATE()
    WHERE StateId = @StateId;

    SELECT 'State Deleted Successfully' AS Message;
END
