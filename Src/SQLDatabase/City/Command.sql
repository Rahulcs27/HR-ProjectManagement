EXEC AddCity_ @CityName = 'Pune', @StateId = 1, @CountryId = 1, @CityStatus = 1, @Action = 'Insert', @WhoInserted = 'admin';

EXEC UpdateCity_ @CityId = 1, @CityName = 'Mumbai', @StateId = 1, @CountryId = 1, @CityStatus = 1, @Action = 'Update', @WhoUpdated = 'admin';

EXEC DeleteCity_ @CityId = 1, @WhoDeleted = 'admin';

EXEC GetAllCities_;

EXEC GetCityById_ @CityId = 1;
