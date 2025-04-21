CREATE PROCEDURE InsertHoliday
    @HolidayName NVARCHAR(30),
    @HolidayDate DATE,
    @HolidayListType NVARCHAR(50),
    @Year INT,
    @WhoInserted NVARCHAR(50)
AS
BEGIN
    INSERT INTO Holiday_(HolidayName, HolidayDate, HolidayListType, Year, WhoInserted, WhenInserted)
    VALUES (@HolidayName, @HolidayDate, @HolidayListType, @Year, @WhoInserted, GETDATE());
END
