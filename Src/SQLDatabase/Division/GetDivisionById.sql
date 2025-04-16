CREATE PROCEDURE GetDivisionById
    @DivisionId INT
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
        D.ManHours,
        D.DivisionStatus
    FROM Division_ D
    INNER JOIN Holiday_ H ON D.HolidayId = H.HolidayId
    WHERE D.DivisionId = @DivisionId;
END
