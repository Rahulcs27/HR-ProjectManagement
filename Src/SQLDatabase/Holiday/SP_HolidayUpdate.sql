CREATE OR ALTER PROCEDURE SP_HolidayUpdate
    @HolidayId INT,
    @HolidayName NVARCHAR(30),
    @HolidayDate DATE,
    @HolidayListType NVARCHAR(50),
    @Year INT,
    @HolidayStatus BIT,
    @UpdatedBy INT
AS
BEGIN
    UPDATE Tbl_HolidayMaster
    SET 
        HolidayName = @HolidayName,
        HolidayDate = @HolidayDate,
        HolidayListType = @HolidayListType,
        Year = @Year,
        HolidayStatus = @HolidayStatus,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE HolidayId = @HolidayId;

    SELECT 'Holiday Updated Successfully' AS Message;
END;
