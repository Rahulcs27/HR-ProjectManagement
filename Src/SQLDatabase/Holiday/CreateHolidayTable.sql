CREATE TABLE Holiday_(
    HolidayId INT IDENTITY(1,1) PRIMARY KEY,
    HolidayName NVARCHAR(30) NOT NULL,
    HolidayDate DATE NOT NULL,
    HolidayListType NVARCHAR(50) NOT NULL, -- US / Non-US
    Year INT NOT NULL,
    Status BIT DEFAULT 1,

    WhoInserted NVARCHAR(50) NULL,
    WhenInserted DATETIME NULL,
    
    WhoUpdated NVARCHAR(50) NULL,
    WhenUpdated DATETIME NULL,
    
    WhoDeleted NVARCHAR(50) NULL,
    WhenDeleted DATETIME NULL
);
