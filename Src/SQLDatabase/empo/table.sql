drop table Tbl_Employee_master

Create table Tbl_Employee_master(
Id int primary key identity(1,1),
Name varchar(20) not null,
Code varchar(20)not null,
Address varchar(250),
MobileNo varchar(20) null,
SkypeId varchar(20) null,
JoinDate DateTime2 ,
Email varchar(50),
BccEmail varchar(50) null,
PanNumber varchar(20),
BirthDate dateTime,
Image varchar(50),
Signature varchar(50),
LoginStatus bit default 1,
leftCompany bit null,
leftDate datetime2 null,

Fk_LocationId int not null,
Fk_DesignationId int not null,
Fk_ShiftId int not null,
Fk_EmployeeTypeId int not null,
Fk_UserGroupId int not null,



foreign key (Fk_LocationId) references Tbl_LocationMaster(LocationId),
foreign key (Fk_DesignationId) references Tbl_DesignationMaster(DesignationId),
foreign key (Fk_ShiftId) references Tbl_ShiftMaster(ShiftId),
foreign key (Fk_EmployeeTypeId) references Tbl_EmployeeTypeMaster(EmployeeTypeId),
foreign key (Fk_UserGroupId) references Tbl_userGroupMaster(UsergroupId)




);






 
