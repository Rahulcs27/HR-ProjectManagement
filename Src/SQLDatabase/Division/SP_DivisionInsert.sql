
CREATE OR ALTER PROCEDURE usp_AddDivision
    @DivisionName NVARCHAR(75),
    @ProjectManagerName NVARCHAR(100),
    @PrefixName NVARCHAR(20),
    @Fk_HolidayId INT,
    @ManHours FLOAT,
    @DivisionStatus BIT,
    @CreatedBy INT
AS
BEGIN
    INSERT INTO Tbl_DivisionMaster (
        DivisionName, ProjectManagerName, PrefixName,
        Fk_HolidayId, ManHours, DivisionStatus,
        CreatedBy, CreatedDate
    )
    VALUES (
        @DivisionName, @ProjectManagerName, @PrefixName,
        @Fk_HolidayId, @ManHours, @DivisionStatus,
        @CreatedBy, GETDATE()
    );

    SELECT 'Division Added Successfully' AS Message;
END;
