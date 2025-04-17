using HrModule

CREATE PROCEDURE SP_CountryDelete
    @CountryId INT
    
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Tbl_CountryMaster
    SET CountryStatus = 0
        
        
        
    WHERE CountryId = @CountryId;
END
