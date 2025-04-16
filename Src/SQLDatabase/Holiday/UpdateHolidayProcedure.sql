CREATE PROCEDURE UpdateHoliday
    @HolidayId INT,
    @HolidayName NVARCHAR(30),
    @HolidayDate DATE,
    @HolidayListType NVARCHAR(50),
    @Year INT,
    @WhoUpdated NVARCHAR(50)
AS
BEGIN
    UPDATE Holiday_
    SET HolidayName = @HolidayName,
        HolidayDate = @HolidayDate,
        HolidayListType = @HolidayListType,
        Year = @Year,
        WhoUpdated = @WhoUpdated,
        WhenUpdated = GETDATE()
    WHERE HolidayId = @HolidayId;
END
