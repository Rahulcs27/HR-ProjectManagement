CREATE PROCEDURE DeleteCity_
    @CityId INT,
    @WhoDeleted NVARCHAR(50)
AS
BEGIN
    UPDATE City_
    SET 
        IsDeleted = 1,
        WhoDeleted = @WhoDeleted,
        WhenDeleted = GETDATE()
    WHERE CityId = @CityId;

    SELECT 'City Deleted Successfully' AS Message;
END
