EXEC AddCity_ @CityName = 'Pune', @StateId = 1, @CountryId = 2, @CityStatus = 1, @Action = 'Insert', @WhoInserted = 'HR';

EXEC UpdateCity_ @CityId = 1, @CityName = 'Mumbai', @StateId = 1, @CountryId = 2, @CityStatus = 1, @Action = 'Update', @WhoUpdated = 'HR';

EXEC DeleteCity_ @CityId = 1, @WhoDeleted = 'HR';

EXEC GetAllCities_;

EXEC GetCityById_ @CityId = 1;
