CREATE TABLE Division_ (
    DivisionId INT IDENTITY(1,1) PRIMARY KEY,
    DivisionName NVARCHAR(75) NOT NULL,
    ProjectManagerName NVARCHAR(100) NOT NULL,
    PrefixName NVARCHAR(20),
    HolidayId INT NOT NULL, -- FK Holiday table
    ManHours FLOAT,
    DivisionStatus BIT DEFAULT 1,

    WhoInserted NVARCHAR(50),
    WhenInserted DATETIME,

    WhoUpdated NVARCHAR(50),
    WhenUpdated DATETIME,

    WhoDeleted NVARCHAR(50),
    WhenDeleted DATETIME,

    CONSTRAINT FK_Division_Holiday FOREIGN KEY (HolidayId) REFERENCES Holiday_(HolidayId)
);

CREATE TABLE Tbl_DivisionMaster (
    DivisionId INT IDENTITY(1,1) PRIMARY KEY,
    DivisionName NVARCHAR(75) NOT NULL,
    ProjectManagerName NVARCHAR(100) NOT NULL,
    PrefixName NVARCHAR(20),
    Fk_HolidayId INT NOT NULL,                    
    ManHours FLOAT,
    DivisionStatus BIT DEFAULT 1,            
    CreatedBy NVARCHAR(50),
    CreatedDate DATETIME2(7),
    UpdatedBy NVARCHAR(50),
    UpdatedDate DATETIME2(7),

    CONSTRAINT FK_Division_Holiday 
        FOREIGN KEY (Fk_HolidayId) REFERENCES Holiday_(HolidayId)
);
