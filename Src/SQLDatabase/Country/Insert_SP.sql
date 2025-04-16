CREATE PROCEDURE InsertCountry_sp
    @CountryName NVARCHAR(100),
    @CountryCode NVARCHAR(20),
    @InsertedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Country_ (CountryName, CountryCode, CountryStatus, Action, WhoInserted, WhenInserted)
    VALUES (@CountryName, @CountryCode, 1, 'Insert', @InsertedBy, GETDATE());
END
