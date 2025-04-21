EXEC SP_TimeSheetMasterInsert
    @StartDate = '2024-04-01 09:00:00',
    @EndDate = '2024-04-30 18:00:00',
    @Fk_EmployeeId = 1, 
	
	@Fk_JobId =1,
    @CreatedBy = 1001;

	select * from Tbl_TimeSheetMaster

	delete  Tbl_TimeSheetMaster  where TimeSheetMasterId =3