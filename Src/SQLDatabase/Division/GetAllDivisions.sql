CREATE PROCEDURE GetAllDivisions
AS
BEGIN
    SELECT 
        D.DivisionId,
        D.DivisionName,
        D.ProjectManagerName,
        D.PrefixName,
        H.HolidayId,
        H.HolidayName,
        H.HolidayListType,
        H.HolidayDate,
        D.ManHours,
        D.DivisionStatus,
        D.WhenInserted,
        D.WhoInserted
    FROM Division_ D
    INNER JOIN Holiday_ H ON D.HolidayId = H.HolidayId
    WHERE D.DivisionStatus = 1
    ORDER BY D.DivisionName;
END
