USE master;
GO

if exists (select * from sysdatabases where name='HotelReservationSystem2')
begin
 DECLARE @kill varchar(8000) = ''; 
 SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';' 
 FROM sys.dm_exec_sessions
 WHERE database_id = db_id('HotelReservationSystem2')
 EXEC(@kill)
 
 DROP DATABASE HotelReservationSystem2
end
GO



CREATE DATABASE HotelReservationSystem2
GO



USE HotelReservationSystem2
GO



CREATE TABLE Amenities(
	AmenitiesId int IDENTITY(1,1) PRIMARY KEY,
	Amenities nvarchar(50) NOT NULL
)


CREATE TABLE RoomInfo(
	RoomInfoId int IDENTITY(1,1) PRIMARY KEY,
	Number int NOT NULL,
	[Floor] int NOT NULL,
	OccupancyLimit smallint NOT NULL
 )

 CREATE TABLE BedType(
	BedTypeId int IDENTITY(1,1) PRIMARY KEY,
	[Type] nvarchar(50) NOT NULL

)

CREATE TABLE RoomRate(
	RoomRateId int IDENTITY(1,1) PRIMARY KEY,
	BedTypeId int FOREIGN KEY REFERENCES BedType(BedTypeId),
	Rate decimal(18, 0) NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL
)


CREATE TABLE Customer(
	CustomerId int IDENTITY(1,1) PRIMARY KEY,
	Customer nvarchar(50) NOT NULL,
	Phone nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL
 )

 CREATE TABLE Promotion(
	PromotionId int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
	[Type] nvarchar(50) NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	[Value] decimal(18, 0) NOT NULL
)


 CREATE TABLE Billing(
	BillingId int IDENTITY(1,1) PRIMARY KEY,
	Total decimal(18, 0) NOT NULL,
	Tax decimal(18, 0) NOT NULL,
	PromotionId int FOREIGN KEY REFERENCES Promotion(PromotionId)

	)




CREATE TABLE Reservation(
	ReservationId int IDENTITY(1,1) PRIMARY KEY,
	CustomerId int FOREIGN KEY REFERENCES Customer(CustomerId) NOT NULL,
	RoomReservedId int NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	BillingId int FOREIGN KEY REFERENCES Billing(BillingId) NOT NULL
)


CREATE TABLE Guest(
	GuestId int IDENTITY(1,1) PRIMARY KEY,
	GuestName nvarchar(50) NOT NULL,
	GuestAge smallint NULL,
	ReservationId int FOREIGN KEY REFERENCES Reservation(ReservationId)
)







CREATE TABLE RoomInfoAmenities(
	RoomInfoId int NOT NULL,
	AmenitiesId int NOT NULL,
	CONSTRAINT PK_RoomInfoAmenities PRIMARY KEY (RoomInfoId,AmenitiesID),
	CONSTRAINT FK_Amenities_RoomInfoAmenities FOREIGN KEY (AmenitiesId) REFERENCES Amenities(AmenitiesId),
	CONSTRAINT FK_RoomInfo_RoomInfoAmenities FOREIGN KEY (RoomInfoId) REFERENCES RoomInfo(RoomInfoId)
)

CREATE TABLE RoomBedType(
	RoomInfoId int NOT NULL,
	BedTypeId int NOT NULL,
	CONSTRAINT PK_RoomBedType PRIMARY KEY (RoomInfoId,BedTypeId),
	CONSTRAINT FK_BedType_RoomBedType FOREIGN KEY (BedTypeId) REFERENCES BedType(BedTypeId),
	CONSTRAINT FK_RoomInfo_RoomBedType FOREIGN KEY (RoomInfoId) REFERENCES RoomInfo(RoomInfoId)
) 


 
 CREATE TABLE RoomReserved(
	RoomReserveId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	RoomReservedStartDate date NOT NULL,
	RoomReservedEndDate date NOT NULL,
	RoomInfoId int FOREIGN KEY REFERENCES RoomInfo (RoomInfoId),
	RoomRateId int FOREIGN KEY REFERENCES RoomRate(RoomRateId) NOT NULL,
	ReservationId int FOREIGN KEY REFERENCES Reservation(ReservationId) NOT NULL

)




CREATE TABLE AddOn(
	AddOnId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Description] nvarchar(50) NOT NULL
	
) 


CREATE TABLE AddOnRate(
	AddOnId int FOREIGN KEY REFERENCES AddOn(AddOnId) NOT NULL,
	Rate decimal(18, 0) NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL
)



CREATE TABLE BillAddOn(
	BillingId int NOT NULL,
	BillAddOnDate date NOT NULL,
	BillAddOnCount smallint NOT NULL,
	AddOnId int NOT NULL,
	CONSTRAINT PK_BillinAddOn PRIMARY KEY (BillingId, AddOnId),
	CONSTRAINT FK_AddOnId_BillAddOn FOREIGN KEY  (AddOnId) REFERENCES AddOn(AddOnId),
	CONSTRAINT FK_BillingId_BillAddOn FOREIGN KEY (BillingId) REFERENCES Billing(BillingId)
) 















































