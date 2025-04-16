Create procedure DeleteLocation_
	@LocationId int,
	@DeletedBy Nvarchar(20)

As
Begin

UPDATE Location_
	set LocationStatus = 0,
	WhoDeleted = @DeletedBy,
	WhenDeleted = GetDate(),
	Action = 'Delete'
	where LocationId = @LocationId 

	SELECT 'Location Deleted Successfully' AS Message;

end

	
		