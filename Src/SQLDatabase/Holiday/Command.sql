EXEC InsertHoliday 
  @HolidayName = 'Republic Day',
  @HolidayDate = '2025-01-26',
  @HolidayListType = 'US Holiday',
  @Year = 2025,
  @WhoInserted = 'HR';

EXEC UpdateHoliday 
  @HolidayId = 1,
  @HolidayName = 'Updated Republic Day',
  @HolidayDate = '2025-01-27',
  @HolidayListType = 'US Holiday',
  @Year = 2025,
  @HolidayStatus = 1,
  @WhoUpdated = 'HR';

EXEC DeleteHoliday 
  @HolidayId = 1,
  @WhoDeleted = 'HR';

EXEC GetAllHoliday;

