CREATE PROCEDURE UpdateCity_
    @CityId INT,
    @CityName NVARCHAR(100),
    @StateId INT,
    @CountryId INT,
    @CityStatus BIT,
    @Action NVARCHAR(10),
    @WhoUpdated NVARCHAR(50)
AS
BEGIN
    UPDATE City_
    SET 
        CityName = @CityName,
        StateId = @StateId,
        CountryId = @CountryId,
        CityStatus = @CityStatus,
        Action = @Action,
        WhoUpdated = @WhoUpdated,
        WhenUpdated = GETDATE()
    WHERE CityId = @CityId AND IsDeleted = 0;

    SELECT 'City Updated Successfully' AS Message;
END
