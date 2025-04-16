CREATE PROCEDURE DeleteDivision
    @DivisionId INT,
    @WhoDeleted NVARCHAR(50)
AS
BEGIN
    UPDATE Division_
    SET 
        DivisionStatus = 0,
        WhoDeleted = @WhoDeleted,
        WhenDeleted = GETDATE()
    WHERE DivisionId = @DivisionId;

    SELECT 'Division Deleted Successfully' AS Message;
END
