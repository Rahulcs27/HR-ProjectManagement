CREATE OR ALTER PROCEDURE dbo.SP_LocationGetALL
AS
BEGIN
    SELECT 
        L.LocationId,
        L.LocationName,
        L.LocationStatus,

        S.StateId,
        S.StateName,

		CI.CityId,
		CI.CityName,

        CO.CountryId,
        CO.CountryName

    FROM Tbl_LocationMaster L
	INNER JOIN Tbl_CityMaster CI ON L.Fk_CityId = CI.CityId
    INNER JOIN Tbl_StateMaster S ON CI.Fk_StateId = S.StateId
    INNER JOIN Tbl_CountryMaster CO ON S.Fk_CountryId = CO.CountryId
    WHERE L.LocationStatus = 1;
END;


exec SP_LocationGetALL