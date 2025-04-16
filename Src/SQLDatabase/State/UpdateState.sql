CREATE PROCEDURE UpdateState_
    @StateId INT,
    @CountryId INT,
    @StateName NVARCHAR(256),
    @StateCode NVARCHAR(10),
    @StateStatus BIT,
    @Action NVARCHAR(10),
    @WhoUpdated NVARCHAR(50)
AS
BEGIN
    UPDATE State_
    SET 
        CountryId = @CountryId,
        StateName = @StateName,
        StateCode = @StateCode,
        StateStatus = @StateStatus,
        Action = @Action,
        WhoUpdated = @WhoUpdated,
        WhenUpdated = GETDATE()
    WHERE StateId = @StateId AND WhenDeleted IS NULL;

    SELECT 'State Updated Successfully' AS Message;
END
