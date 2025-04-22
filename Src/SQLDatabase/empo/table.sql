drop table Tbl_Employee_master

Create table Tbl_Employee_master(

Id int primary key identity(1,1),

Name varchar(20) not null,

DesignationId int not null,

Code varchar(20)not null,
 
 BranchId int not null,

 DivisionId int Not null,

 UserGroupId int not null

 foreign key (BranchId) references Tbl_BranchMaster(BranchId)
);

