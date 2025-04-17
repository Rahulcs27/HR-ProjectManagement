drop table Tbl_CountryMaster

Go 

Create Table Tbl_CountryMaster(

 CountryId int Identity (1,1) primary key,
 CountryName NVARCHAR(100) null,
 CountryCode CHAR(3) null,
 

 CreatedBy  int null,
 CreatedDate DateTime2 null,

 UpdatedBy NVARCHAR(50) null,
 UpdatedDate DateTime2 null,

 CountryStatus BIT null

);



