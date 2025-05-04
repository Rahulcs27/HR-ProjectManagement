EXEC SP_LocationInsert 
    @Fk_CityId = 1, 
    @LocationName = 'Dadar', 
    @LocationStatus = 1, 
    @CreatedBy = 1;

Go

EXEC SP_LocationUpdate
    @LocationId = 2, 
    @LocationName = 'Rabale', 
    @LocationStatus = 1, 
    @UpdatedBy = 1;

EXEC SP_LocationDelete
	@LocationId = 4,
	@UpdatedBy =1;

EXEC SP_GetLocationById @LocationId = 1;

	select * from Tbl_LocationMaster;

	


