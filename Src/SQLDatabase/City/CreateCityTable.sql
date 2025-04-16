CREATE TABLE City_ (
    CityId INT IDENTITY(1,1) PRIMARY KEY,
    
    CityName NVARCHAR(100) NOT NULL,
    
    StateId INT NOT NULL,
    CountryId INT NOT NULL,
    
    CityStatus BIT,
    Action NVARCHAR(10),

    WhoInserted NVARCHAR(50) NULL,
    WhenInserted DATETIME NULL,

    WhoUpdated NVARCHAR(50) NULL,
    WhenUpdated DATETIME NULL,

    WhoDeleted NVARCHAR(50) NULL,
    WhenDeleted DATETIME NULL,

    IsDeleted BIT DEFAULT 0,

    CONSTRAINT FK_City_State FOREIGN KEY (StateId) REFERENCES State_(StateId),
    CONSTRAINT FK_City_Country FOREIGN KEY (CountryId) REFERENCES Country_(CountryId)
);
