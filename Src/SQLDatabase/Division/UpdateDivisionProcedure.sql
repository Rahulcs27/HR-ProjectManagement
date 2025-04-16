CREATE PROCEDURE UpdateDivision
    @DivisionId INT,
    @DivisionName NVARCHAR(75),
    @ProjectManagerName NVARCHAR(100),
    @PrefixName NVARCHAR(20),
    @HolidayId INT,
    @ManHours FLOAT,
    @DivisionStatus BIT,
    @WhoUpdated NVARCHAR(50)
AS
BEGIN
    UPDATE Division_
    SET 
        DivisionName = @DivisionName,
        ProjectManagerName = @ProjectManagerName,
        PrefixName = @PrefixName,
        HolidayId = @HolidayId,
        ManHours = @ManHours,
        DivisionStatus = @DivisionStatus,
        WhoUpdated = @WhoUpdated,
        WhenUpdated = GETDATE()
    WHERE DivisionId = @DivisionId;

    SELECT 'Division Updated Successfully' AS Message;
END
