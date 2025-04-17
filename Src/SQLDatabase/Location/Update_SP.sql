create procedure  UpdateLocation_

	@CityId int,
	@LocationId int,
	@StateId int,
	@CountryID int,
	@LocationName NVARCHAR(10),
	@Action NVARCHAR(10),
	@LocationStatus bit,
	@WHoUpdated NVARCHAR(10)

As
Begin
	
	update Location_

	set 
		LocationName = @LocationName,
        StateId = @StateId,
        CountryId = @CountryId,
        LocationStatus = @LocationStatus,
        Action = @Action,
        WhoUpdated = @WhoUpdated,
        WhenUpdated = GETDATE()
    WHERE LocationId = @LocationId and LocationStatus=1;

		
SELECT 'Location Updated Successfully' AS Message;
END

