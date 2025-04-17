EXEC SP_HolidayInsert 
    @HolidayName = 'Independence Day',
    @HolidayDate = '2025-08-15',
    @HolidayListType = 'Non-US Holiday',
    @Year = 2025,
    @HolidayStatus = 1,
    @CreatedBy = 1;



EXEC SP_HolidayUpdate 
    @HolidayId = 2,
    @HolidayName = 'Good Friday',
    @HolidayDate = '2025-04-18',
    @HolidayListType = 'US Holiday',
    @Year = 2025,
    @HolidayStatus = 1,
    @UpdatedBy = 1;


EXEC usp_DeleteHoliday 
    @HolidayId = 1,
    @UpdatedBy = 1;


EXEC GetHolidays;

EXEC GetHolidays 
  @HolidayListType = 'US Holiday',
  @Year = 2025;
