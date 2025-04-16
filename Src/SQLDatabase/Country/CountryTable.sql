Create Table Country_(
 CountryId int Identity (1,1) primary Key,
 CountryName NVARCHAR(100),
 CountryCode NVARCHAR(20),
 CountryStatus BIT ,
 Action NVARCHAR(10),
 WhoInserted  NVARCHAR(50) null,
 WhenInserted DateTime null,

 WhoUpdated NVARCHAR(50) null,
 WhenUpdated DateTime null,

 WhoDeleted NVARCHAR(50) null,
 WhenDeleted DateTime null
);
