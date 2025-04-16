CREATE PROCEDURE DeleteCountry_sp
    @CountryId INT,
    @DeletedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Country_
    SET CountryStatus = 0,
        WhoDeleted = @DeletedBy,
        WhenDeleted = GETDATE(),
        Action = 'Delete'
    WHERE CountryId = @CountryId;
END
