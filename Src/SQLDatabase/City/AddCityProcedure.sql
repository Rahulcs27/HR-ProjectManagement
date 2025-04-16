CREATE PROCEDURE AddCity_
    @CityName NVARCHAR(100),
    @StateId INT,
    @CountryId INT,
    @CityStatus BIT,
    @Action NVARCHAR(10),
    @WhoInserted NVARCHAR(50)
AS
BEGIN 
    INSERT INTO City_ (
        CityName, StateId, CountryId, CityStatus, Action,
        WhoInserted, WhenInserted, IsDeleted
    )
    VALUES (
        @CityName, @StateId, @CountryId, @CityStatus, @Action,
        @WhoInserted, GETDATE(), 0
    );

    SELECT 'City Added Successfully' AS Message;
END
