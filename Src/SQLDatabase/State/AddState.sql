CREATE PROCEDURE AddState_
    @CountryId INT,
    @StateName NVARCHAR(256),
    @StateCode NVARCHAR(10),
    @StateStatus BIT,
    @Action NVARCHAR(10),
    @WhoInserted NVARCHAR(50)
AS
BEGIN
    INSERT INTO State_ (CountryId, StateName, StateCode, StateStatus, Action, WhoInserted, WhenInserted)
    VALUES (@CountryId, @StateName, @StateCode, @StateStatus, @Action, @WhoInserted, GETDATE());

    SELECT 'State Added Successfully' AS Message;
END
