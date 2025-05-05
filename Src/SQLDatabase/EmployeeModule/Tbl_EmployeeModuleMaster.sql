CREATE TABLE Tbl_EmployeeModuleMaster (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Profile VARCHAR(100),
    Name VARCHAR(100),
    EmployeeCode VARCHAR(20),
    Fk_DesignationId INT,
    Fk_BranchId INT,
    Fk_DivisionId INT,
    Fk_EmployeeTypeId INT,
    LoginStatus BIT,
    CreatedBy INT,
    CreatedDate DATETIME,

	FOREIGN KEY (Fk_DesignationId) REFERENCES Tbl_DesignationMaster(DesignationId),
	FOREIGN KEY (Fk_EmployeeTypeId) REFERENCES Tbl_EmployeeTypeMaster(EmployeeTypeId),
	FOREIGN KEY (Fk_DivisionId) REFERENCES Tbl_DivisionMaster(DivisionId),
    FOREIGN KEY (Fk_BranchId) REFERENCES Tbl_BranchMaster(BranchId)
    -- Foreign Keys and other constraints here...
);
