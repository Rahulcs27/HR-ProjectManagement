CREATE OR ALTER PROCEDURE SP_CityInsert
    @Fk_StateId INT,
    @CityName NVARCHAR(100),
    @CityStatus BIT,
    @CreatedBy NVARCHAR(50)
AS
BEGIN
    INSERT INTO Tbl_CityMaster (
        Fk_StateId, CityName, CityStatus, CreatedBy, CreatedDate
    )
    VALUES (
        @Fk_StateId, @CityName, @CityStatus, @CreatedBy, GETDATE()
    );

    SELECT 'City Added Successfully' AS Message;
END;
