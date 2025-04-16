EXEC AddState_ 
    @CountryId = 2,                 
    @StateName = 'Maharashtra',
    @StateCode = 'MH',
    @StateStatus = 1,
    @Action = 'Insert',
    @WhoInserted = 'HR';

EXEC UpdateState_
    @StateId = 2,                   
    @CountryId = 2,
    @StateName = 'Gujarat',
    @StateCode = 'GJ',
    @StateStatus = 1,
    @Action = 'Update',
    @WhoUpdated = 'HR';

EXEC DeleteState_
    @StateId = 1,                   
    @WhoDeleted = 'HR';

EXEC GetAllStates_;

EXEC GetStateById_
    @StateId = 1;
