CREATE PROCEDURE DeleteHoliday
    @HolidayId INT,
    @WhoDeleted NVARCHAR(50)
AS
BEGIN
    UPDATE Holiday_
    SET Status = 0,
        WhoDeleted = @WhoDeleted,
        WhenDeleted = GETDATE()
    WHERE HolidayId = @HolidayId;
END
