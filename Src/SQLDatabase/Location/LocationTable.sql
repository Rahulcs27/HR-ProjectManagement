drop table  Location_

Go

create table Location_(

	LocationId int identity(1,1) primary key,
	LocationName NVARCHAR(20),
	CountryId int not null, 
	StateId int not null,
	CityId int not null,
	Action NVARCHAR(10),
	LocationStatus BiT,
    
    WhoInserted NVARCHAR(50) NULL,
    WhenInserted DATETIME NULL,
    
    WhoUpdated NVARCHAR(50) NULL,
    WhenUpdated DATETIME NULL,
    
    WhoDeleted NVARCHAR(50) NULL,
    WhenDeleted DATETIME NULL,

	constraint Fk_country foreign key (CountryId) REFERENCES Country_(CountryId),
	CONSTRAINT FK_City_State FOREIGN KEY (StateId) REFERENCES Rahul.State_(StateId),

	constraint Fk_city foreign key (CityId) References Rahul.City_(CityID)
 

);