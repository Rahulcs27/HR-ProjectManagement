CREATE PROCEDURE GetAllCities_
AS
BEGIN
    SELECT 
        C.CityId,
        C.CityName,
        C.CityStatus,
        C.Action,
        C.StateId,
        S.StateName,
        C.CountryId,
        CO.CountryName
    FROM City_ C
    INNER JOIN State_ S ON C.StateId = S.StateId
    INNER JOIN Country_ CO ON C.CountryId = CO.CountryId
    WHERE C.IsDeleted = 0
    ORDER BY C.CityName;
END
