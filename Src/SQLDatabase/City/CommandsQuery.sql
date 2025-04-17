EXEC SP_AddCity 
    @Fk_StateId = 1,              
    @CityName = 'Pune',
    @CityStatus = 1,
    @CreatedBy = 'HR';

EXEC SP_CityUpdate 
    @CityId = 1,                  
    @Fk_StateId = 1,              
    @CityName = 'Mumbai',
    @CityStatus = 1,
    @UpdatedBy = 'HR';

EXEC SP_CityDelete
    @CityId = 1,                   
    @UpdatedBy = 'admin';

EXEC SP_GetAllCities;

EXEC SP_GetCityById 
    @CityId = 1;
