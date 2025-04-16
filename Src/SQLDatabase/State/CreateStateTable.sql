CREATE TABLE State_ (
    StateId INT IDENTITY(1,1) PRIMARY KEY,
    CountryId INT NOT NULL, -- Foreign key
    StateName NVARCHAR(256) NOT NULL,
    StateCode NVARCHAR(10) NOT NULL,
    StateStatus BIT NOT NULL, -- Active/Inactive
    Action NVARCHAR(10),
    
    WhoInserted NVARCHAR(50) NULL,
    WhenInserted DATETIME NULL,
    
    WhoUpdated NVARCHAR(50) NULL,
    WhenUpdated DATETIME NULL,
    
    WhoDeleted NVARCHAR(50) NULL,
    WhenDeleted DATETIME NULL,

    CONSTRAINT FK_State_Country FOREIGN KEY (CountryId) REFERENCES Country_(CountryId)
);
