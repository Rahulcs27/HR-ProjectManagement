CREATE OR ALTER PROCEDURE dbo.SP_HolidayInsert
    @HolidayName NVARCHAR(30),
    @HolidayDate DATE,
	@HolidayListType BIT,
    @Year INT,
    @CreatedBy INT
AS
BEGIN
    INSERT INTO Tbl_HolidayMaster (
        HolidayName,
        HolidayDate,
        HolidayListType,
        Year,
        HolidayStatus,
        CreatedBy,
        CreatedDate
    )
    VALUES (
        @HolidayName,
        @HolidayDate,
        @HolidayListType,
        @Year,
        1,
        @CreatedBy,
        GETDATE()
    );

    SELECT 'Holiday Inserted Successfully' AS Message;
END;
