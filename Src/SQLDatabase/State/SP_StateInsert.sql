CREATE OR ALTER PROCEDURE dbo.SP_StateInsert
    @Fk_CountryId INT,
    @StateName NVARCHAR(100),
    @StateCode CHAR(3),
    @StateStatus BIT,
    @CreatedBy INT
AS
BEGIN
    INSERT INTO Tbl_StateMaster (
        Fk_CountryId, StateName, StateCode, StateStatus, 
        CreatedBy, CreatedDate
    )
    VALUES (
        @Fk_CountryId, @StateName, @StateCode, @StateStatus,
        @CreatedBy, GETDATE()
    );

    SELECT 'State Added Successfully' AS Message;
END;
