CREATE PROCEDURE InsertDivision
    @DivisionName NVARCHAR(75),
    @ProjectManagerName NVARCHAR(100),
    @PrefixName NVARCHAR(20),
    @HolidayId INT,
    @ManHours FLOAT,
    @WhoInserted NVARCHAR(50)
AS
BEGIN
    INSERT INTO Division_ (
        DivisionName, ProjectManagerName, PrefixName, HolidayId,
        ManHours, DivisionStatus, WhoInserted, WhenInserted
    )
    VALUES (
        @DivisionName, @ProjectManagerName, @PrefixName, @HolidayId,
        @ManHours, 1, @WhoInserted, GETDATE()
    );

    SELECT 'Division Added Successfully' AS Message;
END
