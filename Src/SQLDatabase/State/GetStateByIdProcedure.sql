CREATE PROCEDURE GetStateById_
    @StateId INT
AS
BEGIN
    SELECT 
        S.StateId,
        S.StateName,
        S.StateCode,
        S.StateStatus,
        S.Action,
        C.CountryName,
        S.CountryId
    FROM State_ S
    INNER JOIN Country_ C ON S.CountryId = C.CountryId
    WHERE S.StateId = @StateId AND S.WhenDeleted IS NULL;
END
