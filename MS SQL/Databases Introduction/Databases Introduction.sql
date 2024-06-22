USE Minions
GO

--07. Create Table People

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture BINARY(2),
Height DECIMAL(5,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) CHECK (Gender IN ('m', 'f')) NOT NULL,
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('Ivan', null, 167.00, 67.00, 'm', '1996-05-15 16:33:22.222222', 'driver'),
('Maria', null, 187.00, 57.00, 'f', '1999-05-15 16:33:22.222222', 'model'),
('Peter', null, 197.00, 107.00, 'f', '1989-05-15 16:33:22.222222', 'engineer'),
('Valq', null, 157.00, 47.00, 'm', '1986-05-15 16:33:22.222222', 'teacher'),
('Kolio', null, 207.00, 167.00, 'm', '1976-05-15 16:33:22.222222', 'drunker')

--08. Create Table Users

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture BINARY(900),
LastLoginTime DATETIME2,
IsDeleted VARCHAR(5) CHECK(IsDeleted IN ('true', 'false'))

)

INSERT INTO Users (Username, [Password], ProfilePicture,LastLoginTime, IsDeleted)
VALUES
('Smith', 'pass', null, null, 'true'),
('Smit', 'pass1', null, null, 'true'),
('Smi', 'pass2', null, null, 'true'),
('Sm', 'pass', null, null, 'true'),
('S', 'pass4', null, null, 'true')

--09 Change Primary Key
ALTER TABLE Users 
alter column Id int not null

--13

create database Movies
go
use Movies
go
create table Directors
(
Id int primary key identity,
DirectorName nvarchar(30) not null,
Notes nvarchar(200)
)
create table Genres
(
Id int primary key identity,
GenreName nvarchar(30) not null,
Notes nvarchar(200)
)
create table Categories
(
Id int primary key identity,
CategoryName nvarchar(30) not null,
Notes nvarchar(200)
)
create table Movies
(
Id int primary key identity,
Title nvarchar(50) not null,
DirectorId int not null,
CopyrightYear date,
[Length] float,
GenreId int not null,
CategoryId int not null,
Rating float not null,
Notes nvarchar(max),
constraint FK_Movies_Directors foreign key (DirectorId) references Directors(Id),
constraint FK_Movies_Genres foreign key (GenreId) references Genres(Id),
constraint FK_Movies_Category foreign key (CategoryId) references Categories(Id)
)

insert into Directors (DirectorName, Notes) values
('Ivan', null),
('Ivan1', null),
('Ivan2', null),
('Ivan3', null),
('Ivan4', null)
insert into Genres (GenreName, Notes) values
('komedy', null),
('horrer', null),
('action', null),
('drama', null),
('triller', null)

insert into Categories (CategoryName, Notes) values
('18+', null),
('16', null),
('14', null),
('family', null),
('12', null)

insert into Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId,Rating) values
('Doom', 1, '2010', 96, 1, 1, 3),
('LOR', 2, '2000', 220, 2, 1, 10),
('Blade',3 , '1996', 100, 3, 3, 10),
('FF6', 4,'2016', 120, 1, 4, 6),
('It', 5,'2020', 180, 4, 5, 1)

--14.	Car Rental Database

--Using SQL queries create CarRental database with the following entities:
--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--Set the most appropriate data types for each column. Set a primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

create database CarRental
go
use CarRental
create table Categories
(
Id int primary key identity,
CategoryName varchar(30) not null,
DailyRate decimal(4,2) not null,
WeeklyRate decimal(4,2) not null,
MonthlyRate decimal(4,2) not null,
WeekendRate decimal(4,2) not null
)
create table Cars
(
Id int primary key identity,
PlateNumber char(8) not null,
Manufacturer varchar(30) not null,
Model varchar(30) not null,
CarYear date,
CategoryId int foreign key references Categories(Id),
Doors int,
Picture binary,
Condition varchar(50),
Available bit not null
)
create table Employees
(
Id int primary key identity,
FirstName varchar(30) not null,
LastName varchar(30) not null,
Title varchar(30),
Notes varchar(max)
)
create table Customers
(
Id int primary key identity,
DriverLicenceNumber char(4) not null,
FullName varchar(50) not null,
[Address] varchar(50),
City varchar(50),
ZIPCode char(4),
Notes varchar(max)
)
create table RentalOrders
(
Id int primary key identity,
EmployeeId int foreign key references Employees(Id),
CustomerId int foreign key references Customers(Id),
CarId int foreign key references Cars(Id),
TankLevel float,
KilometrageStart float not null,
KilometrageEnd float not null,
TotalKilometrage float not null,
StartDate datetime2,
EndDate datetime2,
TotalDays int not null,
RateApplied decimal(4,2) not null,
TaxRate decimal(4,2) not null,
OrderStatus varchar(30) not null,
Notes varchar(max)
)

insert into Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
values
('Luxury ', 1.00, 1.00,1,1)
('Hybrid ', 10.5, 60.05, 50.99, 25.90),
('Economy', 10.50, 60.05, 20.99, 50.90)

insert into Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition,Available)
values
('ca1324kk', 'Renauth', 'clio', '2003', 13, 2, null, 'used', 1),
('ca1325kk', 'BMW', 'x5', '2023', 11, 5, null, 'perfect', 1),
('ca1326kk', 'Mercedes', 'eqs', '2020', 12, 4, null, 'used', 1)

insert into Employees (FirstName, LastName, Title, Notes)
values
('ben', 'simons', 'engineer', null),
('ken', 'petri', 'qa', null),
('sven', 'capry', 'cleaner', null)

insert into Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode,Notes)
values
('1234', 'karl antony', null, 'Mineapolis', null,null),
('1234', 'karl folt', null, 'LA', null,null),
('1234', 'karl send', null, 'Boston', null,null)

insert into RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
values
(1, 1, 4, 60, 1000, 2000, 1000, null, null, 3, 10, 10.00, 'ok', null),
(2, 2, 5, 60, 1000, 2000, 1000, null, null, 3, 10, 10, 'ok', null),
(3, 3, 3, 60, 1000, 2000, 1000, null, null, 3, 10, 10, 'ok', null)