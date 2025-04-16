EXEC InsertDivision 
    @DivisionName = 'DotNer',
    @ProjectManagerName = 'Rahul Suthar',
    @PrefixName = '.NET',
    @HolidayId = 1, -- should exist in Holiday_
    @ManHours = 8,
    @WhoInserted = 'HR';


EXEC UpdateDivision 
    @DivisionId = 1,
    @DivisionName = 'Angular',
    @ProjectManagerName = 'Rahul Suthar',
    @PrefixName = 'ANG',
    @HolidayId = 1,
    @ManHours = 7.5,
    @DivisionStatus = 1,
    @WhoUpdated = 'HR';

EXEC DeleteDivision 
    @DivisionId = 1,
    @WhoDeleted = 'HR';

EXEC GetAllDivisions;

EXEC GetDivisionById @DivisionId = 1;
