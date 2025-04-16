drop procedure Insertlocation_
Go
create procedure Insertlocation_

	@CountryId int,
	@StateId int,
	@CityId int,
	@LocationName NVARCHAR(10),
	@LocationStatus bit,
	@Action NVARCHAR(10),
	@WhoInserted NVARCHAR(10)

As
Begin
	insert into Location_ (CountryId, StateId, CityId, LocationName,LocationStatus, Action, WhoInserted, WhenInserted )
	values (@CountryId, @StateId, @CityId, @LocationName,1, @Action, @WhoInserted, GetDate());

	print 'Added Successfully';

End




