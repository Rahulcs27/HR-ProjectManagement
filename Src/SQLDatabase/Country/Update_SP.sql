CREATE PROCEDURE UpdateCountry_sp
    @CountryId INT,
    @CountryName NVARCHAR(100),
    @CountryCode NVARCHAR(20),
    @CounStatus BIT,
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Country_
    SET CountryName = @CountryName,
        CountryCode = @CountryCode,
        CountryStatus = @CounStatus,
        WhoUpdated = @UpdatedBy,
        WhenUpdated = GETDATE(),
        Action = 'Update'
    WHERE CountryId = @CountryId;
END
